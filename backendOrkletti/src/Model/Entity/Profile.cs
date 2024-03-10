using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendOrkletti.src.Model.Entity;

[Table("profile")]
public class Profile {
	[Key]
	[Column("cd_profile")]
	public string Id { get; set; }

	[Column("ds_fist_name")]
	public string FirstName { get; set; }

	[Column("ds_last_name")]
	public string LastName { get; set; }

	[Column("bl_profile_image")]
	public byte[] ProfileImage { get; set; }

	[Column("ds_bio")]
	public string Bio { get; set; }
}
