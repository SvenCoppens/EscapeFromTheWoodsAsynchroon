using EscapeFromTheWoods_Asynchroon.interfaces;
using EscapeFromTheWoods_Asynchroon.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EscapeFromTheWoods_Asynchroon.Factories
{
    class WoodFactory : iWoodFactory
    {
        public iTreeFactory TreeFactory { get; set; }
        public iWood CreateWood(int maxX,int maxY, int numberOfTrees, List<iMonkey> monkeys)
        {
            TreeFactory = new TreeFactory(maxX, maxY);
            int iD = IdGenerator.GetNextId();
            List<iTree> trees = FillWithTrees(numberOfTrees);
            Wood wood = new Wood(iD, maxX, maxY,monkeys,trees);
            return wood;
        }
        public List<iTree> FillWithTrees(int amount)
        {
            return TreeFactory.MakeTrees(amount,TreeTypes.Standard);
        }
        
    }
}
