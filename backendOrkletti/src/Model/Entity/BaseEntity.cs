using System.ComponentModel.DataAnnotations;

namespace backendOrkletti.src.Model.Entity;

public class BaseEntity {
	[Key]
	public Guid Id { get; set; }
}
