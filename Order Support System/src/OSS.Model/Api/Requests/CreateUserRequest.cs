using OSS.Common;

namespace OSS.Domain.Common.Models.Api.Requests
{
	public class CreateUserRequest
	{
		public string Login { get; set; }

		public string Password { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }
        public string Photo { get; set; }
        public UserRoles Role { get; set; }
	}
}