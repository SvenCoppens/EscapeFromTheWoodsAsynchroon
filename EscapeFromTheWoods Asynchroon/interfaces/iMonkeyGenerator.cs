using EscapeFromTheWoods_Asynchroon.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheWoods_Asynchroon.interfaces
{
    interface iMonkeyGenerator
    {
        List<Monkey> GenerateMonkeys(int amount);
    }
}
