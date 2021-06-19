using AppIntegrarSqlite.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppIntegrarSqlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private Personas seleccionarItem;

        //private int CampoId;
        //private String CampoNombre;
        //private String CampoApellido;
        //private String CampoCorreo;
        //private int CampoEdad;
        //private String CampoFecha;
        //private String CampoDireccion;

        public Page1()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {   //mandamos a que tabla se guarda
                conexion.CreateTable<Personas>();

                var listpersonas = conexion.Table<Personas>().ToList();
                ListaPersonas.ItemsSource = listpersonas;

            }
        }


       
        private void MenuItem_Clicked_1(object sender, EventArgs e)
        {

        }

        private async void btnModificar_Clicked(object sender, EventArgs e)
        {
                if (seleccionarItem != null)
                {
                //Objeto Anonimo New
                //Para la fecha y convertirlo a tipo fecha
                    var persona = new 
                    {
                        Id = seleccionarItem.Id,
                        Nombres = seleccionarItem.Nombres,
                        Apellidos = seleccionarItem.Apellidos,
                        Edad = seleccionarItem.Edad,
                        FechaNacimiento = Convert.ToDateTime(seleccionarItem.FechaNacimiento, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat),
                        Correo = seleccionarItem.Correo,
                        Direccion = seleccionarItem.Direccion
                    };

                    var Page = new MainPage();
                    Page.BindingContext = persona;
                    await Navigation.PushAsync(Page);
                }
                else
                {
                    await DisplayAlert("Sin Seleccion", "Por Favor Seleccione un Dato", "OK");
                }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            
            using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {
                if (seleccionarItem !=null)
                {
                    DisplayAlert("Aviso", "Se Eliminara el Campo Seleccionado(ID): " + seleccionarItem.Id + " Nombre: " + seleccionarItem.Nombres + " De la lista de personas", "Ok");

                    var listapersonas = conexion.Delete<Personas>(seleccionarItem);
                }else
                {
                    DisplayAlert("Sin Seleccion", "Por Favor Seleccione un Dato", "OK");
                }
                
            }

           
        }


        //seleccionamos el Item y enviamos los parametros
        private void ListaPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            seleccionarItem = e.SelectedItem as Personas;

          
            //Confirmamos que se seleccione
            //DisplayAlert("campo seleccionado (id): " + seleccionarItem.Id, "nombre " + seleccionarItem.Nombres + " "+ seleccionarItem.Apellidos + " correo " + seleccionarItem.Correo+ " de la lista", "ok");

        }
    }
}