using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheWoods_Asynchroon.interfaces
{
    interface iWoodFactory
    {
        iWood CreateWood(int maxX, int maxY, int numberOfTrees,List<iMonkey> monkeys);
    }
}
