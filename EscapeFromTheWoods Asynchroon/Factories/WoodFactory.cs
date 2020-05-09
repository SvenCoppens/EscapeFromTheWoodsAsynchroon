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
        public WoodFactory(iTreeFactory treeFactory)
        {
            TreeFactory = treeFactory;
        }
        public iWood CreateWood(int maxX,int maxY, int numberOfTrees, List<iMonkey> monkeys)
        {
            int iD = IdGenerator.GetNextId();
            List<Tree> trees = TreeFactory.MakeTrees(numberOfTrees,maxX,maxY);
            Wood wood = new Wood(iD, maxX, maxY,monkeys,trees);
            return wood;
        }
        
    }
}
