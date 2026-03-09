using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
using static Raylib_cs.Raylib;

class Program
{
    static public int[,,] mash = new int[g.maxX, g.maxY, 2];
    // | horizontal | vertical | 0-type of thing on 1-for some species like bot id |
    // 0 - nothing | 1 - bot | 2 - food

    static void Main()
    {
        int timer = 0;
        int record = 0;
        int[] timerBuffer = [0, 0];
        int iteration = 0;

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

                if (timer > record)
                {
                    Console.WriteLine($"\n\nNew record: {g.positive}{timer,8}{g.reset}    Old record: {record,8} : +{timer - record}");
                    record = timer;
                }
                else
                {
                    Console.WriteLine($"\n\nrecord: {g.positive}{record,8}{g.reset}");
                }
                Console.WriteLine($"iteration: {iteration}");
                Console.WriteLine("genome of last bot: \n");

                for (int i = 0; i < g.eventsCount; i++)
                {
                    for (int j = 0; j < g.thingCount * g.sensorCount; j++)
                    {
                        Console.Write($"{Bot.savedDna[0, i, j]:F2} ");
                    }
                    //Console.Write($"{Bot.savedDna[0, i, i*2]:F2} ");
                    Console.WriteLine();
                }

                //if (timer > record)
                //{
                //    Console.WriteLine($"New record: {g.positive}{timer,8}{g.reset}    Old record: {record,8} : +{timer - record}");
                //    Console.WriteLine($"iteration: {iteration}");
                //    Console.WriteLine("genome of last 2 bots: \n");
                //    for (int i = 0; i < Math.Sqrt(g.dnaSize); i++)
                //    {
                //        for (int j = 0; j < Math.Sqrt(g.dnaSize); j++)
                //        {
                //            Console.Write($"{Bot.dnaBuf[0, j + i * (int)Math.Sqrt(g.dnaSize)],4}");
                //        }
                //        Console.Write($"   |   ");
                //        for (int j = 0; j < Math.Sqrt(g.dnaSize); j++)
                //        {
                //            Console.Write($"{Bot.Sdna[1, j + i * (int)Math.Sqrt(g.dnaSize)],4}");
                //        }
                //        Console.WriteLine("\n");
                //    }
                //    record = timer;
                //}
                timer = 0;
                iteration++;
            }

            //update pos

            for (int i = 0; i < Bot.countAll; i++)
            {
                if (Bot.bots[i].alive) { Bot.bots[i].move(); }
            }

            timer++;

            //draw
            BeginDrawing();
            ClearBackground(Color.Black);

            DrawFPS(10, 10);
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
                            DrawRectangle(i * g.size, j * g.size, g.size, g.size, Color.Violet);
                            break;
                    }
                }
            }
            EndDrawing();
        }

        // --- логи после закрытия программы ---
        //if (timer > record) { record = timer; }
        //Console.WriteLine($"{g.negative} ------------------------statistic of simulation------------------------{g.reset}\n");
        //Console.WriteLine($"  record: {g.positive}{record,8}{g.reset} iteration: {iteration}");
        //Console.WriteLine($"  genome of last 2 bots: \n");
        //for (int i = 0; i < Math.Sqrt(g.dnaSize); i++)
        //{
        //    for (int j = 0; j < Math.Sqrt(g.dnaSize); j++)
        //    {
        //        Console.Write($"{Bot.dnaBuf[0, j + i * (int)Math.Sqrt(g.dnaSize)],4}");
        //    }
        //    Console.Write($"   | ");
        //    for (int j = 0; j < Math.Sqrt(g.dnaSize); j++)
        //    {
        //        Console.Write($"{Bot.dnaBuf[1, j + i * (int)Math.Sqrt(g.dnaSize)],4}");
        //    }
        //    Console.WriteLine("\n");
        //}
        //Console.WriteLine($"{g.negative} ------------------------statistic of simulation------------------------{g.reset}\n");
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


