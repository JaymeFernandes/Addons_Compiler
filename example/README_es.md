# Creando Ítems para Minecraft con C#

## 🌟 Requisitos Previos

Antes de comenzar, asegúrate de tener:
- Conocimientos básicos de C#
- Entorno de desarrollo configurado con .NET
- Imágenes de textura para los ítems que deseas agregar

## 🏗️ Estructura del Proyecto

Para crear ítems personalizados, necesitas configurar un proyecto en C# utilizando la biblioteca `Addons_Compiler`. Comenzaremos creando dos ítems de ejemplo:
- Cheeseburger
- Espada

## 🛠️ Paso 1: Definir la Textura

Primero, define las texturas de los ítems utilizando el atributo `[Texture]`.

```csharp
using Addons;
using Addons.Texture;

namespace Project
{
    public class Program
    {
        // Define la textura para el Cheeseburger
        [Texture("./cheese_burger.png")]
        public Texture Burger { get; set; } = new Texture("my_burger", TextureType.Items);

        // Define la textura para la Espada
        [Texture("./SwordTexture.png")]
        public Texture Sword { get; set; } = new Texture("my_sword", TextureType.Items);
    }
}
```

## 🌟 Paso 2: Crear los Ítems

Ahora, vamos a crear dos ítems: una espada llamada "My_Sword" y un cheeseburger.

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
        x.UsingConvertsTo = Minecraft.Item.Paper;
    });
});
```

2. Espada 🗡️

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

## 🌟 Paso 3: Registrar los Ítems

Registra los ítems para que sean reconocidos por el juego.

```csharp
app.Behavior.AddItem(myBurger);
app.Behavior.AddItem(mySword);
```

## 📝 Código Completo

Aquí tienes el código completo para los ejemplos proporcionados:

### Ejemplo 1: Ítem de Comida

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
                    x.UsingConvertsTo = Minecraft.Item.Paper;
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

            app.Behavior.AddItem(myBurger);
            app.Behavior.AddItem(mySword);

            app.CreateMcAddonFile();
        }
    }
}
```

## 🚀 Conclusión

Con esta guía, has aprendido a crear addons personalizados para Minecraft utilizando la biblioteca `Addons_Compiler` en C#. ¡Prueba los ejemplos proporcionados, ajusta según sea necesario y comienza a crear tus propios addons personalizados!

Si necesitas más ayuda, consulta la documentación de la biblioteca o contacta con la comunidad de desarrolladores. ¡Diviértete creando tus addons!
