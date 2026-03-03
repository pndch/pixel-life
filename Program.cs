using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
using static Raylib_cs.Raylib;

public static class g
{
    public const int height = 640;
    public const int width = 640;
    public const byte size = 8;
    public const int maxTimer = 50000;

    public const int botCount = 32;
    public const int maximumBotCount = 1024;
    public const int foodCount = 0;
    public const int dnaSize = 64; // 2^x req
    public const int commandsCount = 16; //9 real

    public const int startHP = 80;
    public const int dupeHP = 50;
    public const int botTransferCount = 24;
    public const int mutationFactor = 16; // 1 == no mutation // 3 == 1/3 of genom randomized 
    public const int strategyOfNextGeneration = 1; //1 - botTransferCount >> NextGeneration // 2 - BestBot >> NextGeneration
}

public class Bot
{
    private static Random rnd = new Random();
    public static Bot[] bots = new Bot[g.maximumBotCount];
    public static int countAlive = 0;
    public static int countAll = 0;
    public static int[,] xy = new int[g.botCount, 2];
    public static int[,] dnaBuf = new int[g.botTransferCount, g.dnaSize];

    public int age = 0;
    public int hp = g.startHP;
    public bool alive = true;
    public int x;
    public int y;
    public int rotation = 0; // 0-up 1-right 2-down 3-left
    public int generation = 0;
    public int[] dna;
    public int nextDna = 0;
    public Color clr = Color.Lime;

    public Bot()
    {
        countAll += 1;
        countAlive += 1;
        
        dna = new int[g.dnaSize];
        

        for (int i = 0; i < g.dnaSize; i++)
        {
            dna[i] = rnd.Next(g.commandsCount)+1;
        }

        x = rnd.Next(g.height / g.size) ;
        y = rnd.Next(g.height / g.size) ;
    }

    public void dupe()
    {
        if ((hp >= g.dupeHP*2) && (countAll < g.maximumBotCount))
        {
            hp -= g.dupeHP;
            bots[countAll] = new Bot();
            bots[countAll - 1].generation = generation + 1;
            bots[countAll - 1].hp = g.dupeHP/5*3;
            switch (rnd.Next(4))
            {
                case 0:
                    bots[countAll - 1].x = x + 1;
                    bots[countAll - 1].y = y + 1;
                    break;
                case 1:
                    bots[countAll - 1].x = x + 1;
                    bots[countAll - 1].y = y - 1;
                    break;
                case 2:
                    bots[countAll - 1].x = x - 1;
                    bots[countAll - 1].y = y + 1;
                    break;
                case 3:
                    bots[countAll - 1].x = x - 1;
                    bots[countAll - 1].y = y - 1;
                    break;
            }

            for (int j = 0; j < g.dnaSize; j++)
            {
                if (rnd.Next(g.mutationFactor) == 1)
                {
                    Bot.bots[countAll - 1].dna[j] = rnd.Next(g.commandsCount) + 1;
                }
                else
                {
                    Bot.bots[countAll - 1].dna[j] = dna[j];
                }
            }
        }
        else { doDna(); }
    }
    public void move(int xx, int yy)
    {
        switch(rotation) // 0-up 1-right 2-down 3-left
        {
            case 0:
                x = x + xx;
                y = y + yy;
                break;
            case 1:
                x = x - yy;
                y = y - xx;
                break;
            case 2:
                x = x - xx;
                y = y - yy;
                break;
            case 3:
                x = x + yy;
                y = y + xx;
                break;
        }
    }

    public void doDna()
    {
        int currentDna = nextDna;

        if (alive == true)
        {
            // ---next iteration preparetion---
            age++; hp--;
            if (hp <= 0)
            {
                alive = false;
                clr = Color.Red;
                if (countAlive <= g.botTransferCount)
                {
                    for (int j = 0; j < g.dnaSize; j++)
                    {
                        dnaBuf[countAlive - 1, j] = dna[j];
                    }
                }
                age = 0;
                countAlive -= 1;
            } //dead check
            if (nextDna == g.dnaSize - 1) { nextDna = 0; }else { nextDna++; } //dna switch

            // ---dna command---
            switch (dna[currentDna])
            {
                case 1:
                    move(0, -1); //up
                    break;
                case 2:
                    move(0, 1); //down
                    break;
                case 3:
                    move(-1, 0); //left
                    break;
                case 4:
                    move(1, 0); //right
                    break;
                case 5:
                    move(-1, -1); //upleft
                    break;
                case 6:
                    move(1, -1); //upright
                    break;
                case 7:
                    move(-1, 1); //downleft
                    break;
                case 8:
                    move(1, 1); //downright
                    break;
                case 9: //90
                    rotation += 1;
                    while (rotation > 3) { rotation -= 4; }
                    dupe();
                    break;
                case 10: //180
                    rotation += 2;
                    while (rotation > 3) { rotation -= 4; }
                    dupe();
                    break;
                case 11: //270
                    rotation += 3;
                    while (rotation > 3) { rotation -= 4; }
                    dupe();
                    break;
                case 12: //photosythesis
                    hp += 4;
                    break;
                case 13: //dupe
                    dupe();
                    break;
            }

            // ---invalid position check---
            if (x > g.height / g.size) { x = g.height / g.size; }
            if (y > g.height / g.size) { y = g.height / g.size; }
            if (x < 0) { x = 0; }
            if (y < 0) { y = 0; }

        }
    }
}

class Program
{
    static public int[,] food = new int[g.foodCount, 2];

    static void Main()
    {
        initBots(0);
        drawBots();

    }
    

    static void initBots(int x)
    {
        Random rnd = new Random();
        Bot.countAlive = 0;
        Bot.countAll = 0;

        if (x == 0)
        {
            for (int i = 0; i < g.botCount; i++)
            {
                Bot.bots[i] = new Bot();
            }
        }
        else if (x == 1)
        {
            for (int i = 0; i < g.botTransferCount; i++)
            {
                Bot.bots[i] = new Bot();
                for (int j = 0; j < g.dnaSize; j++)
                {
                    if (rnd.Next(g.mutationFactor) == 1)
                    {
                        Bot.bots[i].dna[j] = rnd.Next(g.commandsCount) + 1;
                    }
                    else
                    {
                        Bot.bots[i].dna[j] = Bot.dnaBuf[i, j]; 
                    }
                }
            }
            
            for (int i = g.botTransferCount; i < g.botCount; i++) { Bot.bots[i] = new Bot(); }
        }
        else if (x == 2)
        {
            for (int i = 0; i < g.botCount; i++)
            {
                Bot.bots[i] = new Bot();
                for (int j = 0; j < g.dnaSize; j++)
                {
                    if (rnd.Next(g.mutationFactor) == 1) { Bot.bots[i].dna[j] = rnd.Next(g.commandsCount) + 1; }
                    else { Bot.bots[i].dna[j] = Bot.dnaBuf[0, j]; }
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
        string reset = "\u001b[0m";
        string red = "\u001b[31m";
        string green = "\u001b[32m"; //38;5;22m";

        int timer = 0;
        int tempOutput = 0;
        int tempAgeCounter = 0;
        int tempAgeId = 0;
        int[] timerBuffer = [0, 0];
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

            if (Bot.countAlive <= 0)
            {
                initBots(g.strategyOfNextGeneration);
                if (timer == timerBuffer[0]) { timerBuffer[1]++; }
                else 
                {
                    tempOutput = timer - timerBuffer[0];
                    if (tempOutput > 0) { Console.WriteLine($"{timer,5} : {green}+{tempOutput,5}{reset} :{timerBuffer[1],3}"); }
                    else { Console.WriteLine($"{timer,5} : {red}-{tempOutput*-1,5}{reset} :{timerBuffer[1],3}"); }
                    timerBuffer[0] = timer; timerBuffer[1] = 1; }
                timer = 0;
                iteration++;
            }
            // -----end of sim-----
            else if (timer > g.maxTimer)
            {
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
                        Console.Write( $"{ Bot.bots[tempAgeId].dna[j + i * (int)Math.Sqrt(g.dnaSize)], 4}" );
                    }
                    Console.WriteLine("\n");
                }
                System.Threading.Thread.Sleep(5000);

                iteration = 0;
                timer = 0;
                initBots(0);
            }

            //update pos
            for (int i = 0; i < Bot.countAll; i++)
            {
                Bot.bots[i].doDna();
            }

            //draw
            BeginDrawing();
            ClearBackground(Color.Black);

            for (int i = 0; i < Bot.countAll; i++) { DrawRectangle(Bot.bots[i].x * g.size, Bot.bots[i].y * g.size, g.size, g.size, Bot.bots[i].clr); }
            for (int i = 0; i < g.foodCount; i++) { DrawRectangle(food[i, 0] * g.size, food[i, 1] * g.size, g.size, g.size, Color.Violet); }
            timer++;

            EndDrawing();
        }

        CloseWindow();
    }
}


