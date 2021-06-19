using AppIntegrarSqlite.Model;
using SQLite;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppIntegrarSqlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage1 : ContentPage
    {
        public ObservableCollection<string> ListaPersona { get; set; }

        public ListViewPage1()
        {
            InitializeComponent();

            
                 using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {   //mandamos a que tabla se guarda
                conexion.CreateTable<Personas>();
                var listpersonas = conexion.Table<Personas>().ToList();
                

                if (listpersonas != null)
                {
                    ListaPersonas.ItemsSource = listpersonas;
                }else
                {
                    DisplayAlert("Lista Vacia", "Por favor Ingrese un Dato","Ok");
                }
            }
        
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Accion Mas", mi.CommandParameter + " more context action", "OK");
        }

        private void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Accion Borrars", mi.CommandParameter + " more context action", "OK");
        }
    }
}
