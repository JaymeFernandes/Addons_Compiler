namespace Addons
{
    public partial class Addon : IAddon
    {
        public void CreateMcAddonFile()
        {
            McAddonManager.CreateMcAddonFile();
            
            Console.Clear();
            ColorConsole.WriteLine("All addon files were created successfully:", ConsoleColor.Green);
            ColorConsole.WriteLine(Path.Combine(AppContext.BaseDirectory, $"com.mojang/{Name}.mcaddon"), ConsoleColor.Blue);

            ColorConsole.WriteLine("\n\nCustom Minecraft Bedrock Addon\n", ConsoleColor.Blue);
            Console.WriteLine("This addon was generated using the Custom Addon Compiler for Minecraft Bedrock Edition.\n");

            ColorConsole.WriteLine("About\n", ConsoleColor.Blue);
            Console.WriteLine("This addon includes custom items, blocks, and behaviors designed to enhance your Minecraft experience. It was automatically compiled from C# code using our Custom Addon Compiler.\n");

            ColorConsole.WriteLine("Repository\n", ConsoleColor.Blue);
            Console.WriteLine("For more information, updates, and to contribute, please visit the GitHub repository:\n");

            ColorConsole.WriteLine("[GitHub Repository]", ConsoleColor.Green);
            ColorConsole.WriteLine("(https://github.com/JaymeFernandes/Addons_Compiler)\n", ConsoleColor.Blue);
            ColorConsole.WriteLine("Happy crafting!\n\n", ConsoleColor.Yellow);
        }



        public IBehaviorPack Behavior { get; set; }
        public IResourcePack Resource { get; set; }
        public string Name { get; private set; } = "";
        public string Description { get; private set; } = "";
        public List<int> Version { get; private set; } = new List<int> { 3, 0, 0 };
        public List<int> MinVersion { get; private set; } = new List<int> { 1, 8, 0 };
    }

    public static class ColorConsole{
        public static void WriteLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
