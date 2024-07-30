using Addons;
using Addons.Model;

namespace AddonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new Addon.CreateBuilder()
                .BuildLogs(false)
                .SetName("temp")
                .SetDescription("Textura atualizada")
                .AddBehavior()
                .AddResource();

            var app = builder.BuildBase();

            IMinecraftItem item = new Item();

            item.Property(x =>
            {
                x.Identifier = "sword:dragon";
                x.Category = ItemCategory.Items;
                x.Name = "text1";
                x.SetTexture("sword_dragon");
                x.SetDisplayName($"[  {MinecraftTextColor.Red}Matadora de Dragões{MinecraftTextFormatting.reset} ]");
                x.Damage = 1000;
            });

            app.Behavior.RegisterItem(item);
        }
    }
}
