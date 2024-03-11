using Microsoft.OpenApi.Models;

namespace backendOrkletti.src.Extensions.toBuilder;

public static class SwaggerBuilder {
	public static void AddSwagger(this WebApplicationBuilder builder) {
		string appName = "Minha API Rest";
		string appVersion = "v1";
		string appDescription = $"{appName} para controle de Autenticação.";
		builder.Services.AddSwaggerGen(c => {
			c.SwaggerDoc(appVersion,
			new OpenApiInfo {
				Title = appName, //titulo no swagger
				Description = appDescription,
				Contact = new OpenApiContact {
					Name = "Alexandre",
					Url = new Uri("http://localhost:3010/")
				}
			});
		});
		builder.Services.AddRouting(opt => opt.LowercaseUrls = true); //!para que fique tudo em minusculo os links no swagger
	}
}
