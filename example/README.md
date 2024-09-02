# Creating Items for Minecraft with C#

## 🌟 Prerequisites

Before you begin, make sure you have:
- Basic knowledge of C#
- A development environment set up with .NET
- Texture images for the items you want to add

## 🏗️ Project Structure

To create custom items, you'll need to set up a C# project using the `Addons_Compiler` library. We'll start by creating two example items:
- Cheeseburger
- Sword

## 🛠️ Step 1: Define the Texture

First, define the textures for your items using the `[Texture]` attribute.

```csharp
using Addons;
using Addons.Texture;

namespace Project
{
    public class Program
    {
        // Define texture for the Cheeseburger
        [Texture("./cheese_burger.png", TextureType.Items)]
        public Texture Burger { get; set; } = new Texture("my_burger");

        // Define texture for the Sword
        [Texture("./SwordTexture.png", TextureType.Items)]
        public Texture Sword { get; set; } = new Texture("my_sword");
    }
}
```

## 🌟 Step 2: Create the Items

Now, let's create two items: a sword called "My_Sword" and a cheeseburger.

1. Cheeseburger 🍔

```csharp
Item myBurger = new Item();

myBurger.Property(x =>
{
    x.SetDisplayName($"{MinecraftColor.Yellow}Cheese Burger");
    x.Identifier = "food_burger";
    x.Category = ItemCategory.Items;
    x.SetTexture("burger");
    x.IsFood(x =>
    {
        x.Nutrition = 9;
        x.FoodSaturationModifier = SaturationModifier.Low;
        x.UsingConvertsTo = "minecraft:paper";
    });
});
```

2. Sword 🗡️

```csharp
Item mySword = new Item();

mySword.Property(x =>
{
    x.SetDisplayName("My Sword");
    x.Identifier = "sword:mysword";
    x.Category = ItemCategory.Items;
    x.StackedByData = false;
    x.MaxStackSize = 1;
    x.Damage = 5;
});
```

## 🌟 Step 3: Register the Items

Register the items so that they are recognized by the game.

```csharp
app.Behavior.RegisterItem(myBurger);
app.Behavior.RegisterItem(mySword);
```

## 📝 Complete Code

Here is the complete code for the provided examples:

### Example 1: Food Item

```csharp
using Addons;
using Addons.Texture;

namespace Project
{
    public class Program
    {
        [Texture("./cheese_burger.png", TextureType.Items)]
        public Texture Burger { get; set; } = new Texture("my_burger");

        [Texture("./SwordTexture.png", TextureType.Items)]
        public Texture Sword { get; set; } = new Texture("my_sword");

        static void Main()
        {
            var builder = Addon.CreateBuilder()
                  .SetName("MyAddon")
                  .SetDescription("MyAddon");

            var app = builder.Build();

            Item myBurger = new Item();
            Item mySword = new Item();

            myBurger.Property(x =>
            {
                x.SetDisplayName($"{MinecraftColor.Yellow}Cheese Burger");
                x.Identifier = "food_burger";
                x.Category = ItemCategory.Items;
                x.SetTexture("my_burger");
                x.IsFood(x =>
                {
                    x.Nutrition = 9;
                    x.FoodSaturationModifier = SaturationModifier.Low;
                    x.UsingConvertsTo = "minecraft:paper";
                });
            });

            mySword.Property(x =>
            {
                x.SetDisplayName("My Sword");
                x.Identifier = "sword:mysword";
                x.Category = ItemCategory.Items;
                x.SetTexture("my_sword");
                x.StackedByData = false;
                x.MaxStackSize = 1;
                x.Damage = 5;
            });

            app.Behavior.RegisterItem(myBurger);
            app.Behavior.RegisterItem(mySword);

            app.CreateMcAddonFile();
        }
    }
}
```

## 🚀 Conclusion

With this guide, you have learned how to create custom addons for Minecraft using the `Addons_Compiler` library in C#. Try out the provided examples, adjust as needed, and start creating your own custom addons!

If you need further assistance, refer to the library documentation or reach out to the developer community. Have fun creating your addons!