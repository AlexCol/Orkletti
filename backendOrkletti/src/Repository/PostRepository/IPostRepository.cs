using backendOrkletti.src.Model.Entity;
using backendOrkletti.src.Repository.GenericRepository;

namespace backendOrkletti.src.Repository.PostRepository;

public interface IPostRepository : IGenericRepository<Post> {
	public void like(Guid postId, Guid profileId, bool like = true);
	public void dislike(Guid postId, Guid profileId);
	public List<Post> getPostsFromProfileId(Guid profileId);
	public List<Post> getPostsFromTopicId(Guid topicId);
}
