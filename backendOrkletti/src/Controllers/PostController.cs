using backendOrkletti.src.Extensions.toClaims;
using backendOrkletti.src.Extensions.toFluntNotifications;
using backendOrkletti.src.Model.Error;
using backendOrkletti.src.Model.HttpModels.Request;
using backendOrkletti.src.Services.PostService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Npgsql.Internal;
using Serilog;

namespace backendOrkletti.src.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PostController : ControllerBase {
	private IPostService _service;
	public PostController(IPostService service) {
		_service = service;
	}

	[HttpGet("topic/{topicId}")]
	public IActionResult FindByTopic(string topicId) {
		try {
			return Ok(_service.FindByTopicId(Guid.Parse(topicId)));
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
	}

	[HttpGet("profile/{profileId}")]
	public IActionResult FindByProfile(string profileId) {
		try {
			return Ok(_service.FindByProfileId(Guid.Parse(profileId)));
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
	}

	[HttpGet("file/{postId}")]
	public async Task<IActionResult> FileFromPost(string postId) {
		try {
			var base64File = _service.GetFileFromPost(Guid.Parse(postId));
			var file = Convert.FromBase64String(base64File);
			Log.Error(file.Length.ToString());
			if (file != null) {
				HttpContext.Response.StatusCode = 200;
				HttpContext.Response.Headers.Append("content-length", file.Length.ToString());
				await HttpContext.Response.Body.WriteAsync(file, 0, file.Length);
			}
			return null; //return null because the response is written above, so any return is ignored
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
	}

	[HttpPost("new")]
	public IActionResult Post([FromForm] PostRequest request) {
		var userRequest = User.Claims.GetUser();
		if (userRequest == null) return BadRequest("Erro para encontrar o usuário logado.");
		request.CreatedBy = userRequest.Id;

		request.ValidateCreation();
		if (!request.IsValid) return BadRequest(new ErrorModel(request.Notifications.convertToEnumerable()));
		try {
			_service.Create(request);
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
		return Ok("Post criado!");
	}

	[HttpPost("like/{postId}")]
	public IActionResult Like(string postId) {
		try {
			var userRequest = User.Claims.GetUser();
			_service.Like(Guid.Parse(postId), userRequest.Id);
			return Ok();
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
	}

	[HttpPost("dislike/{postId}")]
	public IActionResult Dislike(string postId) {
		try {
			var userRequest = User.Claims.GetUser();
			_service.Dislike(Guid.Parse(postId), userRequest.Id);
			return Ok();
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
	}

	[HttpPut("{postId}")]
	public IActionResult Update([FromForm] PostRequest request, string postId) {
		var userRequest = User.Claims.GetUser();
		if (userRequest == null) return BadRequest("Erro para encontrar o usuário logado.");
		request.ValidateUpdate();
		if (!request.IsValid) return BadRequest(new ErrorModel(request.Notifications.convertToEnumerable()));

		var post = _service.FindById(new Guid(postId));
		if (post.CreatedBy.ToString() != userRequest.Id.ToString()) return BadRequest("Esse post não é seu para editar!");

		try {
			_service.Update(Guid.Parse(postId), request);
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
		return Ok("Post atualizado!");
	}

	[HttpDelete("{idToDelete}")]
	public IActionResult Delete(string idToDelete) {
		try {
			var userRequest = User.Claims.GetUser();
			if (userRequest == null) return BadRequest("Erro para encontrar o usuário logado.");

			var post = _service.FindById(new Guid(idToDelete));
			if (post.CreatedBy.ToString() != userRequest.Id.ToString()) return BadRequest("Esse post não é seu para deletar!");

			_service.Delete(new Guid(idToDelete));
			return NoContent();
		} catch (Exception e) {
			return BadRequest(new ErrorModel(e.Message));
		}
	}
}
