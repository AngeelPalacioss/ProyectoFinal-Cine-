namespace ProyectoFinal.Modelos
{
    public class Pelicula
    {
        public int       PelId         { get; set; }
        public string    Titulo        { get; set; } = "";
        public string    Director      { get; set; } = "";
        public string    Genero        { get; set; } = "";
        public int       DuracionMin   { get; set; }
        public string    Clasificacion { get; set; } = "";
        public string    Sinopsis      { get; set; } = "";
        public DateTime? FechaEstreno  { get; set; }
        public int       Activa        { get; set; } = 1;
        public int       SesId         { get; set; }
    }

    public class Sala
    {
        public int    SalaId    { get; set; }
        public string Nombre    { get; set; } = "";
        public int    Capacidad { get; set; }
        public string Tipo      { get; set; } = "Normal";
        public int    Activa    { get; set; } = 1;
        public int    SesId     { get; set; }
    }

    public class Funcion
    {
        public int      FuncId         { get; set; }
        public int      PelId          { get; set; }
        public int      SalaId         { get; set; }
        public DateTime Fecha          { get; set; }
        public string   HoraInicio     { get; set; } = "";
        public string   HoraFin        { get; set; } = "";
        public decimal  PrecioBase     { get; set; }
        public decimal  PrecioConIva   { get; set; }
        public string   Estado         { get; set; } = "Activa";
        public int      SesId          { get; set; }
        // Joins
        public string   TituloPelicula { get; set; } = "";
        public string   NombreSala     { get; set; } = "";
    }

    public class Descuento
    {
        public int     DescId     { get; set; }
        public string  Nombre     { get; set; } = "";
        public decimal Porcentaje { get; set; }
        public string  DiaSemana  { get; set; } = "Todos";
        public string  HoraInicio { get; set; } = "00:00";
        public string  HoraFin    { get; set; } = "23:59";
        public int     Activo     { get; set; } = 1;
        public int     SesId      { get; set; }
    }

    public class Boleto
    {
        public int      BolId           { get; set; }
        public int      FuncId          { get; set; }
        public int      UsuId           { get; set; }
        public int?     DescId          { get; set; }
        public int      Cantidad        { get; set; }
        public decimal  PrecioUnitario  { get; set; }
        public decimal  DescuentoPct    { get; set; }
        public decimal  TotalPagado     { get; set; }
        public string   TipoBoleto      { get; set; } = "Normal";
        public DateTime FechaVenta      { get; set; }
        public int      SesId           { get; set; }
        // Joins
        public string   Pelicula        { get; set; } = "";
        public string   Sala            { get; set; } = "";
        public string   Cajero          { get; set; } = "";
        public string   DescuentoNombre { get; set; } = "";
    }

    public class UsuarioApp
    {
        public int    UsuId        { get; set; }
        public string Username     { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Nombre       { get; set; } = "";
        public string Rol          { get; set; } = "";
        public string PermisosHex  { get; set; } = "00000000";
        public int    Activo       { get; set; } = 1;
        public int    SesId        { get; set; }
    }

    public class Sesion
    {
        public int       SesId       { get; set; }
        public string    Usuario     { get; set; } = "";
        public DateTime  FechaInicio { get; set; }
        public DateTime? FechaFin    { get; set; }
        public string    IpOrigen    { get; set; } = "";
    }
}
