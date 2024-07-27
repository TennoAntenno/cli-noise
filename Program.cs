class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        SimplexNoise.Noise.Seed = rand.Next(0,999999);

        int z = 0;
        while (! Console.KeyAvailable)
        {
            z++;
            Thread.Sleep(100);
            int width = Console.WindowWidth/2;
            int height = Console.WindowHeight;
            string result = "";
            for (int y = 0; y < height; y++)
            {
                result += "\n";
                for (int x = 0; x < width; x++)
                {
                    float noise = SimplexNoise.Noise.CalcPixel3D(x,y,z,0.1f);
                    switch (noise)
                    {
                        case < 100:
                            result += "██";
                            break;
                        case < 110:
                            result += "▓▓";
                            break;
                        case < 120:
                            result += "▒▒";
                            break;
                        case < 130:
                            result += "░░";
                            break;
                        default:
                            result += "  ";
                            break;
                    }
                }
            }
            Console.Clear();
            Console.Write(result);
        }
        Console.Clear();
    }
}