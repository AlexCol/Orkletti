using backendOrkletti.src.Model;
using Microsoft.EntityFrameworkCore;

namespace backendOrkletti.src.Extensions.toBuilder;

public static class PostgreBuilder {
	public static void AddPostgre(this WebApplicationBuilder builder) {
		var conectionString = builder.Configuration["ConnectionStrings:Postgres"];
		builder.Services.AddDbContext<PostgreContext>(options => {
			options.UseNpgsql(conectionString);
		});
	}
}
