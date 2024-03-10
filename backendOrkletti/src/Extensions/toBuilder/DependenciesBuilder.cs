namespace backendOrkletti.src.Extensions.toBuilder;

public static class DependenciesBuilder {
	public static void addDependencies(this WebApplicationBuilder builder) {
		//!adicionando configurações padrão
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddControllers();

		//!adicionando configurações
		builder.addSwagger();
		builder.addPostgre();
		builder.addLogService();
	}
}