using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Models.Interface
{
    public interface ICaseRedactService
    {
        void AddCase(Case newCase );
        void EditCase(int? id, Case caseVM);
       
    }
}
