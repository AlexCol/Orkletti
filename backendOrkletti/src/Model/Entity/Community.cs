using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendOrkletti.src.Model.Entity;

[Table("community")]
public class Community {
	[Key]
	[Column("cd_community")]
	public Guid Id { get; set; }

	[Column("ds_title")]
	public string Tittle { get; set; }

	[Column("bl_image")]
	public byte[] Image { get; set; }

	[Column("ds_description")]
	public string Description { get; set; }

	[Column("cd_user_code")]
	public Profile Profile { get; set; }

	[Column("dt_createdAt")]
	public DateTime CreatedAt { get; set; }
}
