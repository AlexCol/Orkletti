using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendOrkletti.src.Model.Entity;

[Table("post")]
public class Post {
	[Key]
	[Column("cd_post")]
	public Guid Id { get; set; }

	[Column("ds_post_body")]
	public string Body { get; set; }

	[Column("bl_post_attachment")]
	public byte[] Attachment { get; set; }

	[Column("nr_likes")]
	public int Likes { get; set; }

	[Column("nr_dislikes")]
	public int Dislikes { get; set; }

	[Column("cd_topic")]
	public Topic Topic { get; set; }

	[Column("cd_profile")]
	public Profile Profile { get; set; }

	[Column("cd_created_by")]
	public Profile CreatedBy { get; set; }

	[Column("dt_created_at")]
	public DateTime CreatedAt { get; set; }
}
