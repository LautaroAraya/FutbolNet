using CommunityToolkit.Mvvm.Messaging;
using FutbolNet.Class;
using FutbolNet.ViewModels;
using FutbolNet.Views.Jugadores;

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
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JugadorView());


        }

        //private async void Button_Clicked_1(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new ());
        //}
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

