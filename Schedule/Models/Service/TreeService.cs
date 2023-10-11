using Bitlush;
using Schedule.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Models.Service
{
    public class TreeService : ITreeService
    {
        public AvlTree<string, Case> GetTree(List<Case> cases)
        {
            AvlTree<string,Case> tree = new AvlTree<string,Case>();
            foreach(var item in cases)
            {
                tree.Insert(item.Id, item);
            }return tree;
        }
    }
}
