using EscapeFromTheWoods_Asynchroon.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheWoods_Asynchroon.interfaces
{
    interface iWood
    {
        int Id { get; set; }
        int maximumX { get; set; }
        int MaximumY { get; set; }
        List<iMonkey> Monkeys { get; set; }
        List<Tree> Trees { get; set; }
        void LetTheMonkeysLoose();
    }
}
