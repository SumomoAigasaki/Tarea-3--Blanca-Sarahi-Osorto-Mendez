using AppIntegrarSqlite.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppIntegrarSqlite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            
        }


        private void btnSalvar_Clicked(object sender, EventArgs e)
        {
            Int32 resultado = 0;
            DateTime fechaNacimiento = DatapickerFecha.Date;
            //Datos que se le envia al MODEL persona
           

            if (String.IsNullOrEmpty(txtNombres.Text))
            {
                DisplayAlert("Campo Vacio", "Ingrese un Nombre, Por favor ", "Ok");
            }
                else if (String.IsNullOrEmpty(txtApellidos.Text))
                {
                    DisplayAlert("Campo Vacio", "Ingrese un Apellidos, Por favor ", "Ok");
                }
                   
                        else if (String.IsNullOrEmpty(txtCorreo.Text))
                        {
                            DisplayAlert("Campo Vacio", "Ingrese un Correo, Por favor ", "Ok");
                        }
                            else if (String.IsNullOrEmpty(txtDireccion.Text))
                            {
                                DisplayAlert("Campo Vacio", "Ingrese un Direccion, Por favor ", "Ok");
                            }

                            

                                else if (String.IsNullOrEmpty(txtID.Text))
                                    //Para Guardar vamos a validar que si no tiene ID indica que vamos a GUARDAR
                                {
                                    using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
                                    {   //mandamos a que tabla se guarda
                                        conexion.CreateTable<Personas>();
                                        //mandamos los datos que guardamos en la clase persona
                                        //asignamos un resultado que dice si inserto el Script
                                        var persona = new Personas()
                                        {
                                            Nombres = Convert.ToString(txtNombres.Text),
                                            Apellidos = Convert.ToString(txtApellidos.Text),
                                            Edad = Convert.ToInt32(value: txtEdad.Text),
                                            Correo = Convert.ToString(txtCorreo.Text),
                                            Direccion = Convert.ToString(txtDireccion.Text),
                                            FechaNacimiento = fechaNacimiento.ToString("dd/MM/yyyy"),
                                            NombreCompleto = Convert.ToString(txtNombres.Text)+" "+ Convert.ToString(txtApellidos.Text)
                                        };

                                    resultado = conexion.Insert(persona);

                                        if (resultado > 0)
                                        {

                                            DisplayAlert("Aviso", "Se Guardo Exitosamente ", "Ok");
                                            limpiar();
                                        }
                                        else
                                        {
                                            DisplayAlert("Aviso", "hubo un error al enviar los datos", "Ok");
                                        }
                                    }
                                }
                                    else
                                    {
                                        using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
                                        {   //mandamos a que tabla se guarda

                                            //Actualizar Campos de Personas
                                            //Hacemos el setteo de los Campos
                                            //mandamos los campos de donde salen los datos

                                            var Modificar = conexion.Query<Personas>($"Update Personas set " +
                                            $"Nombres = '" + Convert.ToString(txtNombres.Text) + "'," +
                                            $"Apellidos = '" + Convert.ToString(txtApellidos.Text) + "'," +
                                            $"Edad = '" + Convert.ToInt32(value: txtEdad.Text) + "'," +
                                            $"Correo = '" + Convert.ToString(txtCorreo.Text) + "'," +
                                            $"Direccion = '" + Convert.ToString(txtDireccion.Text) + "'," +
                                            $"FechaNacimiento = '" + fechaNacimiento.ToString("dd/MM/yyyy") + "'," +   
                                            $"NombreCompleto= '" + Convert.ToString(txtNombres.Text) + " " + Convert.ToString(txtApellidos.Text) + "'" +
                                            $"WHERE Id = '" + Convert.ToInt32(value: txtID.Text) + "' ");

                   
                                                DisplayAlert("Aviso", " Se Modifico El Campo Con el ID: " + Convert.ToInt32(value: txtID.Text) + "  " + Convert.ToString(txtNombres.Text) + " " 
                                                    + Convert.ToString(txtApellidos.Text) + " ha sido Modificado exitosamente", "Ok");
                                                limpiar();
                                                


                                        }
                                    }

                            
                

         }

        private async void toolbarmenu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }

        public async void limpiar()
        {
            txtNombres.Text = " ";
            txtApellidos.Text = " ";
            txtEdad.Text = " ";
            txtCorreo.Text = " ";
            txtDireccion.Text = " ";

            await Navigation.PushAsync(new Page1());


        }



        //conexion a la base de datos
        //atraves del constructor manda a llamar la ubicacion que se creo en APP.XAML.CS

        //SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB);
        //mandamos a que tabla se guarda

        //conexion.CreateTable<Personas>();
        //mandamos los datos que guardamos en la clase persona
        //asignamos un resultado que dice si inserto el Script

        // resultado = conexion.Insert(persona);
        // conexion.Close();

    }

    //private async void toolbarmenu_clicked(object sender, eventargs e)
    //{
    //    await navigation.pushasync(new page1());
    //}

    //private void txtFechaNacimiento_DateSelected(object sender, DateChangedEventArgs e)
    //{
    //    DisplayAlert("Fecha", e.NewDate.ToString(), "OK");
    //}

}
