using Schedule.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Models.Service
{
    public class CaseService:ICaseService
    {
        readonly IRandomService _random = new RandomService();
 
        public List<Case> GetCases()
        {
           
            List<Case> cases = new List<Case>();
            for (int i = 0; i < _random.GetRandomValue(); i++)
            {
                DateTime startDate = _random.GetRandomDate();
                DateTime endDate = startDate.AddDays(_random.GetRandomValue());
                cases.Add(new Case
                {
                    Id = Guid.NewGuid().ToString(),
                    NameCase = _random.GetRandomValue().ToString(),
                    StartTime = startDate,
                    EndTime = endDate,
                    Duratation = (endDate - startDate).TotalHours,
                    Completed = false,
                    Pending = true,
                    Jeopardy = false,
                });

            }
 
            return cases;
        }
         
    }
}
