using Schedule.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Models.Interface
{
    public interface ICaseService
    {  
        List<Case> GetCases();
        Case GetCaseById(int id);
        bool FindCase(int id);
        int GetCountCompleted();
        int GetCountPending();
        int GetCountJeopardy();
    }
}
