using System.Security.Claims;
using backendOrkletti.src.Model.HttpModels.Request;

namespace backendOrkletti.src.Extensions.toClaims;

public static class ClaimsExtension {
	public static UserRequest GetUser(this IEnumerable<Claim> claims) {
		var requestUserIdClaim = claims.FirstOrDefault(c => c.Type == "UserId");
		var requestUserNameClaim = claims.FirstOrDefault(c => c.Type == "UserName");
		var requestUserEMailClaim = claims.FirstOrDefault(c => c.Type == "UserEMail");
		if (requestUserIdClaim == null || requestUserNameClaim == null || requestUserEMailClaim == null) return null;

		return new UserRequest {
			Id = Guid.Parse(requestUserIdClaim.Value),
			Name = requestUserNameClaim.Value,
			Email = requestUserEMailClaim.Value
		};
	}
}
