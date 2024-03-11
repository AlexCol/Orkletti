using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backendOrkletti.src.Model.Entity;

[Table("community_membership")]
public class ComunityMembership : BaseEntity {
	public Community Community { get; set; }
	public Profile Profile { get; set; }
}
