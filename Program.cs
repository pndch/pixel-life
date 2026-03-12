using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
using System.Threading;
using static Raylib_cs.Raylib;
using pixellife;

class Program
{
    static public int[,,] mash = new int[g.maxX, g.maxY, 2];
    // | horizontal | vertical | 0-type of thing on 1-for some species like bot id |
    // 0 - nothing | 1 - bot | 2 - food
    
    static void Main()
    {

        Thread setting = new Thread(() =>
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new pixellife.Form1());
        });
        setting.SetApartmentState(ApartmentState.STA);
        setting.Start();

        Bot.init(0);
        initFood();

        InitWindow(g.width, g.height, "pixel");
        SetTargetFPS(g.speed);

        while (WindowShouldClose() == false)
        {
            //event handle

            // -----end of sim-----
            if (Bot.countAlive <= 0)
            {
                mash = new int[g.width / g.size, g.height / g.size, 2];
                Bot.init(g.strategyOfNextGeneration);
                initFood();
                if (a.Aflag == true) { a.end(); }
            }

            //update pos

            for (int i = 0; i < Bot.countAll; i++)
            {
                if (Bot.bots[i].alive) { Bot.bots[i].move(); }
            }

            if (a.Aflag == true) { a.timer++; }

            //draw
            BeginDrawing();
            ClearBackground(Raylib_cs.Color.Black);

            if (g.FPSflag == true) { DrawFPS(10, 10); }
            for (int i = 0; i < g.width / g.size; i++)
            {
                for (int j = 0; j < g.height / g.size; j++)
                {
                    switch (mash[i, j, 0])
                    {
                        case 1:
                            DrawRectangle(Bot.bots[mash[i, j, 1]].x * g.size, Bot.bots[mash[i, j, 1]].y * g.size, g.size, g.size, Bot.bots[mash[i, j, 1]].clr);
                            break;
                        case 2:
                            DrawRectangle(i * g.size, j * g.size, g.size, g.size, Raylib_cs.Color.Violet);
                            break;
                    }
                }
            }

            EndDrawing();
        }
        CloseWindow();
    }

    public static void initFood()
    {
        Random rnd = new Random();
        int i = 0;
        int tmpx, tmpy;

        while (i < g.foodCount)
        {
            tmpx = rnd.Next(g.width / g.size);
            tmpy = rnd.Next(g.height / g.size);

            if (mash[tmpx, tmpy, 0] == 0) { mash[tmpx, tmpy, 0] = 2; i++; }
        }
    }
}


