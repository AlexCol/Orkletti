using Microsoft.CodeAnalysis.CSharp.Syntax;
using Serilog;

namespace backendOrkletti.src.Extensions.toString;

public static class FileValidations {

	public static bool ValidateBase64FileSize(this string file, long maxSize) {
		int size = file.Length;
		size -= file.Count(c => c == '=');
		var result = (long)Math.Ceiling(size * 3 / 4.0);

		bool isSizeOk = result <= maxSize * 1024 * 1024;
		return isSizeOk;
	}


	public static bool ValidatePermittedExtensions(this string fileName, string allowedExtensions) {
		var pos = fileName.LastIndexOf('.');
		var isOk = allowedExtensions.Contains(fileName.Substring(pos));
		return isOk;
	}
}



/*
            fileType.ToLower() == ".pdf"
            || fileType.ToLower() == ".jpg"
            || fileType.ToLower() == ".png"
            || fileType.ToLower() == ".jpeg"
            || fileType.ToLower() == ".rar"
            || fileType.ToLower() == ".zip"
*/