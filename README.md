# 🧁 Cardápio CupCake

Projeto .NET MAUI para exibição e gerenciamento de um cardápio de cupcakes — app multiplataforma (Android / iOS).

## ✨ Descrição curta
Aplicativo para cadastrar usuários, visualizar cupcakes, conferir detalhes e adicionar ao carrinho.  
Organizado com arquitetura **MVVM**, perfeito para evolução.

---

## 📸 Screenshots 

### Tela de Login
![Tela Login](assets/screenshots/home.png)

### Tela de Cadastro
![Tela de Cadastro](assets/screenshots/home.png)

### Tela Inicial / Lista de Cupcakes
![Tela Inicial](assets/screenshots/home.png)

### Detalhes do Cupcake
![Detalhes](assets/screenshots/detail.png)

### Carrinho
![Carrinho](assets/screenshots/cart.png)

### Perfil
![Perfil](assets/screenshots/cart.png)

---

## 🍰 Principais funcionalidades
- Cadastro do usuário  
- Login  
- Listagem de cupcakes  
- Adição de itens ao carrinho  
- Página de detalhes  
- Página de perfil  
- Estrutura MVVM com .NET MAUI  

---

## 🛠️ Requisitos
- Visual Studio 2022 com workload de **.NET MAUI**  
- .NET 9 SDK instalado  
- Emulador ou dispositivo físico (Android/iOS/Windows)  

---

## 🚀 Instalação e execução

### 1. Clone o repositório

git clone <url-do-repositorio>


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
