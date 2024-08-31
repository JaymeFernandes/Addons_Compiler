namespace Addons
{
    public interface IAddonBuilder
    {
        Addon Build();

        IAddonBuilder SetName(string name);

        IAddonBuilder SetDescription(string description);

        IAddonBuilder SetVersion(string version);

        IAddonBuilder SetVersion(List<int> version);

        IAddonBuilder SetMinVersion(string version);
    }
}
