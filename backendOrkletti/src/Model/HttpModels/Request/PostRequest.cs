using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace backendOrkletti.src.Model.HttpModels.Request;

public class PostRequest : Notifiable<Notification> {
	public PostRequest() { Validate(); }

	public string Body { get; set; }
	public byte[] Attachment { get; set; }
	public Guid Topic { get; set; }
	public Guid Profile { get; set; }
	public Guid CreatedBy { get; set; }

	public void Validate() {
		Clear();
		var contract = new Contract<PostRequest>()
			.IsNotNullOrWhiteSpace(Body, "Mensagem", "Mensagem precisa estar preenchida.")
			.IsGreaterOrEqualsThan(Body, 10, "Mensagem", "Mensagem deve ter pelo menos 10 caracteres.");
		AddNotifications(contract);
	}
}
