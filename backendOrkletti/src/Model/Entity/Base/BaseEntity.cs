using System.ComponentModel.DataAnnotations;

namespace backendOrkletti.src.Model.Entity.Base;

public class BaseEntity {
	[Key]
	public Guid Id { get; set; }
}
