public interface IAutenticacionService
{
    Task<string> GenerarToken(string username, string password);
}

public interface IAutorizacionService
{
    Task<bool> ValidarPermisos(string username, string permiso);
}

public class AutenticacionService : IAutenticacionService
{
    private readonly IConfiguration _configuration;

    public AutenticacionService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> GenerarToken(string username, string password)
    {
        // Validar las credenciales del usuario
        // ...

        // Generar el token JWT
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
        var jwt = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: signingCredentials);
        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return token;
    }
}