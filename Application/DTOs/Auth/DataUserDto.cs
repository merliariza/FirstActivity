using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs.Auth
{
    public class DataUserDto
    {
        public string? Mensaje { get; set; }
        public bool EstaAutenticado { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public List<string>? roles { get; set; }
        public string? Token { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}