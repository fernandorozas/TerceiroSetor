using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using TerceiroSetor.Application.Gateways;

namespace TerceiroSetor.Identity
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddKeycloack(this IServiceCollection services, IdentitySettings settings)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.Authority =settings.Authority;
                        options.Audience = settings.Client;
                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        options.TokenValidationParameters.NameClaimType = ClaimTypes.NameIdentifier;
                        options.TokenValidationParameters.ValidateIssuerSigningKey = false;
                        options.TokenValidationParameters.ValidateIssuer = false;
                        options.TokenValidationParameters.SignatureValidator = IntedValidateSignature;
                        options.Events = new JwtBearerEvents
                        {
                            OnTokenValidated = context =>
                            {
                                JsonWebToken tokenJwt = context.SecurityToken as JsonWebToken;
                                context.Principal.AddIdentities(FillClaims(tokenJwt.Claims));
                                return Task.CompletedTask;
                            },
                            OnAuthenticationFailed = context =>
                            {
                                context.NoResult();
                                context.Response.StatusCode = 401;
                                context.Response.ContentType = "text/plain";
                                return context.Response.WriteAsync("Ocorreu um erro ao processar a autenticação.");
                            },
                        };
                    });

            services.AddScoped<IIdentityService>(provider => new IdentityService(settings));
            services.AddScoped<IUser, UserService>();

            return services;
        }

        private static void AddClaimFromRoleList(List<Claim> claims, List<string> roles)
        {
            if (roles != null)
                foreach (var item in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }
        }

        private static List<ClaimsIdentity> FillClaims(IEnumerable<Claim> claims)
        {
            var list = new List<ClaimsIdentity>();
            if (claims != null)
            {
                list.Add(new ClaimsIdentity(claims));
            }
            return list;
        }
        private static JsonWebToken IntedValidateSignature(string token, TokenValidationParameters parameters)
        {
            return new JsonWebToken(token);
        }

    }
}
