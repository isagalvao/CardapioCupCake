# Cardápio CupCake

Projeto .NET MAUI para exibição e gerenciamento de um cardápio de cupcakes — app multiplataforma (Android / iOS / Windows).

Descrição curta
--------------
Aplicativo de exemplo para cadastrar, visualizar detalhes e adicionar cupcakes ao carrinho. Código organizado em MVVM com modelos, serviços e ViewModels prontos para evolução.

Screenshots (espaço reservado)
------------------------------
![Tela Login](assets/screenshots/home.png)  
*Tela inicial / Login do usuário*

![Tela de Cadastro](assets/screenshots/home.png)  
*Tela Cadastro / Cadastro incial*

![Tela Inicial](assets/screenshots/home.png)  
*Tela inicial / lista de cupcakes*

![Detalhes do Cupcake](assets/screenshots/detail.png)  
*Detalhes do produto*

![Carrinho](assets/screenshots/cart.png)  
*Carrinho de compras*

![Perfil](assets/screenshots/cart.png)  
*Perfil usuário*


Principais funcionalidades
-------------------------
- Cadastro do usuario
- Login
- Listagem de cupcakes 
- Adição de itens ao carrinho
- Páginas de detalhe e perfil
- Estrutura MVVM compatível com .NET MAUI

Requisitos
----------
- __Visual Studio 2022__ com workload de __.NET MAUI__
- .NET 9 SDK instalado
- Emuladores ou dispositivo físico para a plataforma alvo

Instalação e execução
---------------------
1. Clone o repositório:
   git clone <url-do-repositorio>

2. Abra a solução no __Visual Studio 2022__:
   - Abra o arquivo .sln
   - Selecione a plataforma alvo (Android / iOS / Windows) na __Solution Configuration__ / __Solution Platforms__
   - Use __Rebuild Solution__ se desejar limpar o build anterior

3. Execute:
   - Clique em __Start__ ou use __Debug > Start Debugging__ para executar no emulador/dispositivo selecionado.

Rodando via CLI (alternativa)
-----------------------------
- Restaurar pacotes:
  dotnet restore

- Build:
  dotnet build

- Executar (exemplo Android):
  dotnet build -f net9.0-android
  (ou use as diretivas específicas do projeto / IDE conforme necessário)

Estrutura do projeto
--------------------
- CardapioCupCake.Core.Models — modelos (ex.: CupcakeModel)
- CardapioCupCake.Core.Service — serviços e repositórios (ex.: ListCupCakeRepository)
- CardapioCupCake.Core.ViewModel — ViewModels para cada View
- CardapioCupCake.Core.View — páginas XAML (.xaml / .xaml.cs)
- Resources / Styles — cores e estilos compartilhados

## 🤝 Colaboradores

<table>
  <tr>
    <td align="center">
      <a href="#">
        <img src="https://avatars.githubusercontent.com/u/102769431?v=4" width="100px;" alt="Foto da Isabelle Galvão no GitHub"/><br>
        <sub>
          <b>Isabelle Galvão</b>
        </sub>
      </a>
    </td>
  </tr>
</table>
