namespace Logistica.Api.Datos.Modelo.Out
{
    public class LoginResponse
    {
        public int Codigo { get; set; } = 0;
        public string Mensaje { get; set; }
        public string Nombre { get; set; }
        public int Id { get; set; }
        public string Token { get; set; }
    }
}
