using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;

public static class g // settings
{
    // ----- console -----
    public const string negative = "\u001b[31m"; //color
    public const string positive = "\u001b[32m"; //color
    public const string reset = "\u001b[0m";

    // ----- window -----
    public const int height = 640;
    public const int width = 640;
    public const byte size = 8;
    public const int maxTimer = 50000;
    public const int speed = 16; //0-no limit

    // ----- simulation -----
    public const int foodCount = 300;
    public const int foodEff = 200;
    public const int startHP = 80;
    public const int dupeHP = 100;

    public const int botCount = 8;
    public const int maximumBotCount = 1024;
    public const int botTransferCount = 4;

    // ----- dna -----
    public const int photosyntesisEff = 1;
    public const int dnaSize = 64; // 2^x req
    public const int commandsCount = 32; //9 real
    public const int mutationFactor = 8; // 1 == no mutation // 3 == 1/3 of genom randomized 

    // ----- probably temp -----
    public const int strategyOfNextGeneration = 3; //1 - botTransferCount >> NextGeneration // 2 - BestBot >> NextGeneration
}
