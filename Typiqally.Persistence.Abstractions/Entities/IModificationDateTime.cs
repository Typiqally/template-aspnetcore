using System;

namespace Typiqally.Persistence.Abstractions.Entities
{
	public interface IModificationDateTime
	{
		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }
	}
}