using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter user name: ");
        string userName = Console.ReadLine();
        Console.WriteLine("Enter user password: ");
        string userPassword = Console.ReadLine();
        UserService userService = new UserService();
        string token = userService.Authenticate(userName,
        userPassword);
        Console.WriteLine(token);
    }
}

internal sealed class UserService
{
    private IDictionary<string, string> _users = new Dictionary<string,
    string>()
{
{"test", "test"}
};
    private const string SecretCode = "THIS IS SOME VERY SECRET STRING!!!";
public string Authenticate(string user, string password)
    {
        if (string.IsNullOrWhiteSpace(user) ||
        string.IsNullOrWhiteSpace(password))
        {
            return string.Empty;
        }
        int i = 0;
        foreach (KeyValuePair<string, string> pair in _users)
        {
            i++;
            if (string.CompareOrdinal(pair.Key, user) == 0 &&
            string.CompareOrdinal(pair.Value, password) == 0)
            {
                return GenerateJwtToken(i);
            }
        }
        return string.Empty;
    }
    private string GenerateJwtToken(int id)
    {
        JwtSecurityTokenHandler tokenHandler = new
        JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(SecretCode);
        SecurityTokenDescriptor tokenDescriptor = new
        SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
        {
new Claim(ClaimTypes.Name, id.ToString())
        }),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = new SigningCredentials(new
        SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken token =
        tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

