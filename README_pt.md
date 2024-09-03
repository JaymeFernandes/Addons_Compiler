 ---
# 🛠️ Addon Compiler

Bem-vindo ao **Addon Compiler**! 🎉 Este projeto incrível transforma código C# em arquivos de addon para Minecraft, facilitando a criação de itens personalizados e outros conteúdos incríveis para o jogo. Neste exemplo, vamos adicionar uma espada ao Minecraft usando nosso compilador. Vamos começar! 🚀

# Escolha o Idioma 🌐

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Addons_Compiler/blob/main/README.md">English</a></td>
    <td><a href="https://github.com/JaymeFernandes/Addons_Compiler/blob/main/README_pt.md">Português</a></td>
    <td><a href="https://github.com/JaymeFernandes/Addons_Compiler/blob/main/README_es.md">Español</a></td>
  </tr>
</table>

## 📋 Índice

- [Introdução](#introdução-)
- [Instalação](#instalação-)
- [Uso](#uso-)
- [Exemplo de Código Base](#exemplo-de-código-)
- [Criando Itens](./example//README_pt.MD)
- [Contribuição](#contribuição-)
- [Licença](#licença-)

## Introdução 🌟

O **Addon Compiler** é uma ferramenta poderosa que permite a desenvolvedores escreverem addons para Minecraft em C# e compilá-los em arquivos de addon. Com essa ferramenta, você pode facilmente definir texturas, itens, e outras funcionalidades do jogo usando uma sintaxe familiar e eficiente.

## Instalação 📦

1. Clone este repositório:
   ```sh
   git clone https://github.com/seu-usuario/addon-compiler.git
   ```

2. Navegue até o diretório do projeto:
   ```sh
   cd Addons_Compiler
   ```

3. Restaure os pacotes necessários:
   ```sh
   dotnet restore
   ```

4. Compile o projeto:
   ```sh
   dotnet build
   ```

## Uso 🚀

Para usar o **Addon Compiler**, siga as etapas abaixo para criar um addon básico que adiciona uma espada ao Minecraft.

## Exemplo de Código 💻

Aqui está um exemplo de como criar a Base da addon:

```csharp
using Addons;
using Addons.Texture;

namespace Project
{
    public class Program
    {
        static void Main()
        {
            var builder = Addon.CreateBuilder()
                  .SetName("MyAddon")
                  .SetDescription("MyAddon");

            var app = builder.Build();

            app.CreateMcAddonFile();
        }
    }
}
```

### Passos para rodar o exemplo 📜

1. Substitua o caminho da textura (`"./SwordTexture.png"`) pelo caminho da sua imagem de textura.
2. Execute o programa:
   ```sh
   dotnet run
   ```
3. O arquivo `.mcaddon` será gerado no diretório do projeto. Basta importá-lo no Minecraft e curtir sua nova espada! ⚔️

## Contribuição 🤝

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests. Vamos tornar este projeto ainda melhor juntos! 💪

## Licença 📄

Este projeto está licenciado sob a [MIT License](LICENSE).

---

Divirta-se criando addons incríveis com o **Addon Compiler**! 🎮✨


---

propriedades em desenvolviento:
