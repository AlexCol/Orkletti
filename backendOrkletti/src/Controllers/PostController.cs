using backendOrkletti.src.HttpModels.Request;
using backendOrkletti.src.Model.Error;
using backendOrkletti.src.Repository.PostRepository;
using Microsoft.AspNetCore.Mvc;

namespace backendOrkletti.src.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase {
	private IPostRepository _repo;
	public PostController(IPostRepository repo) {
		_repo = repo;
	}

	[HttpPost("like")]
	public IActionResult like([FromBody] LikeDislikeRequest request) {
		try {
			_repo.like(request.postId, request.profileId);
			return Ok("Like realizado!");
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
	}

	[HttpPost("dislike")]
	public IActionResult dislike([FromBody] LikeDislikeRequest request) {
		try {
			_repo.dislike(request.postId, request.profileId);
			return Ok("Dislike realizado!");
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
	}

}
