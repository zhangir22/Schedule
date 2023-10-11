using Bitlush;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Models.Interfaces
{
    public interface ITreeService
    {
        AvlTree<string, Case> GetTree(List<Case>cases);

    }
}
