using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backendOrkletti.src.Extensions.toFluntNotifications;
using backendOrkletti.src.Model.Entity;
using backendOrkletti.src.Model.Error;
using backendOrkletti.src.Model.HttpModels.Request;
using backendOrkletti.src.Model.HttpModels.Response;
using backendOrkletti.src.Repository.PostRepository;

namespace backendOrkletti.src.Services.PostService;

public class PostService : IPostService {

	private readonly IPostRepository _repo;
	private readonly IMapper _mapper;
	public PostService(IPostRepository repo, IMapper mapper) {
		_repo = repo;
		_mapper = mapper;
	}

	public PostResponse GetById(Guid postId) {
		var post = _repo.FindById(postId);
		if (post == null) throw new Exception("Post não encontrado!");

		return _mapper.Map<PostResponse>(post);
	}

	public List<PostResponse> GetPostsFromProfileId(Guid profileId) {
		return _mapper.Map<List<PostResponse>>(_repo.GetPostsFromProfileId(profileId));
	}

	public List<PostResponse> GetPostsFromTopicId(Guid topicId) {
		return _mapper.Map<List<PostResponse>>(_repo.GetPostsFromTopicId(topicId));
	}

	public PostResponse Create(PostRequest newPost) {
		var post = _mapper.Map<Post>(newPost);
		return _mapper.Map<PostResponse>(_repo.Update(post));
	}

	public PostResponse Edit(Guid postId, PostRequest editPost) {
		var post = _repo.FindById(postId);
		if (post == null) throw new Exception("Post não encontrado!");

		if (post.Body != editPost.Body) post.Body = editPost.Body;
		if (post.Attachment != editPost.Attachment) post.Attachment = editPost.Attachment;

		return _mapper.Map<PostResponse>(_repo.Update(post));
	}

	public void Delete(Guid postId) {
		var post = _repo.FindById(postId);
		if (post == null) throw new Exception("Post não encontrado!");

		_repo.Delete(postId);
	}

	public void Like(Guid postId, Guid profileId) {
		_repo.Like(postId, profileId);
	}

	public void Dislike(Guid postId, Guid profileId) {
		_repo.Dislike(postId, profileId);
	}
}
