namespace PsychApp.Library.Classes.Interfaces
{
    public interface IAuditableEntity: IDefaultEntity
    {
        DateTime CreatedDateTimeUtc { get; set; }
        Guid CreatedById { get; set; }
        DateTime? LastModifiedDateTimeUtc { get; set; }  
        Guid? LastModifiedById { get; set; }
        DateTime? DeletedDateTimeUtc { get; set; }
        Guid? DeletedById { get;set;}
    }
}
