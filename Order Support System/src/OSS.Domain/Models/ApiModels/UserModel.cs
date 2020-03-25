using OSS.Domain.Models.ApiModels;

namespace OSS.Domain.Common.Models.ApiModels
{
	public class UserModel : BaseModel
	{

		public string Login { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }
        public string Photo { get; set; }
        public UserRoles Type { get; set; }
	}
}