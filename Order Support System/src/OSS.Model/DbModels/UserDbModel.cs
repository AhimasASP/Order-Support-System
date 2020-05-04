using Microsoft.AspNetCore.Identity;
using OSS.Common;

namespace OSS.Domain.Common.Models.DbModels
{
	public class UserDbModel : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public string Photo { get; set; }
        public string CreationDate { get; set; }
        public string ModificationDate { get; set; }
		public bool IsDeleted { get; set; }
	}
}