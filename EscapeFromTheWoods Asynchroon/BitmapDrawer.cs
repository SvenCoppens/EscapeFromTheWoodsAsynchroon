using EscapeFromTheWoods_Asynchroon.interfaces;
using EscapeFromTheWoods_Asynchroon.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace EscapeFromTheWoods_Asynchroon
{
    class BitmapDrawer
    {
        string _path = @"D:\Programmeren Data en Bestanden\EscapeFromTheWoods\bitmaps";
        public void DrawMap(iWood wood)
        {
            Bitmap bm = new Bitmap(wood.maximumX * 10, wood.MaximumY * 10);
            Pen circleDrawer = new Pen(Color.DarkGreen);

            Pen[] pens = new Pen[10];
            pens[0] = new Pen(Color.Purple, 10);
            pens[1] = new Pen(Color.Red, 10);
            pens[2] = new Pen(Color.Blue, 10);
            pens[3] = new Pen(Color.Yellow, 10);
            pens[4] = new Pen(Color.Lime, 10);
            pens[5] = new Pen(Color.Orange, 10);
            pens[6] = new Pen(Color.Aqua, 10);
            pens[7] = new Pen(Color.Beige, 10);
            pens[8] = new Pen(Color.Brown, 10);
            pens[9] = new Pen(Color.DarkBlue, 10);

            Brush[] brushes = new Brush[10];
            brushes[0] = new SolidBrush(Color.Green);
            brushes[1] = new SolidBrush(Color.Red);
            brushes[2] = new SolidBrush(Color.Blue);
            brushes[3] = new SolidBrush(Color.Yellow);
            brushes[4] = new SolidBrush(Color.Lime);
            brushes[5] = new SolidBrush(Color.Orange);
            brushes[6] = new SolidBrush(Color.Aqua);
            brushes[7] = new SolidBrush(Color.Beige);
            brushes[8] = new SolidBrush(Color.Brown);
            brushes[9] = new SolidBrush(Color.DarkBlue);

            using (Graphics g = Graphics.FromImage(bm))
            {
                Console.WriteLine($"BITMAP: Started bitmap drawing for {wood.Id}");
                //bomen tekenen
                foreach (iTree tree in wood.Trees)
                {
                    g.DrawEllipse(circleDrawer, tree.X*10, tree.Y*10, 10, 10);
                }
                //voor elk aapje de tekening maken
                for (int i = 0; i < wood.Monkeys.Count; i++)
                {
                    //beginboom
                    g.FillEllipse(brushes[i], wood.Monkeys[i].VisitedTrees[0].X*10, wood.Monkeys[i].VisitedTrees[0].Y*10, 10, 10);
                    for (int index = 1; index < wood.Monkeys[i].VisitedTrees.Count; index++)
                    {
                        //lijnen tussen de bomen
                        var temptrees = wood.Monkeys[i].VisitedTrees;
                        g.DrawLine(pens[i], temptrees[index - 1].X*10, temptrees[index - 1].Y*10, temptrees[index].X*10, temptrees[index].Y*10);
                    }
                }
            }
            bm.Save(Path.Combine(_path, wood.Id.ToString() + " escapeRoutes.jpg"), ImageFormat.Jpeg);
            Console.WriteLine($"BITMAP: Finished bitmap drawing for {wood.Id}");
        }
    }
}
