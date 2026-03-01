using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
using static Raylib_cs.Raylib;

public static class g
{
    public const int height = 640;
    public const int width = 640;
    public const byte size = 8;
    public const int maxTimer = 10000;

    public const int botCount = 32;
    public const int foodCount = 32;
    public const int dnaSize = 64;
    public const int commandsCount = 16; //9 real

    public const int botTransferCount = 4;
    public const int mutationFactor = 512; // 1 == no mutation // 3 == 1/3 of genom randomized 
    public const int strategyOfNextGeneration = 2; //1 - botTransferCount >> NextGeneration // 2 - BestBot >> NextGeneration
}

public class Bot
{
    private static Random rnd = new Random();
    public static int count = 0;
    public static int[,] xy = new int[g.botCount, 2];

    public int hp = 100;
    public bool alive = true;
    public int x;
    public int y;
    public int[] dna;
    public int nextDna = 0;
    public Color clr = Color.Lime;

    public Bot()
    {
        count += 1;
        dna = new int[g.dnaSize];
        

        for (int i = 0; i < g.dnaSize; i++)
        {
            dna[i] = rnd.Next(g.commandsCount)+1;
        }

        x = rnd.Next(g.height / g.size) ;
        y = rnd.Next(g.height / g.size) ;
    }
}

class Program
{

    static public Bot[] bots = new Bot[g.botCount];
    static public int[,] dnaBuf = new int[8,g.dnaSize];
    static public int[,] food = new int[g.foodCount, 2];

    static void Main()
    {
        initBots(0);
        drawBots();

    }
    static void print()
    {
        Console.WriteLine(1);
    }

    static void initBots(int x)
    {
        Random rnd = new Random();
        Bot.count = 0;

        if (x == 0)
        {
            for (int i = 0; i < g.botCount; i++)
            {
                bots[i] = new Bot();
            }
        }
        else if (x == 1)
        {
            for (int i = 0; i < g.botTransferCount; i++)
            {
                bots[i] = new Bot();
                for (int j = 0; j < g.dnaSize; j++)
                {
                    if (rnd.Next(g.mutationFactor) == 1)
                    {
                        bots[i].dna[j] = rnd.Next(g.commandsCount) + 1;
                    }
                    else
                    {
                        bots[i].dna[j] = dnaBuf[i, j]; 
                    }
                }
            }
            
            for (int i = g.botTransferCount; i < g.botCount; i++)
            {
                bots[i] = new Bot();
            }
        }
        else if (x == 2)
        {
            for (int i = 0; i < g.botCount; i++)
            {
                bots[i] = new Bot();
                for (int j = 0; j < g.dnaSize; j++)
                {
                    if (rnd.Next(g.mutationFactor) == 1)
                    {
                        bots[i].dna[j] = rnd.Next(g.commandsCount) + 1;
                    }
                    else
                    {
                        bots[i].dna[j] = dnaBuf[0, j];
                    }
                }
            }
        }
        

        // ----- function to kill bots by themselves -----
        //for (int i = 0; i<g.botCount; i++) 
        //{
        //    Bot.xy[i, 0] = bots[i].x;
        //    Bot.xy[i, 1] = bots[i].y;
        //}
    }

    static void drawBots()
    {
        int timer = 0;
        int iteration = 0;
        
        Random rnd = new Random();

        InitWindow(g.width, g.height, "pixel");
        SetTargetFPS(0);

        // ----- creating food -----

        for (int i = 0; i < g.foodCount; i++)
        {
            food[i, 0] = rnd.Next(g.height / g.size);
            food[i, 1] = rnd.Next(g.height / g.size);
        }

        while (WindowShouldClose() == false)
        {
            //event handle
            DrawFPS(10, 10);

            if (Bot.count <= 0)
            {
                initBots(g.strategyOfNextGeneration);
                //Console.WriteLine(timer);
                iteration++;
                timer = 0;
            }
            else if (timer > g.maxTimer)
            {
                Console.WriteLine(iteration);
                iteration = 0;
                timer = 0;
                initBots(0);
            }

            //update pos
            for (int i = 0; i < g.botCount; i++)
            {
                if (bots[i].alive == true)
                {
                    switch (bots[i].dna[bots[i].nextDna])
                    {
                        case 1:
                            bots[i].y = bots[i].y - 1; //up
                            break;
                        case 2:
                            bots[i].y = bots[i].y + 1; //down
                            break;
                        case 3:
                            bots[i].x = bots[i].x - 1; //left
                            break;
                        case 4:
                            bots[i].x = bots[i].x + 1; //right
                            break;
                        case 5:
                            bots[i].x = bots[i].x - 1; //upleft
                            bots[i].y = bots[i].y - 1;
                            break;
                        case 6:
                            bots[i].x = bots[i].x + 1; //upright
                            bots[i].y = bots[i].y - 1;
                            break;
                        case 7:
                            bots[i].x = bots[i].x - 1; //downleft
                            bots[i].y = bots[i].y + 1;
                            break;
                        case 8:
                            bots[i].x = bots[i].x + 1; //downright
                            bots[i].y = bots[i].y + 1;
                            break;
                        case 9:
                            bots[i].hp += 2;
                            break;
                    }

                    if (bots[i].x > 80)
                    {
                        bots[i].x = 80;
                    }
                    if (bots[i].y > 80)
                    {
                        bots[i].y = 80;
                    }
                    if (bots[i].x < 0)
                    {
                        bots[i].x = 0;
                    }
                    if (bots[i].y < 0)
                    {
                        bots[i].y = 0;
                    }

                    if (bots[i].nextDna == g.dnaSize - 1)
                    {
                        bots[i].nextDna = 0;
                    }
                    else
                    {
                        bots[i].nextDna += 1;
                    }


                    bots[i].hp -= 1;
                    if (bots[i].hp <= 0) 
                    { 
                        bots[i].alive = false; 
                        bots[i].clr = Color.Red;
                        if (Bot.count <= g.botTransferCount)
                        {
                            for (int j = 0; j < g.dnaSize; j++)
                            {
                                dnaBuf[Bot.count-1, j] = bots[i].dna[j];
                            }
                        }
                        Bot.count -= 1;
                    }
                }
            }
            //draw
            BeginDrawing();
            ClearBackground(Color.Black);

            

            for (int i = 0; i < g.botCount; i++)
            {
                 DrawRectangle(bots[i].x * g.size, bots[i].y * g.size, g.size, g.size, bots[i].clr);
            }
            for (int i = 0; i < g.foodCount; i++)
            {
                DrawRectangle(food[i, 0] * g.size, food[i, 1] * g.size, g.size, g.size, Color.Violet);
            }

            timer++;
            EndDrawing();
        }

        CloseWindow();
    }
}


