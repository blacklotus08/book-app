using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PsychApp.Library.Classes.Interfaces;

namespace PsychApp.Library.Classes
{
    public abstract class DefaultEntity : IDefaultEntity
    {
        [Key]
        public virtual Guid Id { get; set; }
        [Column(TypeName = "TIMESTAMP")]
        [Timestamp]
        public virtual DateTime tstamp { get; set; } = DateTime.UtcNow;

    }
}
