namespace Product.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
