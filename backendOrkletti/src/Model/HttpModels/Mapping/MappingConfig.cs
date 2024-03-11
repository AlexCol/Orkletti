
using backendOrkletti.src.Model.Entity;
using backendOrkletti.src.Model.HttpModels.Request;
using backendOrkletti.src.Model.HttpModels.Response;

namespace backendOrkletti.src.ValueObjects.Mapping;

public static class MappingConfig {
	public static AutoMapper.MapperConfiguration RegisterMaps() {
		var mappingCong = new AutoMapper.MapperConfiguration(config => {
			config.CreateMap<PostRequest, Post>()
				.ForMember(dest => dest.Topic, opt => opt.MapFrom(src => new Topic { Id = src.Topic }))
				.ForMember(dest => dest.Profile, opt => opt.MapFrom(src => new Profile { Id = src.Profile }))
				.ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => new Profile { Id = src.CreatedBy }))
				.ForMember(dest => dest.AttachmentFile, opt => opt.MapFrom(src => ConvertIFormFileToByteArray(src.Attachment)))
				.ForMember(dest => dest.AttachmentName, opt => opt.MapFrom(src => src.Attachment.FileName));

			config.CreateMap<Post, PostResponse>()
				.ForMember(dest => dest.Topic, opt => opt.MapFrom(src => src.Topic.Id))
				.ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile.Id))
				.ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy.Id));
		});
		return mappingCong;
	}

	private static string ConvertIFormFileToByteArray(IFormFile attachment) {
		using (var memoryStream = new MemoryStream()) {
			attachment.CopyTo(memoryStream);
			byte[] bytes = memoryStream.ToArray();
			return Convert.ToBase64String(bytes);
		}
	}
}