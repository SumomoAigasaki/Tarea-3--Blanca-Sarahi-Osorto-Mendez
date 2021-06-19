using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppIntegrarSqlite.Model
{
    public class Personas
    {
        //indicamos que es una tabla colocandole el id 
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        //Maximo de caracteres
        [MaxLength(25)]
        public String  Nombres { get; set; }
        public String Apellidos { get; set; }
        public int Edad { get; set; }
        //Para decir que el correo es unico-->UNIQUE
        [MaxLength(100),Unique]
        public String Correo { get; set; }
        [MaxLength(300)]
        public String Direccion { get; set; }
        public String FechaNacimiento { get; set; }

        public String NombreCompleto { get; set; }
    }
}
