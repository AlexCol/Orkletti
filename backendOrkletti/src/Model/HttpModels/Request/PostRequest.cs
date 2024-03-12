using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace backendOrkletti.src.Model.HttpModels.Request;

public class PostRequest : Notifiable<Notification> {
	public PostRequest() { ValidateCreation(); }

	public string Body { get; set; }
	public IFormFile Attachment { get; set; }
	public Guid Topic { get; set; }
	public Guid Profile { get; set; }
	public Guid CreatedBy { get; set; }
	public IFormFile File { get; set; }

	public void ValidateCreation() {
		Clear();
		var contract = new Contract<PostRequest>()
			.IsFalse(Topic.ToString() == "00000000-0000-0000-0000-000000000000" && Profile.ToString() == "00000000-0000-0000-0000-000000000000"
				, "Destino", "Obrigatório vinculo a um Topico ou Perfil.")
			.IsFalse(Topic.ToString() != "00000000-0000-0000-0000-000000000000" && Profile.ToString() != "00000000-0000-0000-0000-000000000000"
				, "Destino", "Apenas um vinculo pai permitido para o post.")
			.IsFalse(CreatedBy.ToString() == "00000000-0000-0000-0000-000000000000", "Criador", "Criador do post deve ser informado.")
			.IsNotNullOrWhiteSpace(Body, "Mensagem", "Mensagem precisa estar preenchida.")
			.IsGreaterOrEqualsThan(Body, 10, "Mensagem", "Mensagem deve ter pelo menos 10 caracteres.");
		AddNotifications(contract);
	}

	public void ValidateUpdate() {
		Clear();
		var contract = new Contract<PostRequest>()
			.IsNotNullOrWhiteSpace(Body, "Mensagem", "Mensagem precisa estar preenchida.")
			.IsGreaterOrEqualsThan(Body, 10, "Mensagem", "Mensagem deve ter pelo menos 10 caracteres.");
		AddNotifications(contract);
	}
}
