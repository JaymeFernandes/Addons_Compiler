using Addons.Model;

namespace Addons
{
	internal class BehaviorPackController : IBehaviorPack
	{
		public AddonManifest Manifest { get; set; } = new AddonManifest();

		/// <summary>
		/// Initializes a new instance of the <see cref="BehaviorPack"/> class.
		/// </summary>
		public BehaviorPackController(string name, string description) 
		{
			BehaviorPackManager.SerName(name);
			Manifest = new AddonManifest(name, description);
			Manifest.Modules.Add(new AddonModules(AddonType.Data, description));
		}



		public void AddItem(Item item) 
		{
			if(item._Model == null) throw new ArgumentNullException(nameof(item));
			if(item._Model.Identifier == null) throw new ArgumentNullException(nameof(item));

			BehaviorPackManager.CreateItem(item.ToString(), item._Model.Identifier.Replace(":", "_") ?? throw new ArgumentNullException(nameof(item)));
		}
		
		public void AddItems(ICollection<Item> items) => items.ToList().ForEach(item => AddItem(item));

		public void MapItem(Action<IMinecraftItem> options)
		{
			var item = new Item(options);

			if(item._Model.Identifier == null) throw new ArgumentNullException(nameof(item));

			AddItem(item);
		}


	}
}
