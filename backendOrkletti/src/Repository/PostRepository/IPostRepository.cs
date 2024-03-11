using backendOrkletti.src.Model.Entity;
using backendOrkletti.src.Model.HttpModels.Request;
using backendOrkletti.src.Model.HttpModels.Response;
using backendOrkletti.src.Repository.GenericRepository;

namespace backendOrkletti.src.Repository.PostRepository;

public interface IPostRepository : IGenericRepository<Post> {
	public void Like(Guid postId, Guid profileId);
	public void Dislike(Guid postId, Guid profileId);
	public List<Post> FindByProfileId(Guid profileId);
	public List<Post> FindByTopicId(Guid topicId);
}
