using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace backendOrkletti.src.Extensions.toBuilder {
	public static class JWTBuilder {
		//! Método para configurar o serviço JWT
		public static void AddJWTService(this WebApplicationBuilder builder) {
			//! Configura a autenticação para usar JWT
			builder.Services.AddAuthentication(options => {
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options => {
				//! Configura os parâmetros de validação do token JWT
				options.TokenValidationParameters = new TokenValidationParameters {
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = builder.Configuration["TokenConfiguration:Issuer"],
					ValidAudience = builder.Configuration["TokenConfiguration:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenConfiguration:Secret"])),
					ClockSkew = TimeSpan.Zero //! Tempo de tolerância após o tempo de expiração do token
				};
			});

			//! Configura as políticas de autorização
			builder.Services.AddAuthorization(auth => {
				//! Define uma política padrão que exige autenticação JWT
				auth.DefaultPolicy = new AuthorizationPolicyBuilder()
									.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
									.RequireAuthenticatedUser()
									.Build();
			});
		}
	}
}