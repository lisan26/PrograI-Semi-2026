using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // Esta libreria es para usar bases de datos
using System.Data.SqlClient; // Esta libreria permite usar SQLServer

namespace miPrimeaAplicacion
{
    internal class Conexion
    {
        // Definir los miembros, atributos y metodos de la clase
        public SqlConnection objConexion = new SqlConnection(); // Conectarme a la BD
        public SqlCommand objComando = new SqlCommand(); // Ejecutar consultas (Insert, update, delete, select) SQL en la BD
        public SqlDataAdapter objDataAdapter = new SqlDataAdapter(); // un puente entre la BD y la aplicacion.
        DataSet objDs = new DataSet(); // Representa una copia en memoria de la arquitectura de la BD

        public Conexion()
        { // Constructor e inicializador de los miembros de la clase
            String cadenaCoenxion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\db_academica.mdf;Integrated Security=True";
            objConexion.ConnectionString = cadenaCoenxion;
            objConexion.Open(); // abrir la BD
        }

        public DataSet obtenerDatos()
        {
            objDs.Clear(); // Limpiar el dataset.
            objComando.Connection = objConexion; // Establecer la conexion para ejecutar consultas a la BD

            objDataAdapter.SelectCommand = objComando;
            objComando.CommandText = "SELECT * FROM alumnos";
            objDataAdapter.Fill(objDs, "alumnos"); // tomamos los datos de la BD y llenamos el ds

            return objDs;
        }

        public string administrarDatosAlumnos(string[] datos, string accion)
        {
            try
            {
                objComando.Connection = objConexion;

                if (accion == "nuevo")
                {
                    objComando.CommandText = "INSERT INTO alumnos (codigo, nombre, direccion, telefono, email) " +
                    "VALUES ('" + datos[1] + "', '" + datos[2] + "', '" + datos[3] + "', '" + datos[4] + "', '" + datos[5] + "')";
                }
                else if (accion == "modificar")
                {
                    objComando.CommandText = "UPDATE alumnos SET codigo='" + datos[1] + "', nombre='" + datos[2] + "', " +
                    "direccion='" + datos[3] + "', telefono='" + datos[4] + "', email='" + datos[5] + "' " +
                    "WHERE idAlumno='" + datos[0] + "'";
                }
                else if (accion == "eliminar")
                {
                    objComando.CommandText = "DELETE FROM alumnos WHERE idAlumno='" + datos[0] + "'";
                }

                objComando.ExecuteNonQuery(); // Ejecuta la consulta de escritura/eliminación en la BD
                return "1"; // Indica éxito
            }
            catch (Exception ex)
            {
                return ex.Message; // Devuelve el error si falla la consulta
            }
        }
    }
}