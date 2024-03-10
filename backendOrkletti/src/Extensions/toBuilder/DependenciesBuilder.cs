using backendOrkletti.src.Repository.GenericRepository;
using backendOrkletti.src.Repository.PostRepository;


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

		//!adicionando classes para injeções de dependencia
		builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
		builder.Services.AddScoped<IPostRepository, PostRepository>();
	}
}