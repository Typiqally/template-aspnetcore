namespace Typiqally.Persistence.Abstractions.Entities
{
	public interface IEntity<TKey> : IEntity
	{
		public new TKey Id { get; set; }
	}
}