using CommunityToolkit.Mvvm.Messaging;
using FutbolNet.Class;
using FutbolNet.ViewModels;
using FutbolNet.Views.Jugadores;
using FutbolNet.Views.Ligas;

namespace FutbolNet
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            //código para preparar la recepción de mensajes y la llamada al método RecibirMensaje
            WeakReferenceMessenger.Default.Register<MyMessage>(this, (r, m) =>
            {
                AlRecibirMensaje(m);
            });
        }

        private async void AlRecibirMensaje(MyMessage m)
        {
            if (m.Value == "AbrirAddEditJugadorView")
            {
                await Navigation.PushAsync(new AddEditJugadorView(m.Jugador));
            }
            else if (m.Value == "AbrirJugadores")
            {
                await Navigation.PushAsync(new JugadorView());
            }
            else if (m.Value == "VolverAJugadores")
            {
                await Navigation.PopAsync();
            }
            if (m.Value == "AbrirAddEditLigaView")
            {
                await Navigation.PushAsync(new AddEditLigaView(m.Liga));
            }
            else if (m.Value == "AbrirLigas")
            {
                await Navigation.PushAsync(new LigaView());
            }
            else if (m.Value == "VolverALigas")
            {
                await Navigation.PopAsync();
            }
        }

        private async void JugadorBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JugadorView());


        }

        private async void LigaBtn_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LigaView());

        }
    }
}

//private void OnCounterClicked(object sender, EventArgs e)
//{
//    count++;

//    if (count == 1)
//        CounterBtn.Text = $"Clicked {count} time";
//    else
//        CounterBtn.Text = $"Clicked {count} times";

//    SemanticScreenReader.Announce(CounterBtn.Text);
//}

