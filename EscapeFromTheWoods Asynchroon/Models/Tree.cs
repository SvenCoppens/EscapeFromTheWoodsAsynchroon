using EscapeFromTheWoods_Asynchroon.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EscapeFromTheWoods_Asynchroon.Models
{
    class Tree : IEquatable<Tree>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int ID { get; set; }
        public Tree(int id,int x,int y)
        {
            ID = id;
            X = x;
            Y = y;
        }
        public override bool Equals(object obj) => Equals(obj as Tree);
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, ID);
        }

        public bool Equals(Tree other)
        {
            if (other is null)
                return false;
            else
            return (ID == other.ID && X == other.X && Y == other.Y);
        }
    }
}
