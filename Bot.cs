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
    public static int[,] xy = new int[g.botCount, 2];
    public static int[,] dnaBuf = new int[g.botTransferCount, g.dnaSize];

    public int age = 0;
    public double hp = g.startHP;
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
        dna = new int[g.dnaSize];

        for (int i = 0; i < g.dnaSize; i++)
        {
            dna[i] = rnd.Next(g.commandsCount) + 1;
        }

        x = rnd.Next(g.height / g.size);
        y = rnd.Next(g.height / g.size);
    }

    public static void initBots(int x)
    {
        countAlive = 0;
        countAll = 0;

        if (x == 0)
        {
            for (int i = 0; i < g.botCount; i++)
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

        else if (x == 1)
        {
            for (int i = 0; i < g.botTransferCount; i++)
            {
                countAll += 1;
                countAlive += 1;

                while (true)
                {
                    bots[i] = new Bot();
                    if (Program.mash[bots[i].x, bots[i].y, 0] == 0) { Program.mash[bots[i].x, bots[i].y, 0] = 1; Program.mash[bots[i].x, bots[i].y, 1] = i; break; }
                }

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
                countAll += 1;
                countAlive += 1;
                bots[i] = new Bot();
            }
        }
        else if (x == 2)
        {
            for (int i = 0; i < g.botCount; i++)
            {
                countAll += 1;
                countAlive += 1;

                while (true)
                {
                    bots[i] = new Bot();
                    if (Program.mash[bots[i].x, bots[i].y, 0] == 0) { Program.mash[bots[i].x, bots[i].y, 0] = 1; Program.mash[bots[i].x, bots[i].y, 1] = i; break; }
                }

                for (int j = 0; j < g.dnaSize; j++)
                {
                    if (rnd.Next(g.mutationFactor) == 1) { bots[i].dna[j] = rnd.Next(g.commandsCount) + 1; }
                    else { bots[i].dna[j] = Bot.dnaBuf[0, j]; }
                }
            }
        }
        else if (x == 3)
        {
            for (int i = 0; i < g.botCount; i++)
            {
                countAll += 1;
                countAlive += 1;

                while (true)
                {
                    bots[i] = new Bot();
                    if (Program.mash[bots[i].x, bots[i].y, 0] == 0) { Program.mash[bots[i].x, bots[i].y, 0] = 1; Program.mash[bots[i].x, bots[i].y, 1] = i; break; }
                }

                for (int j = 0; j < g.dnaSize; j++)
                {
                    int tempG = rnd.Next(2); 
                    if (dnaBuf[tempG, j] > 8 && dnaBuf[tempG, j] < 17)
                    {
                            
                        for (int t = 0; t<3; t++)
                        {
                            bots[i].dna[j] = dnaBuf[tempG, j];
                            if (j == g.dnaSize - 1) { break; } else { j++; }
                        }
                    }
                    else { bots[i].dna[j] = dnaBuf[tempG, j]; }

                    if (rnd.Next(g.mutationFactor) == 1) { bots[i].dna[j] = rnd.Next(g.commandsCount) + 1; }
                }
            }
        }
    }

    public void dupe()
    {
        if ((hp >= g.dupeHP * 2) && (countAll < g.maximumBotCount))
        {
            hp -= g.dupeHP;
            bots[countAll] = new Bot();

            countAll += 1;
            countAlive += 1;

            bots[countAll - 1].generation = generation + 1;
            bots[countAll - 1].hp = g.dupeHP / 5 * 3;


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

            // ---invalid position check---
            if (bots[countAll - 1].x > g.width / g.size - 1) { bots[countAll - 1].x = g.width / g.size - 1; }
            if (bots[countAll - 1].y > g.height / g.size - 1) { bots[countAll - 1].y = g.height / g.size - 1; }
            if (bots[countAll - 1].x < 0) { bots[countAll - 1].x = 0; }
            if (bots[countAll - 1].y < 0) { bots[countAll - 1].y = 0; }

            int tmp = 0;
            while (tmp < 8)
            {
                if (Program.mash[bots[countAll - 1].x, bots[countAll - 1].y, 0] != 1) { break; }
                else
                {
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

                    if (bots[countAll - 1].x > g.width / g.size - 1) { bots[countAll - 1].x = g.width / g.size - 1; }
                    if (bots[countAll - 1].y > g.height / g.size - 1) { bots[countAll - 1].y = g.height / g.size - 1; }
                    if (bots[countAll - 1].x < 0) { bots[countAll - 1].x = 0; }
                    if (bots[countAll - 1].y < 0) { bots[countAll - 1].y = 0; }
                }
                tmp++;
            }

            // если не получится найти место рядом с родителем просто удалим ребенка
            if (tmp >= 7)
            {
                countAll -= 1;
                countAlive -= 1;
                hp += g.dupeHP;
                return;
            }

            if (Program.mash[bots[countAll - 1].x, bots[countAll - 1].y, 0] == 2)
            {
                bots[countAll - 1].hp += 30;
            }

            Program.mash[bots[countAll - 1].x, bots[countAll - 1].y, 0] = 1; Program.mash[bots[countAll - 1].x, bots[countAll - 1].y, 1] = countAll - 1;

            for (int j = 0; j < g.dnaSize; j++)
            {
                if (rnd.Next(g.mutationFactor) == 1)
                {
                    bots[countAll - 1].dna[j] = rnd.Next(g.commandsCount) + 1;
                }
                else
                {
                    bots[countAll - 1].dna[j] = dna[j];
                }
            }
        }
        else { doDna(); }
    }

    public void move(int xx, int yy)
    {
        int tmpid = Program.mash[x, y, 1]; int tmpx = x; int tmpy = y;
        Program.mash[x, y, 0] = 0; Program.mash[x, y, 1] = 0;

        switch (rotation) // 0-up 1-right 2-down 3-left
        {
            case 0:
                x = x + xx;
                y = y + yy;
                break;
            case 1:
                x = x - yy;
                y = y + xx;
                break;
            case 2:
                x = x - xx;
                y = y - yy;
                break;
            case 3:
                x = x + yy;
                y = y - xx;
                break;
        }

        // ---invalid position check---
        if (x > g.width / g.size - 1) { x = g.width / g.size - 1; }
        if (y > g.height / g.size - 1) { y = g.height / g.size - 1; }
        if (x < 0) { x = 0; }
        if (y < 0) { y = 0; }

        switch (Program.mash[x, y, 0])
        {
            case 1:
                x = tmpx; y = tmpy;
                break;
            case 2:
                hp += g.foodEff;
                break;
        }

        Program.mash[x, y, 0] = 1; Program.mash[x, y, 1] = tmpid;
    }

    public void check(int xx, int yy)
    {
        int tx = 0, ty = 0;

        hp += 0.75;

        switch (rotation) // 0-up 1-right 2-down 3-left
        {
            case 0:
                tx = x + xx;
                ty = y + yy;
                break;
            case 1:
                tx = x - yy;
                ty = y + xx;
                break;
            case 2:
                tx = x - xx;
                ty = y - yy;
                break;
            case 3:
                tx = x + yy;
                ty = y - xx;
                break;
        }

        if (tx >= 0 && ty >= 0 && tx < g.width / g.size && ty < g.height / g.size)

        {
            switch (Program.mash[tx, ty, 0]) 
            {
                case 0:
                    nextDna = (nextDna + 1) % g.dnaSize;
                    doDna();
                    nextDna = (nextDna + 2) % g.dnaSize;
                    break;
                case 1:
                    nextDna = (nextDna + 2) % g.dnaSize;
                    doDna();
                    nextDna = (nextDna + 1) % g.dnaSize;
                    break;
                case 2:
                    nextDna = (nextDna + 3) % g.dnaSize;
                    doDna();
                    nextDna = (nextDna + 0) % g.dnaSize;
                    break;
            }
        }
    }

    public void doDna()
    {
        if (alive == true)
        {
            // ---next iteration preparetion---
            age++; hp--;

            // ---dead check---
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
            }

            // ---dna command---
            switch (dna[nextDna])
            {
                //move
                case 1: move(0, -1); break; //up
                case 2: move(0, 1); break; //down
                case 3: move(-1, 0); break; //left
                case 4: move(1, 0); break; //right
                case 5: move(-1, -1); break; //upleft
                case 6: move(1, -1); break; //upright
                case 7: move(-1, 1); break; //downleft
                case 8: move(1, 1); break; //downright

                //check
                case 9: check(0, -1); break; //up
                case 10: check(0, 1); break; //down
                case 11: check(-1, 0); break; //left
                case 12: check(1, 0); break; //right
                case 13: check(-1, -1); break; //upleft
                case 14: check(1, -1); break; //upright
                case 15: check(-1, 1); break; //downleft
                case 16: check(1, 1); break; //downright

                case 17: //90
                    rotation += 1;
                    while (rotation > 3) { rotation -= 4; }
                    if (nextDna == g.dnaSize - 1) { nextDna = 0; } else { nextDna++; }
                    doDna(); break;
                case 18: //180
                    rotation += 2;
                    while (rotation > 3) { rotation -= 4; }
                    if (nextDna == g.dnaSize - 1) { nextDna = 0; } else { nextDna++; }
                    doDna(); break;
                case 19: //270
                    rotation += 3;
                    while (rotation > 3) { rotation -= 4; }
                    if (nextDna == g.dnaSize - 1) { nextDna = 0; } else { nextDna++; }
                    doDna(); break;
                case 20: hp += g.photosyntesisEff; break; //photosythesis
                case 21: dupe(); break; //dupe
            }

            if (nextDna == g.dnaSize - 1) { nextDna = 0; } else { nextDna++; } //dna switch
        }
    }
}