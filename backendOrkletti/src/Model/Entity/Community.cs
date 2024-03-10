using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendOrkletti.src.Model.Entity;

[Table("community")]
public class Community : BaseEntity {
	[Column("ds_title")]
	public string Tittle { get; set; }

	[Column("bl_image")]
	public byte[] Image { get; set; }

	[Column("ds_description")]
	public string Description { get; set; }

	[Column("cd_created_by")]
	public Profile CreatedBy { get; set; }

	[Column("dt_created_at")]
	public DateTime CreatedAt { get; set; }
}
