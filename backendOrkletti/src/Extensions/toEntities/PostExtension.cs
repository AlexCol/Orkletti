using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendOrkletti.src.Extensions.toString;
using backendOrkletti.src.Model.Entity;

namespace backendOrkletti.src.Extensions.toEntities;

public static class PostExtension {
	public static void ValidateFile(this Post post, IConfiguration _config) {
		var permittedExtensions = _config.GetValue<string>("FilePermits:Extensions");
		if (!post.AttachmentName.ValidatePermittedExtensions(permittedExtensions)) throw new Exception($"Permitidos apenas arquivos com as extensões {permittedExtensions}.");
		var maxSize = _config.GetValue<long>("FilePermits:SizeInMB");
		if (!post.AttachmentFile.ValidateBase64FileSize(maxSize)) throw new Exception($"Tamanho máximo é de {maxSize}MB por arquivo.");
	}
}
