using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;

public class Bot
{
    private static Random rnd = new Random();
    public static Bot[] bots = new Bot[g.maximumBotCount];
    public static int countAlive = 0;
    public static int countAll = 0;
    //public static int[,] xy = new int[g.botCount, 2];
    //public static int[,] dnaBuf = new int[g.botTransferCount, g.dnaSize];
    public static int mvmCount = 20;
    public float[] probs = new float[g.eventsCount];
    public static int[,] mvm =
        {
            { 0, -1,}, { 0, 1}, {-1, 0}, { 1, 0}, { -1, -1}, {1, -1}, {-1, 1 }, {1, 1 },

            { 0, -2}, { 1, -2}, { -1, -2},
            { 0, 2}, { 1, 2}, { -1, 2},
            {-2, 0}, {-2, 1}, {-2, -1},
            { 2, 0}, { 2, 1}, { 2, -1},
        };

    public double hp;
    public bool alive = true;
    public int x;
    public int y;
    //public int rotation = 0; // 0-up 1-right 2-down 3-left
    public float[,] dna;
    public static float[,,] savedDna = new float[2, g.eventsCount, g.thingCount * g.sensorCount];
    public int[] sensOutput;
    public Raylib_cs.Color clr = Raylib_cs.Color.Lime;

    public Bot()
    {
        dna = new float[g.eventsCount, g.thingCount * g.sensorCount];
        sensOutput = new int[g.thingCount * g.sensorCount];

        for (int i = 0; i < g.eventsCount; i++)
        {
            for (int j = 0; j < g.thingCount * g.sensorCount; j++)
            {
                dna[i, j] = (float)(rnd.NextDouble() * 2 - 1);
            }
        }

        hp = g.startHP;

        x = rnd.Next(g.maxX);
        y = rnd.Next(g.maxY);
    }

    public static void init(int x)
    {
        countAlive = 0;
        countAll = 0;

        if (x == 0) // first iteration only
        {
            for (int i = 0; i < g.botCount*10; i++)
            {
                countAll += 1;
                countAlive += 1;

                while (true)
                {
                    bots[i] = new Bot();
                    if (Program.mash[bots[i].x, bots[i].y, 0] == 0) { Program.mash[bots[i].x, bots[i].y, 0] = 1; Program.mash[bots[i].x, bots[i].y, 1] = i; break; }
                }
            }
        }

        if (x == 1)
        {
            for (int b = 0; b < g.botCount; b++)
            {
                countAll += 1;
                countAlive += 1;

                while (true)
                {
                    bots[b] = new Bot();
                    if (Program.mash[bots[b].x, bots[b].y, 0] == 0) { Program.mash[bots[b].x, bots[b].y, 0] = 1; Program.mash[bots[b].x, bots[b].y, 1] = b; break; }
                }

                for (int i = 0; i < g.eventsCount; i++)
                {
                    for (int j = 0; j < g.thingCount * g.sensorCount; j++)
                    {
                        int temp = rnd.Next(g.mutationFactor);
                        if (temp == 0)
                        {
                            temp = rnd.Next(2) * 2 - 1;
                            bots[b].dna[i, j] = savedDna[0, i, j] * (float)0.98 + (float)(g.mutationStep * temp);
                        }
                        else { bots[b].dna[i, j] = savedDna[0, i, j]; }
                    }
                }
            }
        }
    }

    public void save(int x)
    {
        for (int i = 0; i < g.eventsCount; i++)
        {
            for (int j = 0; j < g.thingCount * g.sensorCount; j++)
            {
                savedDna[x, i, j] = dna[i, j];
            }
        }
    }

    void sensor()
    {
        sensOutput = new int[g.thingCount * g.sensorCount];

        for (int i = 0; i < 8; i++) //заполнение первых 16 sensOutput тк там не может быть 2 вещи в одной клетке
        {
            if (Program.mash[(x + mvm[i, 0] + g.maxX) % g.maxX, (y + mvm[i, 1] + g.maxY) % g.maxY, 0] != 0)
            {
                sensOutput[i * g.thingCount - 1 + Program.mash[(x + mvm[i, 0] + g.maxX) % g.maxX, (y + mvm[i, 1] + g.maxY) % g.maxY, 0]] = 1;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Program.mash[(x + mvm[8 + i * 3 + j, 0] + g.maxX) % g.maxX, (y + mvm[8 + i * 3 + j, 1] + g.maxY) % g.maxY, 0] != 0)
                {
                    sensOutput[8 * g.thingCount + i * g.thingCount - 1 + Program.mash[(x + mvm[8 + i * 3 + j, 0] + g.maxX) % g.maxX, (y + mvm[8 + i * 3 + j, 1] + g.maxY) % g.maxY, 0]] = 1;
                }
            }
        }
    }

    int think()
    {
        Array.Clear(probs, 0, probs.Length);
        int result = 0;
        bool temp = false;

        sensor();

        for (int i = 0; i < g.eventsCount; i++)
        {
            for (int j = 0; j < g.thingCount * g.sensorCount; j++)
            {
                probs[i] += dna[i, j] * sensOutput[j];
                if (sensOutput[j] != 0) { temp = true; }
            }
            if (probs[result] < probs[i]) { result = i; }
        }

        if (temp != true) { return -1; }
        else { return result; }
    }

    public void move()
    {
        if (alive == true)
        {
            // ---next iteration preparetion---
            int tmpid = Program.mash[x, y, 1]; int tmpx = x; int tmpy = y;
            Program.mash[x, y, 0] = 0; Program.mash[x, y, 1] = 0;
            hp--;

            // ---dead check---
            if (hp <= 0)
            {
                alive = false;
                save(0);
                countAlive -= 1;
                Program.mash[x, y, 0] = 2; Program.mash[x, y, 1] = 0;
                return;
            }

            switch (think())
            {
                case -1:
                    x = x + rnd.Next(3) - 1;
                    y = y + rnd.Next(3) - 1;
                    //y--;
                    break;
                case 0:
                    y--;
                    break;
                case 1:
                    y++;
                    break;
                case 2:
                    x--;
                    break;
                case 3:
                    x++;
                    break;
                case 4:
                    x--;
                    y--;
                    break;
                case 5:
                    x++;
                    y--;
                    break;
                case 6:
                    x--;
                    y++;
                    break;
                case 7:
                    x++;
                    y++;
                    break;
            }

            // ---invalid position check---
            x = (x + g.maxX) % g.maxX;
            y = (y + g.maxY) % g.maxY;

            switch (Program.mash[x, y, 0])
            {
                case 1:
                    x = tmpx; y = tmpy;
                    break;
                case 2:
                    while (true)
                    {
                        int tmpfx = rnd.Next(g.maxX);
                        int tmpfy = rnd.Next(g.maxY);

                        if (Program.mash[tmpfx, tmpfy, 0] == 0) { Program.mash[tmpfx, tmpfy, 0] = 2; break; }
                    }
                    hp += g.foodEff;
                    break;
            }
            Program.mash[x, y, 0] = 1; Program.mash[x, y, 1] = tmpid;
        }
    }
}