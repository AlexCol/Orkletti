using backendOrkletti.src.Extensions.toFluntNotifications;
using backendOrkletti.src.Model.Error;
using backendOrkletti.src.Model.HttpModels.Request;
using backendOrkletti.src.Services.PostService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backendOrkletti.src.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PostController : ControllerBase {
	private IPostService _service;
	public PostController(IPostService service) {
		_service = service;
	}

	[HttpPost("new")]
	public IActionResult Post([FromForm] PostRequest request) {
		request.Validate();
		if (!request.IsValid) return BadRequest(new ErrorModel(request.Notifications.convertToEnumerable()));
		try {
			_service.Create(request);
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
		return Ok("Post criado!");
	}

	[HttpDelete("{idToDelete}")]
	public IActionResult Delete(string idToDelete) {
		try {
			var requestUserIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");
			if (requestUserIdClaim == null) return BadRequest("Erro para encontrar o usuário logado.");
			var requestUserId = requestUserIdClaim.Value;

			var post = _service.FindById(new Guid(idToDelete));
			if (post.CreatedBy.ToString() != requestUserId.ToString()) return BadRequest("Esse post não é seu para deletar!");

			_service.Delete(new Guid(idToDelete));
			return Ok(post);
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
	}

	[HttpPost("like")]
	public IActionResult Like([FromBody] LikeDislikeRequest request) {
		try {
			_service.Like(request.postId, request.profileId);
			return Ok();
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
	}

	[HttpPost("dislike")]
	public IActionResult Dislike([FromBody] LikeDislikeRequest request) {
		try {
			_service.Dislike(request.postId, request.profileId);
			return Ok();
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
	}

}
