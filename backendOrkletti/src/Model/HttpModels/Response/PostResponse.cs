using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendOrkletti.src.Model.HttpModels.Response;

public class PostResponse {
	public string Body { get; set; }
	public byte[] Attachment { get; set; }
	public Guid Topic { get; set; }
	public Guid Profile { get; set; }
	public Guid CreatedBy { get; set; }
}
