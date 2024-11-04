using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ProspAI_Sprint3.Services
{
    /// <summary>
    /// Serviço responsável pela autenticação de usuários.
    /// </summary>
    public class AuthService
    {
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>
        {
            { "ProspAI", "ProjetoProspAI_keywith32caracter" },
            { "David Bryan", "ProjectProspAI_rm55123632caracte" }
        };

        private readonly string _secretKey;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="AuthService"/> com a chave secreta especificada.
        /// </summary>
        /// <param name="secretKey">A chave secreta utilizada para a assinatura dos tokens JWT.</param>
        /// <exception cref="ArgumentException">Lançado quando a chave secreta é nula ou possui menos de 32 caracteres.</exception>
        public AuthService(string secretKey)
        {
            if (string.IsNullOrWhiteSpace(secretKey) || secretKey.Length < 32)
                throw new ArgumentException("A chave secreta deve ter pelo menos 32 caracteres.", nameof(secretKey));

            _secretKey = secretKey;
        }

        /// <summary>
        /// Autentica um usuário e gera um token JWT se as credenciais estiverem corretas.
        /// </summary>
        /// <param name="username">O nome de usuário.</param>
        /// <param name="password">A senha do usuário.</param>
        /// <returns>Um token JWT se as credenciais estiverem corretas; caso contrário, null.</returns>
        public string Authenticate(string username, string password)
        {
            // Verificar se o usuário e a senha estão corretos
            if (!_users.TryGetValue(username, out var storedPassword) || password != storedPassword)
                return null;

            // Gerar o token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
