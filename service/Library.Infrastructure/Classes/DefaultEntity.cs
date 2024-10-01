using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Infrastructures.Interfaces;

namespace Library.Infrastructure.Classes
{
    public abstract class DefaultEntity : IDefaultEntity
    {
        [Key]
        public virtual int Id { get; set; }
        [Column(TypeName = "TIMESTAMP")]
        [Timestamp]
        public virtual DateTime tstamp { get; set; } = DateTime.UtcNow;

    }
}
