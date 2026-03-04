using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
using static Raylib_cs.Raylib;

class Program
{
    static public int[,,] mash = new int[g.width / g.size, g.height / g.size, 2];
    // | horizontal | vertical | 0-type of thing on 1-for some species like bot id |
    // 0 - nothing | 1 - bot | 2 - food

    static void Main()
    {
        int timer = 0;
        int tempOutput = 0;
        int tempAgeCounter = 0;
        int tempAgeId = 0;
        int[] timerBuffer = [0, 0];
        int iteration = 0;

        Bot.initBots(0);
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
                Bot.initBots(g.strategyOfNextGeneration);
                initFood();
                if (timer == timerBuffer[0]) { timerBuffer[1]++; }
                else
                {
                    tempOutput = timer - timerBuffer[0];
                    if (tempOutput > 0) { Console.WriteLine($"{timer,5} : {g.positive}+{tempOutput,5}{g.reset} :{timerBuffer[1],3}"); }
                    else { Console.WriteLine($"{timer,5} : {g.negative}-{tempOutput * -1,5}{g.reset} :{timerBuffer[1],3}"); }
                    timerBuffer[0] = timer; timerBuffer[1] = 1;
                }

                timer = 0;
                iteration++;
            }
            else if (timer > g.maxTimer)
            {
                mash = new int[g.width / g.size, g.height / g.size, 2];
                for (int i = 0; i < Bot.countAll; i++)
                {
                    if (Bot.bots[i].alive == true && Bot.bots[i].age > tempAgeCounter) { tempAgeCounter = Bot.bots[i].age; tempAgeId = i; }
                }
                Console.WriteLine("\n-----simulaton was ended with " + iteration + " iterations and " + Bot.countAlive + " bots-----");
                Console.WriteLine("age of oldest bot: " + tempAgeCounter);
                Console.WriteLine("genome of oldest bot: \n");
                for (int i = 0; i < Math.Sqrt(g.dnaSize); i++)
                {
                    for (int j = 0; j < Math.Sqrt(g.dnaSize); j++)
                    {
                        Console.Write($"{Bot.bots[tempAgeId].dna[j + i * (int)Math.Sqrt(g.dnaSize)],4}");
                    }
                    Console.WriteLine("\n");
                }
                System.Threading.Thread.Sleep(5000);

                iteration = 0;
                timer = 0;
                Bot.initBots(0);
                initFood();
            }

            //update pos

            for (int i = 0; i < Bot.countAll; i++)
            {
                if (Bot.bots[i].alive) { Bot.bots[i].doDna(); }
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


