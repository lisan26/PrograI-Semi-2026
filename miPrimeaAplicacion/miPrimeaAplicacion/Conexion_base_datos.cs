using System;
using System.Data;
using System.Data.SqlClient;

namespace miPrimeaAplicacion
{
    internal class Conexion_base_datos : Conexion
    {
        public string CredencialesIniciales { get; private set; }

        public Conexion_base_datos() : base()
        {
            crearTablaUsuarios();
        }

        private void crearTablaUsuarios()
        {
            const string sql = @"
IF OBJECT_ID('dbo.usuarios_USSS129326', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.usuarios_USSS129326
    (
        idUsuario INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        usuario VARCHAR(35) NOT NULL UNIQUE,
        clave VARCHAR(35) NOT NULL,
        nombre VARCHAR(65) NOT NULL,
        direccion VARCHAR(85) NOT NULL,
        telefono VARCHAR(9) NOT NULL
    );
END;";

            string respuesta = procesar(sql);
            if (respuesta != "-1" && respuesta != "0")
            {
                throw new InvalidOperationException("No se pudo preparar la tabla de usuarios: " + respuesta);
            }

            using (SqlCommand contar = new SqlCommand("SELECT COUNT(*) FROM dbo.usuarios_USSS129326", objConexion))
            {
                if (Convert.ToInt32(contar.ExecuteScalar()) == 0)
                {
                    crearUsuariosIniciales();
                }
            }
        }

        private void crearUsuariosIniciales()
        {
            string[,] usuarios =
            {
                { "demoUSSS1", "Clave129326A", "Usuario inicial 1", "Sin especificar", "000000001" },
                { "demoUSSS2", "Clave129326B", "Usuario inicial 2", "Sin especificar", "000000002" },
                { "demoUSSS3", "Clave129326C", "Usuario inicial 3", "Sin especificar", "000000003" }
            };
            string[] lineas = new string[usuarios.GetLength(0)];
            for (int i = 0; i < usuarios.GetLength(0); i++)
            {
                string respuesta = mantenimiento_usuarios_USSS129326(
                    new[] { "", usuarios[i, 0], usuarios[i, 1], usuarios[i, 2], usuarios[i, 3], usuarios[i, 4] },
                    "nuevo");

                if (respuesta != "1")
                {
                    throw new InvalidOperationException("No se pudieron crear los usuarios iniciales: " + respuesta);
                }

                lineas[i] = "Usuario " + (i + 1) + ": " + usuarios[i, 0] + "  |  Clave: " + usuarios[i, 1];
            }

            CredencialesIniciales = string.Join(Environment.NewLine, lineas);
        }

        public DataSet crearDs()
        {
            DataSet ds = obtenerDatos();
            using (SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT * FROM dbo.usuarios_USSS129326 ORDER BY idUsuario", objConexion))
            {
                adapter.Fill(ds, "usuarios_USSS129326");
            }
            return ds;
        }

        public string mantenimiento_usuarios_USSS129326(string[] datos, string accion)
        {
            if (accion == "nuevo")
            {
                return procesar(
                    "INSERT INTO dbo.usuarios_USSS129326(usuario,clave,nombre,direccion,telefono) VALUES (@usuario,@clave,@nombre,@direccion,@telefono)",
                    new SqlParameter("@usuario", datos[1]),
                    new SqlParameter("@clave", datos[2]),
                    new SqlParameter("@nombre", datos[3]),
                    new SqlParameter("@direccion", datos[4]),
                    new SqlParameter("@telefono", datos[5]));
            }

            if (accion == "modificar")
            {
                return procesar(
                    "UPDATE dbo.usuarios_USSS129326 SET usuario=@usuario, clave=CASE WHEN @clave='' THEN clave ELSE @clave END, nombre=@nombre, direccion=@direccion, telefono=@telefono WHERE idUsuario=@idUsuario",
                    new SqlParameter("@usuario", datos[1]),
                    new SqlParameter("@clave", datos[2]),
                    new SqlParameter("@nombre", datos[3]),
                    new SqlParameter("@direccion", datos[4]),
                    new SqlParameter("@telefono", datos[5]),
                    new SqlParameter("@idUsuario", Convert.ToInt32(datos[0])));
            }

            if (accion == "eliminar")
            {
                return procesar(
                    "DELETE FROM dbo.usuarios_USSS129326 WHERE idUsuario=@idUsuario",
                    new SqlParameter("@idUsuario", Convert.ToInt32(datos[0])));
            }

            return "Accion de mantenimiento no valida.";
        }

        public bool validarUsuario(string usuario, string clave)
        {
            using (SqlCommand comando = new SqlCommand(
                "SELECT COUNT(*) FROM dbo.usuarios_USSS129326 WHERE usuario=@usuario AND clave=@clave", objConexion))
            {
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@clave", clave);
                return Convert.ToInt32(comando.ExecuteScalar()) > 0;
            }
        }

        public string procesar(string sql, params SqlParameter[] parametros)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand(sql, objConexion))
                {
                    if (parametros != null && parametros.Length > 0)
                    {
                        comando.Parameters.AddRange(parametros);
                    }
                    return comando.ExecuteNonQuery().ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
