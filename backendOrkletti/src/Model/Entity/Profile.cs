using System.ComponentModel.DataAnnotations.Schema;
using backendOrkletti.src.Model.Entity.Base;

namespace backendOrkletti.src.Model.Entity;

[Table("profile")]
public class Profile : BaseEntity {
	[Column("ds_fistname")]
	public string FirstName { get; set; }
	[Column("ds_lastname")]
	public string LastName { get; set; }
	[Column("bl_profileimage")]
	public byte[] ProfileImage { get; set; }
	[Column("ds_bio")]
	public string Bio { get; set; }
}
