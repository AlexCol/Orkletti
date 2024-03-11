using AutoMapper;
using backendOrkletti.src.Model.Entity;
using backendOrkletti.src.Model.HttpModels.Request;
using backendOrkletti.src.Model.HttpModels.Response;

namespace backendOrkletti.src.ValueObjects.Mapping;

public static class MappingConfig {
	public static MapperConfiguration RegisterMaps() {
		var mappingCong = new MapperConfiguration(config => {
			config.CreateMap<PostRequest, Post>();
			config.CreateMap<Post, PostResponse>();
		});
		return mappingCong;
	}
}
