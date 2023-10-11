using Schedule.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Models.Service
{
    public class RandomService:IRandomService
    {
        readonly int START_VALUE = 100;
        readonly int END_VALUE = 1000;
        private Random rnd;
        public RandomService() 
        {
            rnd = new Random();
        }
        public int GetRandomValue()
        {
            return rnd.Next(START_VALUE, END_VALUE);
        }
        public DateTime GetRandomDate()
        {
            DateTime date = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - date).Days;
            return date.AddDays(rnd.Next(range));
        }
    }
}
