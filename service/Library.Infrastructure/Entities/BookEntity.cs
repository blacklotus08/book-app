using Library.Infrastructure.Classes;
using Library.Infrastructure.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Infrastructure.Entities
{
    public class BookEntity : AuditableEntity, IBookEntity
    {
        public virtual string Title { get; set; } = string.Empty;
        public virtual string Author { get; set; } = string.Empty;
        public virtual string Isbn { get; set; } = string.Empty;
        [DataType(DataType.DateTime)]
        public virtual DateTime PublishedDate { get; set; }

    }
}
