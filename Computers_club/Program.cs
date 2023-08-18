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
