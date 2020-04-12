using OSS.Common;

namespace OSS.Domain.Common.Models.Api.Requests
{
    public class UpdateUserRequest
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
    }
}