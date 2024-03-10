using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backendOrkletti.src.Model.Entity;

[Table("like_dislike_control")]
public class LikeOrDislikeRegister : BaseEntity {

	[Column("cd_post")]
	public Post Post { get; set; }

	[Column("cd_profile")]
	public Profile Profile { get; set; }

	[Column("sn_liked")]
	public bool Liked { get; set; }

}
