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

	public void Like(Guid postId, Guid profileId) {
		LikeOrDislike(postId, profileId, true);
	}

	public void Dislike(Guid postId, Guid profileId) {
		LikeOrDislike(postId, profileId, false);
	}

	public List<Post> GetPostsFromProfileId(Guid profileId) {
		return _context.Posts.Where(p => p.Profile.Id == profileId).ToList();
	}

	public List<Post> GetPostsFromTopicId(Guid topicId) {
		return _context.Posts.Where(p => p.Topic.Id == topicId).ToList();
	}


	//!funções auxiliares privadas
	private void LikeOrDislike(Guid postId, Guid profileId, bool likeOrDislike) {
		try {
			var register = _context.LikeOrDislikeRegisters
				.Include(ldr => ldr.Post)
				.Include(ldr => ldr.Profile)
				.FirstOrDefault(ldr => ldr.Post.Id == postId && ldr.Profile.Id == profileId);

			if (register != null) {
				if (register.Liked == likeOrDislike)
					deleteExistingRegister(register, likeOrDislike);
				else
					updateExistingRegister(register, likeOrDislike);
			} else {
				var post = _context.Posts.First(p => p.Id == postId);
				var profile = _context.Profiles.First(p => p.Id == profileId);
				createNewRegister(post, profile, likeOrDislike);
			}
			_context.SaveChanges();
		} catch (Exception e) {
			throw new Exception(e.Message);
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

	private void updateExistingRegister(LikeOrDislikeRegister register, bool likedOrNot) {
		if (register.Liked == likedOrNot) throw new Exception(likedOrNot ? "Já deu like no post!" : "Já deu dislike no post!");

		register.Liked = likedOrNot;
		if (likedOrNot) {
			register.Post.Likes++;
			register.Post.Dislikes--;
		} else {
			register.Post.Likes--;
			register.Post.Dislikes++;
		}
	}

	private void deleteExistingRegister(LikeOrDislikeRegister register, bool likeOrDislike) {
		if (likeOrDislike) {
			register.Post.Likes--;
		} else {
			register.Post.Dislikes--;
		}

		_context.LikeOrDislikeRegisters.Remove(register);
	}

}
