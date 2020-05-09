using EscapeFromTheWoods_Asynchroon.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheWoods_Asynchroon.interfaces
{
    interface iMonkey
    {
        bool Escaped { set; get; }
        int Id { get; set; }
        string Name { get; set; }
        List<Tree> VisitedTrees { get; set; }
        public void JumpToNextTree(iWood wood);
    }
}
