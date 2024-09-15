namespace ServerLibrary.Dtos;

public class JwtOptionsDTO
{
    public string? SecretKey { get; set; }

    public string? Issuer { get; set; }
    
    public string? Audience { get; set; }
    
    public double AccessTokenExpiration { get; set; }
    
    public double RefreshTokenExpiration { get; set; }
}
