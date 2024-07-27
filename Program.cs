using System.Text.Json;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        SimplexNoise.Noise.Seed = rand.Next(0,999999);

        // Load config and deserialize from JSON
        string configFile = File.ReadAllText("CONFIG.cfg");
        // Remove comments from config before deserializing
        configFile = Regex.Replace(configFile, @"^\s*#.*$", string.Empty, RegexOptions.Multiline);
        Config config = JsonSerializer.Deserialize<Config>(configFile)
            ?? throw new InvalidOperationException("Config file could not be deserialized.");

        // Set properties based on config
        Console.Title = config.title;

        // Color of the text
        switch (config.color)
        {
            case "White":
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case "Black":
                Console.ForegroundColor = ConsoleColor.Black;
                break;
            case "Blue":
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case "Cyan":
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case "Gray":
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
            case "Green":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case "Magenta":
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            case "Red":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case "Yellow":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "DarkBlue":
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                break;
            case "DarkCyan":
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                break;
            case "DarkGray":
                Console.ForegroundColor = ConsoleColor.DarkGray;
                break;
            case "DarkGreen":
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
            case "DarkMagenta":
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;
            case "DarkRed":
                Console.ForegroundColor = ConsoleColor.DarkRed;
                break;
            case "DarkYellow":
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }

        int updateInterval = config.update_interval;
        int zOffset = Convert.ToInt32(config.z_offset);
        float scale = config.scale;

        char max_symbol = config.max_symbol;
        char mid_symbol = config.mid_symbol;
        char partial_symbol = config.partial_symbol;
        char min_symbol = config.min_symbol;
        char empty_symbol = config.empty_symbol;

        float max_threshold = config.max_threshold;
        float mid_threshold = config.mid_threshold;
        float partial_threshold = config.partial_threshold;
        float min_threshold = config.min_threshold;

        int z = 0;
        while (! Console.KeyAvailable)
        {
            z += zOffset;
            Thread.Sleep(updateInterval);
            int width = Console.WindowWidth/2;
            int height = Console.WindowHeight;
            string result = "";
            for (int y = 0; y < height; y++)
            {
                result += "\n";
                for (int x = 0; x < width; x++)
                {
                    float noise = SimplexNoise.Noise.CalcPixel3D(x,y,z,scale);
                    switch (noise)
                    {
                        case float value when value < max_threshold: 
                            result += max_symbol;
                            result += max_symbol;
                            break;
                        case float value when value < mid_threshold:
                            result += mid_symbol;
                            result += mid_symbol;
                            break;
                        case float value when value < partial_threshold:
                            result += partial_symbol;
                            result += partial_symbol;
                            break;
                        case float value when value < min_threshold:
                            result += min_symbol;
                            result += min_symbol;
                            break;
                        default:
                            result += empty_symbol;
                            result += empty_symbol;
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