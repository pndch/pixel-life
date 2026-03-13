public static class g // settings
{
    // ----- console -----
    public const string negative = "\u001b[31m"; //color
    public const string positive = "\u001b[32m"; //color
    public const string reset = "\u001b[0m";

    // ----- window -----
    public const int height = 640;
    public const int width = 640;
    public const byte size = 4;
    public static int speed = 0; //0-no limit
    public static bool FPSflag = true;
    public static bool Sflag = false; //stop flag
    public static bool Pflag = true; //pause flag
    public static bool Dflag = true; // draw flag
    public const int maxX = width / size;
    public const int maxY = height / size;

    // ----- simulation -----
    public static int foodCount = 200;
    public static int foodEff = 70;
    public static int startHP = 80;
    //public const int dupeHP = 50;

    public static int botCount = 64;
    public static int maximumBotCount = 1024;
    public const int botTransferCount = 4;

    // ----- dna -----
    public const int sensorCount = 12;
    public const int thingCount = 2;
    public const int eventsCount = 8;

    public static double mutationStep = 0.07;
    public static int mutationFactor = 64; // 1 == no mutation // 3 == 1/3 of genom randomized 

    // ----- probably temp -----
    public const int strategyOfNextGeneration = 1; //1 - botTransferCount >> NextGeneration // 2 - BestBot >> NextGeneration
}
