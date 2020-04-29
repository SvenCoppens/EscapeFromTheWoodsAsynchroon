using EscapeFromTheWoods_Asynchroon.Factories;
using EscapeFromTheWoods_Asynchroon.Models;
using System;
using System.Threading;

namespace EscapeFromTheWoods_Asynchroon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Program");
            MonkeyGenerator monkeyFactory = new MonkeyGenerator();
            WoodGenerator woodFactory = new WoodGenerator(monkeyFactory);
            DatabaseWriter dbWriter = new DatabaseWriter();
            ReportWriter reportWriter = new ReportWriter();
            BitmapDrawer mapDrawer = new BitmapDrawer();

            var wood1 = woodFactory.CreateWood(100, 100, 4,500);
            var wood2 = woodFactory.CreateWood(200, 200, 3, 800);
            Thread letLooseW1 = new Thread(wood1.LetTheMonkeysLoose);
            letLooseW1.Start();
            Thread letLooseW2 = new Thread(wood2.LetTheMonkeysLoose);
            letLooseW2.Start();

            letLooseW1.Join();
            Thread draw1 = new Thread(() => mapDrawer.DrawMap(wood1));
            draw1.Start();
            Thread dataWriter1 = new Thread(() => dbWriter.FillDataBase(wood1));
            dataWriter1.Start();
            Thread reporter1 = new Thread(() => reportWriter.WriteReport(wood1));
            reporter1.Start();

            letLooseW2.Join();
            Thread draw2 = new Thread(() => mapDrawer.DrawMap(wood2));
            draw2.Start();
            Thread dataWriter2 = new Thread(() => dbWriter.FillDataBase(wood2));
            dataWriter2.Start();
            Thread reporter2 = new Thread(() => reportWriter.WriteReport(wood2));
            reporter2.Start();

        }
    }
}
