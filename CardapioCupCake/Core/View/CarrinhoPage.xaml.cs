using CardapioCupCake.Core.ViewModel;

namespace CardapioCupCake.Core.View;

public partial class CarrinhoPage : ContentPage
{
    CarrinhoViewModel ViewModel;
    public CarrinhoPage(CarrinhoViewModel vm)
    {
        InitializeComponent();
        BindingContext = ViewModel = vm;
    }
    private async void OnFinalizarPedidoClicked(object sender, EventArgs e)
    {
        // Ação ao finalizar o pedido
        await DisplayAlert("Pedido Enviado!", "Seu pedido foi finalizado com sucesso. Acompanhe o status na tela de Pedidos.", "OK");

        // Em uma aplicação real, aqui você faria:
        // 1. Enviar os dados do pedido para a API/servidor.
        // 2. Navegar para a tela de Acompanhamento de Pedido.

        // Exemplo de navegação:
        //
    }
}