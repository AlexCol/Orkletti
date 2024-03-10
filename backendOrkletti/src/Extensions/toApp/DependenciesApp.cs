
namespace backendOrkletti.src.Extensions.toApp;

public static class DependenciesApp {
	public static void addDependencies(this WebApplication app) {
		//!adicionando configurações padrão
		app.UseCors();

		app.UseAuthentication();
		app.UseAuthorization();

		app.UseSwagger();
		app.UseSwaggerUI();

		app.UseHttpsRedirection();
		app.MapControllers();

	}
}