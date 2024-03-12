using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendOrkletti.src.Model.Entity;
using backendOrkletti.src.Model.HttpModels.Request;
using backendOrkletti.src.Model.HttpModels.Response;

namespace backendOrkletti.src.Services.PostService;

public interface IPostService {
	public PostResponse FindById(Guid postId);
	public List<PostResponse> FindByProfileId(Guid profileId);
	public List<PostResponse> FindByTopicId(Guid topicId);
	public PostResponse Create(PostRequest newPost);
	public PostResponse Update(Guid postId, PostRequest editPost);
	public void Delete(Guid postId);
	public void Like(Guid postId, Guid profileId);
	public void Dislike(Guid postId, Guid profileId);
	public string GetFileFromPost(Guid postId);
}
