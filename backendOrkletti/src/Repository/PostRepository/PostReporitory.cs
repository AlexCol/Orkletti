using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendOrkletti.src.Model;
using backendOrkletti.src.Model.Entity;
using backendOrkletti.src.Repository.GenericRepository;

namespace backendOrkletti.src.Repository.PostRepository;

public class PostReporitory : GenericRepository<Post>, IPostRepository {

	private readonly PostgreContext _context;
	public PostReporitory(PostgreContext context) : base(context) {
		_context = context;
	}

	public void like(Post postToUpdate) {

	}

	public void dislike(Post postToUpdate) {

	}

	public List<Post> getPostsFromProfileId(Guid profileId) {
		throw new NotImplementedException();
	}

	public List<Post> getPostsFromTopicId(Guid topicId) {
		throw new NotImplementedException();
	}

}
