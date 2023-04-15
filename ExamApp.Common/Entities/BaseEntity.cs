namespace ExamApp.Common.Entities
{
    public abstract class BaseEntity:IBaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual DateTime? UpdatedAt { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
    }
}