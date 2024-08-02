 ---
# 🛠️ Compilador de Addons

¡Bienvenido al **Compilador de Addons**! 🎉 Este increíble proyecto transforma código C# en archivos de addon para Minecraft, facilitando la creación de objetos personalizados y otros contenidos emocionantes para el juego. En este ejemplo, agregaremos una espada a Minecraft usando nuestro compilador. ¡Vamos a empezar! 🚀


# Selector de Idioma 🌐

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Addons_Compiler/blob/main/README.md">English</a></td>
    <td><a href="https://github.com/JaymeFernandes/Addons_Compiler/blob/main/README_pt.md">Português</a></td>
    <td><a href="https://github.com/JaymeFernandes/Addons_Compiler/blob/main/README_es.md">Español</a></td>
  </tr>
</table>

## 📋 Tabla de Contenidos

- [Introducción](#introducción-)
- [Instalación](#instalación-)
- [Uso](#uso-)
- [Ejemplo de Código Base](#ejemplo-de-código-)
- [Creando Ítems](./example/README_es.md)
- [Contribución](#contribución-)
- [Licencia](#licencia-)

## Introducción 🌟

El **Compilador de Addons** es una herramienta poderosa que permite a los desarrolladores escribir addons para Minecraft en C# y compilarlos en archivos de addon. Con esta herramienta, puedes definir fácilmente texturas, objetos y otras funcionalidades del juego utilizando una sintaxis familiar y eficiente.

## Instalación 📦

1. Clona este repositorio:
   ```sh
   git clone https://github.com/tu-usuario/addon-compiler.git
   ```

2. Navega hasta el directorio del proyecto:
   ```sh
   cd Addons_Compiler
   ```

3. Restaura los paquetes necesarios:
   ```sh
   dotnet restore
   ```

4. Compila el proyecto:
   ```sh
   dotnet build
   ```

## Uso 🚀

Para usar el **Compilador de Addons**, sigue los pasos a continuación para crear un addon básico que agregue una espada a Minecraft.

## Ejemplo de Código 💻

Aquí tienes un ejemplo de cómo crear un addon que agrega una espada personalizada al juego:

```csharp
using Addons;
using Addons.Texture;

namespace Project
{
    public class Program
    {
        // Crea la textura
        // [Texture(Directorio, Tipo de Texture)]
        [Texture("./SwordTexture.png", TextureType.Items)]
        public Texture Sword { get; set; } = new Texture("iron_sword"); // Nombre de la textura

        static void Main()
        {
            var builder = new Addon.Builder()
                .SetName("MyAddon")
                .SetDescription("Custom addon")
                .AddBehavior() // Paquete de comportamiento
                .AddResource(); // Paquete de texturas

            var app = builder.Base();

            app.Behavior.RegisterItem(item);

            app.CreateMcAddonFile();
        }
    }
}
```

### Pasos para Ejecutar el Ejemplo 📜

1. Reemplaza la ruta de la textura (`"./SwordTexture.png"`) con la ruta de tu imagen de textura.
2. Ejecuta el programa:
   ```sh
   dotnet run
   ```
3. El archivo `.mcaddon` se generará en el directorio del proyecto. Solo tienes que importarlo en Minecraft y disfrutar de tu nueva espada. ⚔️

## Contribución 🤝

¡Las contribuciones son bienvenidas! No dudes en abrir issues y pull requests. ¡Hagamos este proyecto aún mejor juntos! 💪

## Licencia 📄

Este proyecto está licenciado bajo la [Licencia MIT](LICENSE).

---

¡Diviértete creando addons increíbles con el **Compilador de Addons**! 🎮✨