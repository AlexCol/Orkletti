using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendOrkletti.src.Model.HttpModels.Request;

public class LikeDislikeRequest {
	public Guid postId { get; set; }
	public Guid profileId { get; set; }
}
