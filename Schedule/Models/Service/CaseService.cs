using Schedule.Models.EF;
using Schedule.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Models
{
    public class CaseService : ICaseService
    {
        private Context _db { get; } = new Context();
        public bool FindCase(int id)
        {
            return _db.cases.ToList().Contains(GetCaseById(id));
        }

        public Case GetCaseById(int id)
        {
            return _db.cases.FirstOrDefault(c => c.Id == id);
        }

        public List<Case> GetCases()
        {
            return _db.cases.ToList();
        }

        public int GetCountCompleted()
        {
            return _db.cases.Where(c => c.Completed!= false).Select(c=>c.Completed).Count(); 
        }

        public int GetCountJeopardy()
        {
            return _db.cases.Where(c => c.Jeopardy!= false).Select(c=>c.Jeopardy).Count();
        }

        public int GetCountPending()
        {
            return _db.cases.Where(c=>c.Pending!=false).Select(c=>c.Pending).Count();
        }
    }
}
