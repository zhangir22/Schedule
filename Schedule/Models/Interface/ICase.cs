using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Models.Interface
{
    public interface ICase
    {
        string NameCase { get; set; }
        string DescriptionCase { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        double Duratation { get; set; }
        bool Pending { get; set; }
        bool Jeopardy { get; set; }
        bool Completed { get; set; }
    }
}
