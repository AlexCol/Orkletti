using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendOrkletti.src.Model.Entity;
using backendOrkletti.src.Repository.GenericRepository;

namespace backendOrkletti.src.Repository.PostRepository;

public interface IPostRepository : IGenericRepository<Post> {
	public void like(Post postToUpdate);
	public void dislike(Post postToUpdate);
	public List<Post> getPostsFromProfileId(Guid profileId);
	public List<Post> getPostsFromTopicId(Guid topicId);
}
