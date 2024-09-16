using System.ComponentModel.DataAnnotations;

namespace Library.Application.PayloadModel
{
    public class Book
    {   
        public virtual string? Title { get; set; } = string.Empty;
        public virtual string? Author { get; set; } = string.Empty;
        public virtual string? Isbn { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public virtual DateTime? PublishedDate { get; set; }

    }
}
