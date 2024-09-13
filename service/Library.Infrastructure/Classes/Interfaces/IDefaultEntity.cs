namespace Library.Infrastructures.Interfaces
{
    public interface IDefaultEntity
    {
        Guid Id { get; set; }

        DateTime tstamp { get; set; }
    }
}
