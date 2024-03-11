using backendOrkletti.src.Repository.GenericRepository;
using backendOrkletti.src.Repository.PostRepository;
using backendOrkletti.src.Services.PostService;


namespace backendOrkletti.src.Extensions.toBuilder;

public static class DependenciesBuilder {
	public static void addDependencies(this WebApplicationBuilder builder) {
		//!adicionando configurações padrão
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddControllers();

		//!adicionando configurações
		builder.AddSwagger();
		builder.AddPostgre();
		builder.AddLogService();
		builder.AddAutoMapper();

		//!adicionando classes para injeções de dependencia
		builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
		builder.Services.AddScoped<IPostRepository, PostRepository>();
		builder.Services.AddScoped<IPostService, PostService>();
	}
}