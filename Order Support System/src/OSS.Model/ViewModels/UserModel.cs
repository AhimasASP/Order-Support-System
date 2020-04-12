using OSS.Common;
using OSS.Domain.Models.ApiModels;

namespace OSS.Domain.Common.Models.ApiModels
{
	public class UserModel : BaseModel
	{

		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public string Photo { get; set; }
	}
}