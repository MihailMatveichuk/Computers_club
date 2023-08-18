using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Computers_club
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComputerClub computerClub = new ComputerClub(8);
            computerClub.Work();
        }
    }
    class ComputerClub
    {
        private List<Computer> _computers = new List<Computer>();
        private Queue<SchoolBoy> _schoolBoys = new Queue<SchoolBoy>();
        private int _money = 0;

        public ComputerClub(int computersCount)
        {
            Random rand = new Random();

            for (int i = 0; i < computersCount; i++)
            {
                _computers.Add(new Computer(rand.Next(5, 15)));
            }
            CreateNewSchoolBoys(25);
        }
        private void CreateNewSchoolBoys(int value)
        {
            Random rand = new Random();

            for (int i = 0; i < value; i++)
            {

                _schoolBoys.Enqueue(new SchoolBoy(rand.Next(100, 250), rand));
            }
        }

        public void Work()
        {
            while (_schoolBoys.Count > 0)
            {
                Console.WriteLine($"Our computer club have {_money} rubles now. We are waiting a new client!!!");

                SchoolBoy schoolBoy = _schoolBoys.Dequeue();
                Console.WriteLine($"The new young boy in queue. He wants to buy {schoolBoy.DesiredMinutes} minutes for play");

                Console.WriteLine("\nList of computers: ");
                ShowAllComputers();

                Console.Write("\nWe are offering him PC under number - ");
                try
                {
                    int computerNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (computerNumber >= 0 && computerNumber < _computers.Count)
                    {
                        if (_computers[computerNumber].IsBusy)
                        {
                            Console.WriteLine("This computer has already busied");
                        }
                        else
                        {
                            if (schoolBoy.CheckSolvency(_computers[computerNumber]))
                            {
                                Console.WriteLine("Count the money, client paid for neccesary time and sat down at computer");
                                _money += schoolBoy.ToPay();

                                _computers[computerNumber].TakeThePlace(schoolBoy);
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong");
                            }
                        }
                    }
                    else Console.WriteLine("We don't have such computer. Client is gone out.");

                    Console.WriteLine("For going to a new client press any key");
                    SkipMinutes();
                }
                catch
                {
                    Console.WriteLine("Number was not valid!!");
                }
                Console.ReadKey();
                Console.Clear();


            }
        }

        private void ShowAllComputers()
        {
            for (int i = 0; i < _computers.Count; i++)
            {
                Console.Write($"{i + 1} - ");
                _computers[i].ShowComputersInfo();
            }
        }
        public void SkipMinutes()
        {
            foreach (var compute in _computers)
            {
                compute.SkipMinutes();
            }
        }
    }





    class Computer
    {
        private SchoolBoy _schoolBoy;
        private int _minutesLeft;

        public int PriceForMinute { get; private set; }
        public bool IsBusy
        {
            get
            {
                return _minutesLeft > 0;
            }
        }

        public Computer(int priceForMinute)
        {
            PriceForMinute = priceForMinute;
        }

        public void TakeThePlace(SchoolBoy schoolBoy)
        {
            _schoolBoy = schoolBoy;
            _minutesLeft = _schoolBoy.DesiredMinutes;
        }

        public void FreeThePlace()
        {
            _schoolBoy = null;
        }

        public void SkipMinutes()
        {
            _minutesLeft--;
        }

        public void ShowComputersInfo()
        {
            if (IsBusy) Console.WriteLine($"Computer is busy. {_minutesLeft} minutes are left");
            else Console.WriteLine($"Computer is free. Price for minute equals {PriceForMinute}");
        }
    }

    class SchoolBoy
    {
        private int _money;
        private int _moneyToPay;

        public int DesiredMinutes { get; private set; }

        public SchoolBoy(int money, Random random)
        {
            _money = money;
            DesiredMinutes = random.Next(10, 30);
        }

        public bool CheckSolvency(Computer computer)
        {
            _moneyToPay = computer.PriceForMinute * DesiredMinutes;
            if (_money >= _moneyToPay) return true;
            else
            {
                _moneyToPay = 0;
                return false;
            };
        }

        public int ToPay()
        {
            _money -= _moneyToPay;
            return _moneyToPay;
        }
    }
}
