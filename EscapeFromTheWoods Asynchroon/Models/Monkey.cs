using EscapeFromTheWoods_Asynchroon.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EscapeFromTheWoods_Asynchroon.Models
{
    class Monkey //: iMonkey
    {
        public Monkey(int id, string name)
        {
            Id = id;
            Name = name;
            VisitedTrees = new List<Tree>();
            Escaped = false;
        }
        public bool Escaped { private set; get; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tree> VisitedTrees;
        public void HasEscaped()
        {
            Escaped = true;
        }
    }
}
