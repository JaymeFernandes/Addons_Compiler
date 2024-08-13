using Addons;
using Addons.Scripts.Model;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace Addons.Scripts;



public static class Extensions_AddScript
{
    private static List<string> MethodsIgnore = new List<string> { "GetType", "ToString", "Equals", "GetHashCode" };

    /// <summary>
    /// In Development
    /// </summary>
    public static void AddScripts<ClassScript>(this Addon app) where ClassScript : class
    {
        var type = typeof(ClassScript);

        if(!type.IsClass) throw new ArgumentException($"{nameof(ClassScript)} is invalid");
        if(!type.IsSubclassOf(typeof(ModelScript))) throw new ArgumentException("The passed class does not have ModelScript inheritance");

        string src = "";

        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

        foreach(var method in methods)
        {
            if(!MethodsIgnore.Contains(method.Name))
            {
                ParameterInfo[] parameters = method.GetParameters();
                src += $"funtion {method.Name}() ";
                src += "{" + $"" + "}\n\n";
            }
        }

        Console.Clear();
        Console.WriteLine(src);
    }
}
