using Schedule.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Schedule.Models
{
    public class Case : ICase
    {
        public int Id { get; set; }
        public string NameCase {get;set; }
        public string DescriptionCase { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Duratation { get; set; }
        public bool Pending { get; set; }
        public bool Jeopardy { get; set; }
        public bool Completed { get; set; }
    }
}
