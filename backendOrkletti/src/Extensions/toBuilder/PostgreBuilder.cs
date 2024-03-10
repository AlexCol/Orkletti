using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUTENTICADOR.src.Model;
using Microsoft.EntityFrameworkCore;

namespace backendOrkletti.src.Extensions.toBuilder;

public static class PostgreBuilder {
	public static void addPostgre(this WebApplicationBuilder builder) {
		var conectionString = builder.Configuration["ConnectionStrings:Postgres"];
		builder.Services.AddDbContext<PostgreContext>(options => {
			options.UseNpgsql(conectionString);
		});
	}
}
