using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendOrkletti.src.Extensions.toBuilder;

public static class CorsBuilder {
	public static void AddCors(this WebApplicationBuilder builder) {
		builder.Services.AddCors(opt => {
			opt.AddDefaultPolicy(build => {
				build
						.AllowAnyOrigin()
						.AllowAnyHeader()
						.AllowAnyMethod();
			});
		});
	}
}