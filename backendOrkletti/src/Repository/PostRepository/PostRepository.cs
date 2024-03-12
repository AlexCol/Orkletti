
using backendOrkletti.src.Model;
using backendOrkletti.src.Model.Entity;
using backendOrkletti.src.Model.HttpModels.Request;
using backendOrkletti.src.Model.HttpModels.Response;
using backendOrkletti.src.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace backendOrkletti.src.Repository.PostRepository;

public class PostRepository : GenericRepository<Post>, IPostRepository {

	private readonly PostgreContext _context;

	public PostRepository(PostgreContext context) : base(context) {
		_context = context;
	}

	public override Post FindById(Guid id) {
		return _context.Posts
										.Include(p => p.Profile)
										.Include(p => p.CreatedBy)
										.Include(p => p.Topic)
										.FirstOrDefault(p => p.Id == id);
	}

	public override Post Create(Post postRequest) {
		var profile = _context.Profiles.FirstOrDefault(p => p.Id == postRequest.Profile.Id);
		var createdBy = _context.Profiles.FirstOrDefault(p => p.Id == postRequest.CreatedBy.Id);
		var topic = _context.Topics
												.Include(t => t.Community)
												.Include(t => t.CreatedBy)
												.FirstOrDefault(t => t.Id == postRequest.Topic.Id);

		var newPost = new Post {
			Profile = profile,
			Topic = topic,
			AttachmentName = postRequest.AttachmentName,
			AttachmentFile = postRequest.AttachmentFile,
			CreatedBy = createdBy,
			Body = postRequest.Body
		};
		_context.Posts.Add(newPost);
		_context.SaveChanges();
		return newPost;
	}

	public void Like(Guid postId, Guid profileId) {
		LikeOrDislike(postId, profileId, true);
	}

	public void Dislike(Guid postId, Guid profileId) {
		LikeOrDislike(postId, profileId, false);
	}

	public List<Post> FindByProfileId(Guid profileId) {
		return _context.Posts
			.Include(t => t.Profile)
			.Include(t => t.CreatedBy)
			.Where(p => p.Profile.Id == profileId).ToList();
	}

	public List<Post> FindByTopicId(Guid topicId) {
		return _context.Posts
			.Include(t => t.Topic)
			.Include(t => t.CreatedBy)
			.Where(p => p.Topic.Id == topicId).ToList();
	}


	//!funções auxiliares privadas ////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
				var post = _context.Posts.FirstOrDefault(p => p.Id == postId);
				var profile = _context.Profiles.FirstOrDefault(p => p.Id == profileId);
				if (post == null || profile == null) throw new Exception("Post ou perfil não encontrados!");
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
