using AutoMapper;
using backendOrkletti.src.ValueObjects.Mapping;

namespace backendOrkletti.src.Extensions.toBuilder;

public static class AutoMapperBuilder {
	public static void AddAutoMapper(this WebApplicationBuilder builder) {
		//!configuração do automapping (pra evitar precisar criar um conversor)
		IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
		builder.Services.AddSingleton(mapper);
		builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
	}

}
