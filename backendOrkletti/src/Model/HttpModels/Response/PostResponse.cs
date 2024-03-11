using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendOrkletti.src.Model.HttpModels.Response;

public class PostResponse {
	public Guid Id { get; set; }
	public string Body { get; set; }
	public string AttachmentName { get; set; }
	public string AttachmentFile { get; set; }
	public Guid Topic { get; set; }
	public Guid Profile { get; set; }
	public Guid CreatedBy { get; set; }
	public DateTime CreatedAt { get; set; }
}
