using System.ComponentModel.DataAnnotations;

namespace Library.Application.PayloadModel
{
    public class BookPayloadModel
    {
        [Required]
        public virtual string Title { get; set; } = string.Empty;
        [Required]
        public virtual string Author { get; set; } = string.Empty;
        [Required]
        public virtual string Isbn { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public virtual DateTime PublishedDate { get; set; }

    }
}
