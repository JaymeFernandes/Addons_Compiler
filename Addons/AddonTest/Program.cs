using Addons;
using Newtonsoft.Json;

namespace AddonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new Addon.CreateBuilder()
                .BuildLogs(true)
                .SetName("temp")
                .SetDescription("Textura atualizada")
                .AddBehavior()
                .AddResource();

            var app = builder.BuildBase();

            IMinecraftItem item = new Item();

            item.Property(x =>
            {
                x.Identifier = "mink:item";
                x.Category = ItemCategory.Misc;
                x.Name = "item novo minecraft";
                x.SetTexture("chakra");
            });

            app.Behavior.RegisterItem(item);
        }
    }
}
