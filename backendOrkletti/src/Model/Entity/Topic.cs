using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendOrkletti.src.Model.Entity;

[Table("topic")]
public class Topic {
	[Key]
	[Column("cd_topic")]
	public Guid Id { get; set; }

	[Column("ds_title")]
	public string Tittle { get; set; }

	[Column("cd_community")]
	public Community Community { get; set; }

	[Column("cd_created_by")]
	public Profile CreatedBy { get; set; }

	[Column("dt_created_at")]
	public DateTime CreatedAt { get; set; }
}
