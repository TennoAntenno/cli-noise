using System.Text.Json;

public class Config
{
    public string title { get; set; } = "";
    public string color { get; set; } = "";
    public int update_interval { get; set; }
    public float z_offset { get; set; }
    public float scale { get; set; }
    public char max_symbol { get; set; }
    public char mid_symbol { get; set; }
    public char partial_symbol { get; set; }
    public char min_symbol { get; set; }
    public char empty_symbol { get; set; }
    public float max_threshold { get; set; }
    public float mid_threshold { get; set; }
    public float partial_threshold { get; set; }
    public float min_threshold { get; set; }
}