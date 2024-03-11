using Serilog;

namespace backendOrkletti.src.Extensions.toBuilder;

public static class LogBuilder {
	public static void AddLogService(this WebApplicationBuilder builder) {
		//!ativando serilog
		builder.Host.UseSerilog((context, configuration) => configuration.WriteTo.Console());
	}
}
