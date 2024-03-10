using backendOrkletti.src.Model;
using backendOrkletti.src.Model.Entity;
using backendOrkletti.src.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace backendOrkletti.src.Repository.PostRepository;

public class PostRepository : GenericRepository<Post>, IPostRepository {

	private readonly PostgreContext _context;
	public PostRepository(PostgreContext context) : base(context) {
		_context = context;
	}

	public void like(Guid postId, Guid profileId, bool like = true) {
		using (var transaction = _context.Database.BeginTransaction()) {
			try {
				var post = _context.Posts.First(p => p.Id == postId);
				var profile = _context.Profiles.First(p => p.Id == profileId);
				var register = _context.LikeOrDislikeRegisters.FirstOrDefault(ldr => ldr.Post.Id == postId && ldr.Profile.Id == profileId);

				if (register != null) {
					updateExistingRegister(register, post, like);
				} else {
					createNewRegister(post, profile, like);
				}
				_context.SaveChanges();
			} catch (Exception e) {
				transaction.Rollback();
				throw new Exception(e.Message);
			}
			transaction.Commit();
		}
	}

	public void dislike(Guid postId, Guid profileId) {
		Log.Error("dislike");
		like(postId, profileId, false);
	}

	public List<Post> getPostsFromProfileId(Guid profileId) {
		throw new NotImplementedException();
	}

	public List<Post> getPostsFromTopicId(Guid topicId) {
		throw new NotImplementedException();
	}


	//!funções auxiliares privadas
	private void updateExistingRegister(LikeOrDislikeRegister register, Post post, bool likedOrNot) {
		if (register.Liked == likedOrNot) throw new Exception(likedOrNot ? "Já deu like no post!" : "Já deu dislike no post!");

		register.Liked = likedOrNot;
		if (likedOrNot) {
			post.Likes++;
			post.Dislikes--;
		} else {
			post.Likes--;
			post.Dislikes++;
		}
	}

	private void createNewRegister(Post post, Profile profile, bool likedOrNot) {
		var register = new LikeOrDislikeRegister {
			Liked = likedOrNot,
			Post = post,
			Profile = profile
		};

		if (likedOrNot)
			post.Likes++;
		else
			post.Dislikes++;

		_context.LikeOrDislikeRegisters.Add(register);
	}
}
