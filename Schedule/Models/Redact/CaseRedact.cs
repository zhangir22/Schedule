using Schedule.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schedule.Models.EF;
using System.Data.Entity.Migrations;
using Schedule.Models.Service;
using System.Linq.Expressions;

namespace Schedule.Models.Service
{
    public class CaseRedact : ICaseRedactService
    {
        private Context _db { get; } 
        ICaseService _caseService { get; set; }
        public CaseRedact()
        {
            _db = new Context();
        }
        public void AddCase(Case newCase )
        {   
            _caseService = new CaseService();
            if(newCase != null)
            {
                if (_caseService.GetCaseById(newCase.Id) == null)
                {
                    _db.cases.Add(newCase);
                    _db.SaveChanges();
                }
            }
           
        }

    

        public void EditCase(int? id , Case model)
        {
            _caseService = new CaseService();
            if(id != null)
            {
                Case currentCase = _caseService.GetCaseById((int)id);
                if (currentCase!=null) 
                {
                    if(model != null)
                    {

                        currentCase.NameCase = model.NameCase;
                        currentCase.DescriptionCase = model.DescriptionCase;
                        currentCase.StartTime = model.StartTime;
                        currentCase.EndTime = model.EndTime;
                        currentCase.Completed = model.Completed;
                        currentCase.Pending = model.Pending;
                        currentCase.Jeopardy = model.Jeopardy;
                        currentCase.Duratation = model.EndTime.Hour - model.StartTime.Hour;
                         _db.cases.AddOrUpdate(currentCase);
                        _db.SaveChanges();
                    }
                }
            }
        }
        
    }
}
