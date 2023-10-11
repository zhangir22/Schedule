using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;



namespace Schedule.Models
{
    public class Case
    {
        public string Id { get; set; }
        public string NameCase {get;set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Duratation { set; get; } 

        public bool Pending { get; set; }
        public bool Jeopardy { get; set; }
        public bool Completed { get; set; }
 

    }
}
