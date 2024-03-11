using backendOrkletti.src.Model.Error;
using backendOrkletti.src.Model.HttpModels.Request;
using backendOrkletti.src.Repository.PostRepository;
using backendOrkletti.src.Services.PostService;
using Microsoft.AspNetCore.Mvc;

namespace backendOrkletti.src.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase {
	private IPostService _service;
	public PostController(IPostService service) {
		_service = service;
	}

	[HttpPost("like")]
	public IActionResult like([FromBody] LikeDislikeRequest request) {
		try {
			_service.Like(request.postId, request.profileId);
			return Ok("Like realizado!");
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
	}

	[HttpPost("dislike")]
	public IActionResult dislike([FromBody] LikeDislikeRequest request) {
		try {
			_service.Dislike(request.postId, request.profileId);
			return Ok("Dislike realizado!");
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
	}

}
