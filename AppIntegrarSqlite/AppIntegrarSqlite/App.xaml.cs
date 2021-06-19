using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppIntegrarSqlite
{
    public partial class App : Application
    {
        public static string UbicacionDB = string.Empty;

        //Constructores de clases 
        //Constructor que no recibe el parametro
        public App()
        {
            InitializeComponent();

            //Navegar entre pantallas 
            MainPage = new NavigationPage (new  MainPage());

        }

        //Constructor que recibe la ubicacion de la pagina 
        public App(String DBLocal)
        {
            InitializeComponent();


            //Navegar entre pantallas 
            MainPage = new NavigationPage(new MainPage());
            UbicacionDB = DBLocal;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
