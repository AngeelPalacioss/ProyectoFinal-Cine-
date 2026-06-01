using System;
using System.Collections.Generic;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ProyectoFinal
{
    public sealed class Conexion
    {
        // ── Singleton ────────────────────────────────────────────────
        private static Conexion? _instancia;
        private static readonly object _lock = new();

        public static Conexion Instancia
        {
            get
            {
                lock (_lock)
                {
                    _instancia ??= new Conexion();
                    return _instancia;
                }
            }
        }

        // ── Cadena de conexion ───────────────────────────────────────
        private readonly string _connectionString;

        private Conexion()
        {
            var builder = new OracleConnectionStringBuilder
            {
                DataSource = "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                                    "(HOST=192.168.100.130)(PORT=1521))" +
                                    "(CONNECT_DATA=(SERVICE_NAME=xe)))",
                UserID = "admin",
                Password = "Admin123456",
                Pooling = true,
                MinPoolSize = 1,
                MaxPoolSize = 10,
                ConnectionTimeout = 30,
                IncrPoolSize = 2
            };

            _connectionString = builder.ToString();
        }

        // ── Obtener conexion del pool ────────────────────────────────
        public OracleConnection ObtenerConexion()
        {
            var conn = new OracleConnection(_connectionString);
            conn.Open();
            return conn;
        }

        // ── Probar conexion ──────────────────────────────────────────
        public bool ProbarConexion(out string mensaje)
        {
            try
            {
                using var conn = ObtenerConexion();
                mensaje = "Conexion exitosa. Version: " + conn.ServerVersion;
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error de conexion: " + ex.Message;
                return false;
            }
        }

        // ── Ejecutar SELECT → DataTable ──────────────────────────────
        public DataTable EjecutarConsulta(string sql, OracleParameter[]? parametros = null)
        {
            using var conn = ObtenerConexion();
            using var cmd = new OracleCommand(sql, conn);

            if (parametros != null)
                cmd.Parameters.AddRange(parametros);

            var dt = new DataTable();
            using var adapter = new OracleDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        // ── Ejecutar INSERT / UPDATE / DELETE → filas afectadas ──────
        public int EjecutarComando(string sql, OracleParameter[]? parametros = null)
        {
            using var conn = ObtenerConexion();
            using var cmd = new OracleCommand(sql, conn);

            if (parametros != null)
                cmd.Parameters.AddRange(parametros);

            return cmd.ExecuteNonQuery();
        }

        // ── Ejecutar procedimiento almacenado ────────────────────────
        public void EjecutarProcedimiento(string nombre, OracleParameter[] parametros)
        {
            using var conn = ObtenerConexion();
            using var cmd = new OracleCommand(nombre, conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddRange(parametros);
            cmd.ExecuteNonQuery();
        }
    }
}
