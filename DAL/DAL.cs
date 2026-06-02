using Oracle.ManagedDataAccess.Client;
using ProyectoFinal.Modelos;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace ProyectoFinal.DAL
{
    //GUARDA EL USUARIO QUE INICIO SESION EN MEMORIA
    public static class SesionGlobal
    {
        public static int    UsuId      { get; set; }
        public static string Username   { get; set; } = "";
        public static string Nombre     { get; set; } = "";
        public static string Rol        { get; set; } = "";
        public static string PermisosHex{ get; set; } = "00000000";
        public static int    SesId      { get; set; }

        public static bool TienePermiso(int bitMask)
        {
            int permisos = Convert.ToInt32(PermisosHex, 16);
            return (permisos & bitMask) == bitMask;
        }

        public static void Limpiar()
        {
            UsuId       = 0;
            Username    = "";
            Nombre      = "";
            Rol         = "";
            PermisosHex = "00000000";
            SesId       = 0;
        }
    }

    //OCURRE EL LOGIN DAL
    public class LoginDAL
    {
        private readonly Conexion _db = Conexion.Instancia;

        public static string HashSHA256(string texto)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(texto));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public bool Autenticar(string username, string password, out string mensaje)
        {
            mensaje = "";
            try
            {
                string hash = HashSHA256(password);
                string sql  = @"SELECT usu_id, username, nombre, rol, permisos_hex
                                FROM   USUARIOS_APP
                                WHERE  UPPER(username) = UPPER(:usr)
                                AND    password_hash   = :pwd
                                AND    activo          = 1";

                var parametros = new[]
                {
                    new OracleParameter("usr", username),
                    new OracleParameter("pwd", hash)
                };

                var dt = _db.EjecutarConsulta(sql, parametros);

                if (dt.Rows.Count == 0)
                {
                    mensaje = "Usuario o contrasena incorrectos.";
                    return false;
                }

                var fila = dt.Rows[0];

                // Registrar sesion en BD
                string sqlSes = @"INSERT INTO SESIONES (usuario, fecha_inicio, ip_origen)
                                  VALUES (:usr, SYSTIMESTAMP, :ip)
                                  RETURNING ses_id INTO :sid";

                using var conn = _db.ObtenerConexion();
                using var cmd  = new OracleCommand(sqlSes, conn);
                cmd.Parameters.Add("usr", username);
                cmd.Parameters.Add("ip",  "WinForms");
                var pSid = new OracleParameter("sid", OracleDbType.Int32)
                           { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(pSid);
                cmd.ExecuteNonQuery();

                // Guardar en sesion global
                SesionGlobal.UsuId       = Convert.ToInt32(fila["usu_id"]);
                SesionGlobal.Username    = fila["username"].ToString()!;
                SesionGlobal.Nombre      = fila["nombre"].ToString()!;
                SesionGlobal.Rol         = fila["rol"].ToString()!;
                SesionGlobal.PermisosHex = fila["permisos_hex"].ToString()!;
                SesionGlobal.SesId       = Convert.ToInt32(pSid.Value.ToString());

                mensaje = "OK";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
                return false;
            }
        }

        public void CerrarSesion()
        {
            if (SesionGlobal.SesId > 0)
            {
                string sql = @"UPDATE SESIONES SET fecha_fin = SYSTIMESTAMP
                               WHERE ses_id = :sid";
                _db.EjecutarComando(sql, new[]
                {
                    new OracleParameter("sid", SesionGlobal.SesId)
                });
            }
            SesionGlobal.Limpiar();
        }
    }

    public class PeliculasDAL
    {
        private readonly Conexion _db = Conexion.Instancia;

        public DataTable ObtenerTodas(string filtro = "")
        {
            string sql = @"SELECT pel_id, titulo, director, genero,
                                  duracion_min, clasificacion, fecha_estreno, activa
                           FROM   PELICULAS
                           WHERE  activa = 1";

            if (!string.IsNullOrEmpty(filtro))
                sql += " AND UPPER(titulo) LIKE UPPER(:filtro)";

            sql += " ORDER BY titulo";

            if (!string.IsNullOrEmpty(filtro))
                return _db.EjecutarConsulta(sql, new[]
                {
                    new OracleParameter("filtro", "%" + filtro + "%")
                });

            return _db.EjecutarConsulta(sql);
        }

        public bool Guardar(Pelicula p, out string mensaje)
        {
            mensaje = "";
            try
            {
                if (p.PelId == 0)
                {
                    string sql = @"INSERT INTO PELICULAS
                                   (titulo, director, genero, duracion_min,
                                    clasificacion, sinopsis, fecha_estreno, activa, ses_id)
                                   VALUES (:tit,:dir,:gen,:dur,:cla,:sin,:fec,:act,:ses)";
                    _db.EjecutarComando(sql, new[]
                    {
                        new OracleParameter("tit", p.Titulo),
                        new OracleParameter("dir", p.Director),
                        new OracleParameter("gen", p.Genero),
                        new OracleParameter("dur", p.DuracionMin),
                        new OracleParameter("cla", p.Clasificacion),
                        new OracleParameter("sin", p.Sinopsis),
                        new OracleParameter("fec", p.FechaEstreno.HasValue ? (object)p.FechaEstreno.Value : DBNull.Value),
                        new OracleParameter("act", p.Activa),
                        new OracleParameter("ses", SesionGlobal.SesId)
                    });
                }
                else
                {
                    string sql = @"UPDATE PELICULAS
                                   SET titulo=:tit, director=:dir, genero=:gen,
                                       duracion_min=:dur, clasificacion=:cla,
                                       sinopsis=:sin, fecha_estreno=:fec,
                                       modificado_por=:mod, fecha_modificacion=SYSTIMESTAMP
                                   WHERE pel_id = :id";
                    _db.EjecutarComando(sql, new[]
                    {
                        new OracleParameter("tit", p.Titulo),
                        new OracleParameter("dir", p.Director),
                        new OracleParameter("gen", p.Genero),
                        new OracleParameter("dur", p.DuracionMin),
                        new OracleParameter("cla", p.Clasificacion),
                        new OracleParameter("sin", p.Sinopsis),
                        new OracleParameter("fec", p.FechaEstreno.HasValue ? (object)p.FechaEstreno.Value : DBNull.Value),
                        new OracleParameter("mod", SesionGlobal.Username),
                        new OracleParameter("id",  p.PelId)
                    });
                }
                mensaje = "OK";
                return true;
            }
            catch (Exception ex) { mensaje = ex.Message; return false; }
        }

        public bool Eliminar(int pelId, out string mensaje)
        {
            mensaje = "";
            try
            {
                // Baja logica: no elimina fisicamente
                string sql = @"UPDATE PELICULAS SET activa = 0,
                               modificado_por = :mod, fecha_modificacion = SYSTIMESTAMP
                               WHERE pel_id = :id";
                _db.EjecutarComando(sql, new[]
                {
                    new OracleParameter("mod", SesionGlobal.Username),
                    new OracleParameter("id",  pelId)
                });
                mensaje = "OK";
                return true;
            }
            catch (Exception ex) { mensaje = ex.Message; return false; }
        }
    }

    public class SalasDAL
    {
        private readonly Conexion _db = Conexion.Instancia;

        public DataTable ObtenerTodas()
        {
            return _db.EjecutarConsulta(
                "SELECT sala_id, nombre, capacidad, tipo, activa FROM SALAS ORDER BY nombre");
        }

        public DataTable ObtenerActivas()
        {
            return _db.EjecutarConsulta(
                "SELECT sala_id, nombre, capacidad, tipo FROM SALAS WHERE activa=1 ORDER BY nombre");
        }

        public bool Guardar(Sala s, out string mensaje)
        {
            mensaje = "";
            try
            {
                if (s.SalaId == 0)
                {
                    string sql = @"INSERT INTO SALAS (nombre, capacidad, tipo, activa, ses_id)
                                   VALUES (:nom,:cap,:tip,:act,:ses)";
                    _db.EjecutarComando(sql, new[]
                    {
                        new OracleParameter("nom", s.Nombre),
                        new OracleParameter("cap", s.Capacidad),
                        new OracleParameter("tip", s.Tipo),
                        new OracleParameter("act", s.Activa),
                        new OracleParameter("ses", SesionGlobal.SesId)
                    });
                }
                else
                {
                    string sql = @"UPDATE SALAS SET nombre=:nom, capacidad=:cap, tipo=:tip,
                                   modificado_por=:mod, fecha_modificacion=SYSTIMESTAMP
                                   WHERE sala_id=:id";
                    _db.EjecutarComando(sql, new[]
                    {
                        new OracleParameter("nom", s.Nombre),
                        new OracleParameter("cap", s.Capacidad),
                        new OracleParameter("tip", s.Tipo),
                        new OracleParameter("mod", SesionGlobal.Username),
                        new OracleParameter("id",  s.SalaId)
                    });
                }
                mensaje = "OK";
                return true;
            }
            catch (Exception ex) { mensaje = ex.Message; return false; }
        }

        public bool Eliminar(int salaId, out string mensaje)
        {
            mensaje = "";
            try
            {
                _db.EjecutarComando(
                    "UPDATE SALAS SET activa=0, modificado_por=:mod, fecha_modificacion=SYSTIMESTAMP WHERE sala_id=:id",
                    new[] { new OracleParameter("mod", SesionGlobal.Username), new OracleParameter("id", salaId) });
                mensaje = "OK";
                return true;
            }
            catch (Exception ex) { mensaje = ex.Message; return false; }
        }
    }


    public class FuncionesDAL
    {
        private readonly Conexion _db = Conexion.Instancia;

        public DataTable ObtenerPorFecha(DateTime fecha)
        {
            string sql = @"SELECT f.func_id, p.titulo, s.nombre AS sala,
                                  f.fecha, f.hora_inicio, f.hora_fin,
                                  f.precio_base, f.precio_con_iva, f.estado
                           FROM   FUNCIONES f
                           JOIN   PELICULAS p ON f.pel_id  = p.pel_id
                           JOIN   SALAS    s ON f.sala_id = s.sala_id
                           WHERE  TRUNC(f.fecha) = TRUNC(:fec)
                           ORDER  BY f.hora_inicio";
            return _db.EjecutarConsulta(sql, new[]
            {
                new OracleParameter("fec", fecha)
            });
        }

        public DataTable ObtenerTodas()
        {
            string sql = @"SELECT f.func_id, p.titulo, s.nombre AS sala,
                                  f.fecha, f.hora_inicio, f.hora_fin,
                                  f.precio_base, f.precio_con_iva, f.estado
                           FROM   FUNCIONES f
                           JOIN   PELICULAS p ON f.pel_id  = p.pel_id
                           JOIN   SALAS    s ON f.sala_id = s.sala_id
                           ORDER  BY f.fecha DESC, f.hora_inicio";
            return _db.EjecutarConsulta(sql);
        }

        public bool Guardar(Funcion f, out string mensaje)
        {
            mensaje = "";
            try
            {
                if (f.FuncId == 0)
                {
                    string sql = @"INSERT INTO FUNCIONES
                                   (pel_id, sala_id, fecha, hora_inicio, hora_fin,
                                    precio_base, estado, ses_id)
                                   VALUES (:pel,:sal,:fec,:hi,:hf,:pre,:est,:ses)";
                    _db.EjecutarComando(sql, new[]
                    {
                        new OracleParameter("pel", f.PelId),
                        new OracleParameter("sal", f.SalaId),
                        new OracleParameter("fec", f.Fecha),
                        new OracleParameter("hi",  f.HoraInicio),
                        new OracleParameter("hf",  f.HoraFin),
                        new OracleParameter("pre", f.PrecioBase),
                        new OracleParameter("est", f.Estado),
                        new OracleParameter("ses", SesionGlobal.SesId)
                    });
                }
                else
                {
                    string sql = @"UPDATE FUNCIONES
                                   SET pel_id=:pel, sala_id=:sal, fecha=:fec,
                                       hora_inicio=:hi, hora_fin=:hf,
                                       precio_base=:pre, estado=:est,
                                       modificado_por=:mod, fecha_modificacion=SYSTIMESTAMP
                                   WHERE func_id=:id";
                    _db.EjecutarComando(sql, new[]
                    {
                        new OracleParameter("pel", f.PelId),
                        new OracleParameter("sal", f.SalaId),
                        new OracleParameter("fec", f.Fecha),
                        new OracleParameter("hi",  f.HoraInicio),
                        new OracleParameter("hf",  f.HoraFin),
                        new OracleParameter("pre", f.PrecioBase),
                        new OracleParameter("est", f.Estado),
                        new OracleParameter("mod", SesionGlobal.Username),
                        new OracleParameter("id",  f.FuncId)
                    });
                }
                mensaje = "OK";
                return true;
            }
            catch (Exception ex) { mensaje = ex.Message; return false; }
        }

        public bool Eliminar(int funcId, out string mensaje)
        {
            mensaje = "";
            try
            {
                _db.EjecutarComando(
                    @"UPDATE FUNCIONES SET estado='Cancelada',
                      modificado_por=:mod, fecha_modificacion=SYSTIMESTAMP
                      WHERE func_id=:id",
                    new[] { new OracleParameter("mod", SesionGlobal.Username),
                            new OracleParameter("id",  funcId) });
                mensaje = "OK";
                return true;
            }
            catch (Exception ex) { mensaje = ex.Message; return false; }
        }
    }


    public class DescuentosDAL
    {
        private readonly Conexion _db = Conexion.Instancia;

        public DataTable ObtenerTodos()
        {
            return _db.EjecutarConsulta(
                @"SELECT desc_id, nombre, porcentaje, dia_semana,
                         hora_inicio, hora_fin, activo
                  FROM   DESCUENTOS ORDER BY nombre");
        }

        public DataTable ObtenerDescuentoAplicable(DateTime fechaFuncion, string horaFuncion)
        {
            string diaSemana = fechaFuncion.DayOfWeek switch
            {
                DayOfWeek.Monday    => "Lunes",
                DayOfWeek.Tuesday   => "Martes",
                DayOfWeek.Wednesday => "Miercoles",
                DayOfWeek.Thursday  => "Jueves",
                DayOfWeek.Friday    => "Viernes",
                DayOfWeek.Saturday  => "Sabado",
                DayOfWeek.Sunday    => "Domingo",
                _ => ""
            };

            string sql = @"SELECT desc_id, nombre, porcentaje
                           FROM   DESCUENTOS
                           WHERE  activo = 1
                           AND    (dia_semana = 'Todos' OR dia_semana = :dia)
                           AND    :hora BETWEEN hora_inicio AND hora_fin
                           ORDER  BY porcentaje DESC
                           FETCH  FIRST 1 ROW ONLY";

            return _db.EjecutarConsulta(sql, new[]
            {
                new OracleParameter("dia",  diaSemana),
                new OracleParameter("hora", horaFuncion)
            });
        }

        public bool Guardar(Descuento d, out string mensaje)
        {
            mensaje = "";
            try
            {
                if (d.DescId == 0)
                {
                    string sql = @"INSERT INTO DESCUENTOS
                                   (nombre, porcentaje, dia_semana, hora_inicio, hora_fin, activo, ses_id)
                                   VALUES (:nom,:pct,:dia,:hi,:hf,:act,:ses)";
                    _db.EjecutarComando(sql, new[]
                    {
                        new OracleParameter("nom", d.Nombre),
                        new OracleParameter("pct", d.Porcentaje),
                        new OracleParameter("dia", d.DiaSemana),
                        new OracleParameter("hi",  d.HoraInicio),
                        new OracleParameter("hf",  d.HoraFin),
                        new OracleParameter("act", d.Activo),
                        new OracleParameter("ses", SesionGlobal.SesId)
                    });
                }
                else
                {
                    string sql = @"UPDATE DESCUENTOS
                                   SET nombre=:nom, porcentaje=:pct, dia_semana=:dia,
                                       hora_inicio=:hi, hora_fin=:hf, activo=:act,
                                       modificado_por=:mod, fecha_modificacion=SYSTIMESTAMP
                                   WHERE desc_id=:id";
                    _db.EjecutarComando(sql, new[]
                    {
                        new OracleParameter("nom", d.Nombre),
                        new OracleParameter("pct", d.Porcentaje),
                        new OracleParameter("dia", d.DiaSemana),
                        new OracleParameter("hi",  d.HoraInicio),
                        new OracleParameter("hf",  d.HoraFin),
                        new OracleParameter("act", d.Activo),
                        new OracleParameter("mod", SesionGlobal.Username),
                        new OracleParameter("id",  d.DescId)
                    });
                }
                mensaje = "OK";
                return true;
            }
            catch (Exception ex) { mensaje = ex.Message; return false; }
        }

        public bool Eliminar(int descId, out string mensaje)
        {
            mensaje = "";
            try
            {
                _db.EjecutarComando(
                    @"UPDATE DESCUENTOS SET activo=0,
                      modificado_por=:mod, fecha_modificacion=SYSTIMESTAMP
                      WHERE desc_id=:id",
                    new[] { new OracleParameter("mod", SesionGlobal.Username),
                            new OracleParameter("id",  descId) });
                mensaje = "OK";
                return true;
            }
            catch (Exception ex) { mensaje = ex.Message; return false; }
        }
    }

    public class VentasDAL
    {
        private readonly Conexion _db = Conexion.Instancia;

        public DataTable ObtenerHistorial(DateTime desde, DateTime hasta, string filtroPelicula = "")
        {
            string sql = @"SELECT bol_id AS folio, pelicula, sala,
                                  hora_inicio, tipo_boleto, cantidad,
                                  precio_unitario, descuento_pct, total_pagado,
                                  descuento_aplicado, cajero, fecha_venta
                           FROM   VW_HISTORIAL_VENTAS
                           WHERE  fecha_funcion BETWEEN :desde AND :hasta";

            var parametros = new List<OracleParameter>
            {
                new OracleParameter("desde", desde),
                new OracleParameter("hasta", hasta)
            };

            if (!string.IsNullOrEmpty(filtroPelicula))
            {
                sql += " AND UPPER(pelicula) LIKE UPPER(:pel)";
                parametros.Add(new OracleParameter("pel", "%" + filtroPelicula + "%"));
            }

            sql += " ORDER BY fecha_venta DESC";
            return _db.EjecutarConsulta(sql, parametros.ToArray());
        }

        public bool RegistrarVenta(int funcId, int? descId, int cantidad,
                                   decimal precioUnit, decimal descPct,
                                   string tipoBoleto,
                                   out int bolId, out decimal total, out string mensaje)
        {
            bolId   = 0;
            total   = 0;
            mensaje = "";

            try
            {
                using var conn = _db.ObtenerConexion();
                using var cmd  = new OracleCommand("SP_REGISTRAR_VENTA", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add("p_func_id",       OracleDbType.Int32).Value        = funcId;
                cmd.Parameters.Add("p_usu_id",         OracleDbType.Int32).Value        = SesionGlobal.UsuId;
                cmd.Parameters.Add("p_desc_id",        OracleDbType.Int32).Value        = descId.HasValue ? (object)descId.Value : DBNull.Value;
                cmd.Parameters.Add("p_cantidad",       OracleDbType.Int32).Value        = cantidad;
                cmd.Parameters.Add("p_precio_unit",    OracleDbType.Decimal).Value      = precioUnit;
                cmd.Parameters.Add("p_descuento_pct",  OracleDbType.Decimal).Value      = descPct;
                cmd.Parameters.Add("p_tipo_boleto",    OracleDbType.Varchar2).Value     = tipoBoleto;
                cmd.Parameters.Add("p_ses_id",         OracleDbType.Int32).Value        = SesionGlobal.SesId;

                var pBolId   = cmd.Parameters.Add("p_bol_id",  OracleDbType.Int32);
                var pTotal   = cmd.Parameters.Add("p_total",   OracleDbType.Decimal);
                var pMensaje = cmd.Parameters.Add("p_mensaje", OracleDbType.Varchar2, 500);

                pBolId.Direction   = ParameterDirection.Output;
                pTotal.Direction   = ParameterDirection.Output;
                pMensaje.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                mensaje = pMensaje.Value.ToString()!;

                if (mensaje.StartsWith("OK"))
                {
                    bolId = Convert.ToInt32(pBolId.Value.ToString());
                    total = Convert.ToDecimal(pTotal.Value.ToString());
                    return true;
                }
                return false;
            }
            catch (Exception ex) { mensaje = ex.Message; return false; }
        }
    }


    public class ReportesDAL
    {
        private readonly Conexion _db = Conexion.Instancia;

        public DataTable R1_CartelераDia(DateTime fecha)
        {
            string sql = @"SELECT f.func_id, p.titulo AS pelicula, p.clasificacion,
                                  s.nombre AS sala, s.tipo AS tipo_sala,
                                  f.fecha, f.hora_inicio, f.hora_fin,
                                  f.precio_base, f.precio_con_iva
                           FROM   FUNCIONES f
                           JOIN   PELICULAS p ON f.pel_id  = p.pel_id
                           JOIN   SALAS    s ON f.sala_id = s.sala_id
                           WHERE  f.estado = 'Activa'
                           AND    TRUNC(f.fecha) = TRUNC(:fec)
                           ORDER  BY f.hora_inicio";
            return _db.EjecutarConsulta(sql, new[] { new OracleParameter("fec", fecha) });
        }

        public DataTable R2_IngresosPorGenero()
        {
            string sql = @"SELECT p.genero,
                                  COUNT(DISTINCT f.func_id)    AS total_funciones,
                                  SUM(b.cantidad)              AS boletos_vendidos,
                                  SUM(b.total_pagado)          AS ingresos_totales,
                                  ROUND(AVG(b.precio_unitario),2) AS precio_promedio
                           FROM   BOLETOS b
                           JOIN   FUNCIONES f ON b.func_id = f.func_id
                           JOIN   PELICULAS p ON f.pel_id  = p.pel_id
                           GROUP  BY p.genero
                           HAVING SUM(b.total_pagado) > 0
                           ORDER  BY ingresos_totales DESC";
            return _db.EjecutarConsulta(sql);
        }

        public DataTable R3_FuncionessobrePromedio()
        {
            string sql = @"SELECT f.func_id, p.titulo, s.nombre AS sala,
                                  f.fecha, f.hora_inicio,
                                  SUM(b.total_pagado) AS recaudacion
                           FROM   FUNCIONES f
                           JOIN   PELICULAS p ON f.pel_id  = p.pel_id
                           JOIN   SALAS    s ON f.sala_id = s.sala_id
                           JOIN   BOLETOS  b ON b.func_id = f.func_id
                           GROUP  BY f.func_id, p.titulo, s.nombre, f.fecha, f.hora_inicio
                           HAVING SUM(b.total_pagado) > (
                               SELECT AVG(sub_total) FROM (
                                   SELECT SUM(b2.total_pagado) AS sub_total
                                   FROM   BOLETOS b2 GROUP BY b2.func_id))
                           ORDER  BY recaudacion DESC";
            return _db.EjecutarConsulta(sql);
        }

        public DataTable R4_PeliculasConFuncionActiva()
        {
            string sql = @"SELECT p.pel_id, p.titulo, p.director,
                                  p.genero, p.duracion_min, p.clasificacion
                           FROM   PELICULAS p
                           WHERE  EXISTS (
                               SELECT 1 FROM FUNCIONES f
                               WHERE  f.pel_id = p.pel_id
                               AND    f.estado = 'Activa'
                               AND    f.fecha >= TRUNC(SYSDATE))
                           ORDER  BY p.titulo";
            return _db.EjecutarConsulta(sql);
        }

        public DataTable R5_HistorialVentas()
        {
            return _db.EjecutarConsulta(
                "SELECT * FROM VW_HISTORIAL_VENTAS ORDER BY fecha_venta DESC");
        }

        public DataTable R6_CatalogoPaginado(int pagina = 1, int porPagina = 5)
        {
            int offset = (pagina - 1) * porPagina;
            string sql = @"SELECT pel_id, titulo, director, genero,
                                  duracion_min, clasificacion, fecha_estreno
                           FROM   PELICULAS
                           WHERE  activa = 1
                           ORDER  BY fecha_estreno NULLS LAST, titulo
                           OFFSET :off ROWS FETCH NEXT :lim ROWS ONLY";
            return _db.EjecutarConsulta(sql, new[]
            {
                new OracleParameter("off", offset),
                new OracleParameter("lim", porPagina)
            });
        }

        public DataTable R7_ActividadReciente()
        {
            string sql = @"SELECT 'Pelicula registrada' AS tipo_evento,
                                  titulo AS descripcion,
                                  TO_CHAR(fecha_creacion,'DD/MM/YYYY HH24:MI') AS fecha_hora,
                                  creado_por AS usuario
                           FROM   PELICULAS
                           WHERE  fecha_creacion >= SYSTIMESTAMP - INTERVAL '24' HOUR
                           UNION
                           SELECT 'Boleto vendido',
                                  'Folio #'||TO_CHAR(bol_id)||' - '||TO_CHAR(cantidad)||' boleto(s)',
                                  TO_CHAR(fecha_venta,'DD/MM/YYYY HH24:MI'),
                                  creado_por
                           FROM   BOLETOS
                           WHERE  fecha_venta >= SYSTIMESTAMP - INTERVAL '24' HOUR
                           ORDER  BY fecha_hora DESC";
            return _db.EjecutarConsulta(sql);
        }
    }
}
