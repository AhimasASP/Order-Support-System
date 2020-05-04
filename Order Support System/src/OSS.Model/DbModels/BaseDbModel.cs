
using System;

namespace OSS.Domain.Common.Models.DbModels
{
	public abstract class BaseDbModel
	{
		public Guid Id { get; set; }
        public string CreationDate { get; set; }
        public string ModificationDate { get; set; }
        public bool IsDeleted { get; set; }
	}
}