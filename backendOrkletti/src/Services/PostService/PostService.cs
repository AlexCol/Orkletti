using AutoMapper;
using backendOrkletti.src.Extensions.toEntities;
using backendOrkletti.src.Extensions.toString;
using backendOrkletti.src.Model.Entity;
using backendOrkletti.src.Model.HttpModels.Request;
using backendOrkletti.src.Model.HttpModels.Response;
using backendOrkletti.src.Repository.PostRepository;
using Serilog;

namespace backendOrkletti.src.Services.PostService;

public class PostService : IPostService {

	private readonly IPostRepository _repo;
	private readonly IMapper _mapper;
	private readonly IConfiguration _config;
	public PostService(IPostRepository repo, IMapper mapper, IConfiguration config) {
		_repo = repo;
		_mapper = mapper;
		_config = config;
	}

	public PostResponse FindById(Guid postId) {
		var post = _repo.FindById(postId);
		if (post == null) throw new Exception("Post não encontrado!");

		return _mapper.Map<PostResponse>(post);
	}

	public List<PostResponse> FindByProfileId(Guid profileId) {
		return _mapper.Map<List<PostResponse>>(_repo.FindByProfileId(profileId));
	}

	public List<PostResponse> FindByTopicId(Guid topicId) {
		return _mapper.Map<List<PostResponse>>(_repo.FindByTopicId(topicId));
	}

	public PostResponse Create(PostRequest newPost) {
		var post = _mapper.Map<Post>(newPost);
		post.ValidateFile(_config); //throws exception in case of error
		return _mapper.Map<PostResponse>(_repo.Create(post));
	}

	public PostResponse Update(Guid postId, PostRequest editPost) {
		var post = _repo.FindById(postId);
		if (post == null) throw new Exception("Post não encontrado!");

		var editPostConverted = _mapper.Map<Post>(editPost);

		if (post.Body != editPostConverted.Body) post.Body = editPost.Body;
		if (post.AttachmentFile != editPostConverted.AttachmentFile) post.AttachmentFile = editPostConverted.AttachmentFile;
		if (post.AttachmentName != editPostConverted.AttachmentName) post.AttachmentName = editPostConverted.AttachmentName;

		return _mapper.Map<PostResponse>(_repo.Update(post));
	}

	public void Delete(Guid postId) {
		_repo.Delete(postId);
	}

	public void Like(Guid postId, Guid profileId) {
		_repo.Like(postId, profileId);
	}

	public void Dislike(Guid postId, Guid profileId) {
		_repo.Dislike(postId, profileId);
	}
}
