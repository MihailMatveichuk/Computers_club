using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers_club
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class ComputerClub
    {
        private List<Computer> _computers = new List<Computer>();
        private Queue<SchoolBoy> _schoolBoys = new Queue<SchoolBoy>();
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
            if (IsBusy) Console.WriteLine($"Computer is busy. {_minutesLeft} are left");
            else Console.WriteLine($"Computer is free. Price for minute equals {PriceForMinute}");
        }
    }

    class SchoolBoy
    {
        private int _money;

        public int DesiredMinutes { get; private set; }

        public SchoolBoy(int money)
        {
            Random random = new Random();
            _money = money;
            DesiredMinutes = random.Next(10, 30);
        }
    }
}
