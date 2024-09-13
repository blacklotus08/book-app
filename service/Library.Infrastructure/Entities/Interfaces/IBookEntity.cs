namespace Library.Infrastructure.Entities.Interfaces
{
    public interface IBookEntity
    {
        string Title { get; set; }
        string Author { get; set; }
        string Isbn { get; set; }
        DateTime PublishedDate { get; set; }

    }
}
