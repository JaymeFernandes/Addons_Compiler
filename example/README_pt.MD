# Criando Itens para Minecraft com C#

## 🌟 Pré-requisitos

Antes de começar, certifique-se de ter:
- Conhecimento básico de C#
- Ambiente de desenvolvimento configurado com .NET
- Imagens de textura para os itens que deseja adicionar

## 🏗️ Estrutura do Projeto

Para criar itens personalizados, você precisará configurar um projeto C# utilizando a biblioteca `Addons_Compiler`. A seguir, vamos criar dois itens exemplo:
- Cheeseburger
- Espada

## 🛠️ Passo 1: Definir a Textura

Primeiro, defina as texturas dos itens utilizando o atributo `[Texture]`.

```csharp
using Addons;
using Addons.Texture;

namespace Project
{
    public class Program
    {
        // Define a textura para o Cheeseburger
        [Texture("./cheese_burger.png")]
        public Texture Burger { get; set; } = new Texture("my_burger", TextureType.Items);

        // Define a textura para a Espada
        [Texture("./SwordTexture.png")]
        public Texture Sword { get; set; } = new Texture("my_sword", TextureType.Items);
    }
}
```

## 🌟 Passo 2: Criar os Itens

Agora, vamos criar dois itens: uma espada chamada "My_Sword" e um Cheeseburger.

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

## 🌟 Passo 3: Registrar os Itens

Registre os itens para que eles sejam reconhecidos pelo jogo.

```csharp
app.Behavior.AddItem(myBurger);
app.Behavior.AddItem(mySword);
```

## 📝 Código Completo

Aqui está o código completo dos exemplos fornecidos:

### Exemplo 1: Item de Comida

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

## 🚀 Conclusão

Com este guia, você aprendeu a criar addons personalizados para Minecraft utilizando a biblioteca `Addons_Compiler` em C#. Experimente os exemplos fornecidos, faça ajustes conforme necessário e comece a criar seus próprios addons! 

Se precisar de mais ajuda, consulte a documentação da biblioteca ou entre em contato com a comunidade de desenvolvedores. Divirta-se criando seus addons!

---