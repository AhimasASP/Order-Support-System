
using System;

namespace OSS.Domain.Common.Models.DbModels
{
	public abstract class BaseDbModel
	{
		public Guid Id { get; set; }
        public string CreationTime { get; set; }
        public string ModificationTime { get; set; }
        public bool IsDeleted { get; set; }
	}
}