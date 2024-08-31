 ---
# 🛠️ Addon Compiler

Welcome to **Addon Compiler**! 🎉 This amazing project transforms C# code into addon files for Minecraft, making it easy to create custom items and other exciting content for the game. In this example, we will add a sword to Minecraft using our compiler. Let's get started! 🚀

# Choose Language 🌐

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Addons_Compiler/blob/main/README.md">English</a></td>
    <td><a href="https://github.com/JaymeFernandes/Addons_Compiler/blob/main/README_pt.md">Português</a></td>
    <td><a href="https://github.com/JaymeFernandes/Addons_Compiler/blob/main/README_es.md">Español</a></td>
  </tr>
</table>

## 📋 Table of Contents

- [Introduction](#introduction-)
- [Installation](#installation-)
- [Usage](#usage-)
- [Code Example Base](#code-example-)
- [Creating Items](./example/README.md)
- [Contribution](#contribution-)
- [License](#license-)

## Introduction 🌟

**Addon Compiler** is a powerful tool that allows developers to write addons for Minecraft in C# and compile them into addon files. With this tool, you can easily define textures, items, and other game functionalities using a familiar and efficient syntax.

## Installation 📦

1. Clone this repository:
   ```sh
   git clone https://github.com/your-username/addon-compiler.git
   ```

2. Navigate to the project directory:
   ```sh
   cd Addons_Compiler
   ```

3. Restore the necessary packages:
   ```sh
   dotnet restore
   ```

4. Build the project:
   ```sh
   dotnet build
   ```

## Usage 🚀

To use **Addon Compiler**, follow the steps below to create a basic addon that adds a sword to Minecraft.

## Code Example 💻

Here is an example of how to create an addon that adds a custom sword to the game:

```csharp
using Addons;
using Addons.Texture;

namespace Project
{
    public class Program
    {
        // Create the texture
        // [Texture(Directory, Texture type)]
        [Texture("./SwordTexture.png", TextureType.Items)]
        public Texture Sword { get; set; } = new Texture("iron_sword"); // Texture name

        static void Main()
        {
            var builder = new Addon.Builder()
                .SetName("MyAddon")
                .SetDescription("Custom addon");

            var app = builder.Base();

            app.CreateMcAddonFile();
        }
    }
}
```

### Steps to Run the Example 📜

1. Replace the texture path (`"./SwordTexture.png"`) with the path to your texture image.
2. Run the program:
   ```sh
   dotnet run
   ```
3. The `.mcaddon` file will be generated in the project directory. Just import it into Minecraft and enjoy your new sword! ⚔️

## Contribution 🤝

Contributions are welcome! Feel free to open issues and pull requests. Let's make this project even better together! 💪

## License 📄

This project is licensed under the [MIT License](LICENSE).

---

Have fun creating amazing addons with **Addon Compiler**! 🎮✨

