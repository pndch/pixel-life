using pixellife;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Raylib_cs.Raylib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.Threading;


public static class a
{
    public static bool Aflag = true;
    public static bool Gflag = false;

    public static int avgLifetime100 = 0;
    public static int avgLifetime25 = 0;
    public static int timer = 0;
    public static int record = 0;
    public static int iteration = 0;

    static Queue<int> timerStack = new Queue<int>(101);
    static int avgCounter = 0;

    public static void end()
    {
        if (Gflag == true)
        {
            Console.WriteLine("\n\ngenome of last bot: \n");
            for (int i = 0; i < g.eventsCount; i++)
            {
                for (int j = 0; j < g.thingCount * g.sensorCount; j++)
                {
                    Console.Write($"{Bot.savedDna[0, i, j]:F2} ");
                }
                Console.WriteLine();
            }
        }

        if (iteration > 2 && record < timer) { record = timer; }
        avgTimer();

        timer = 0;
        iteration++;
    }

    static void avgTimer()
    {
        int tempStack = 0;
        int tempStack25 = 0;
        int tempCounter = 0;
        int counter = 0;

        timerStack.Enqueue( timer );
        while ( timerStack.Count > 100 ) { timerStack.Dequeue(); }

        foreach (int i in timerStack)
        {
            counter++;
            tempStack += i;
            if (counter > timerStack.Count-25 || timerStack.Count<25) { tempStack25 += i; tempCounter++; }
        }
        avgLifetime25 = tempStack25 / tempCounter;
        avgLifetime100 = tempStack / timerStack.Count;
    }
}