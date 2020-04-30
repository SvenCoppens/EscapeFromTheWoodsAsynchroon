using EscapeFromTheWoods_Asynchroon.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheWoods_Asynchroon.interfaces
{
    interface iMonkeyFactory
    {
        public List<iMonkey> GetMonkeys(int amount, MonkeyTypes monkeytype);
    }
}
