﻿using PsychApp.Library.Classes.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PsychApp.Library.Classes
{
    public class AuditableEntity : DefaultEntity, IAuditableEntity
    {
        [Required]
        [DataType(DataType.DateTime)]
        [JsonIgnore]
        public DateTime CreatedDateTimeUtc { get; set; } = DateTime.UtcNow;
        [Required]
        [JsonIgnore]
        public Guid CreatedById { get; set; }
        [JsonIgnore]
        public DateTime? LastModifiedDateTimeUtc { get; set; }
        [JsonIgnore]
        public Guid? LastModifiedById { get; set; }
        [JsonIgnore]
        public DateTime? DeletedDateTimeUtc { get; set; }
        [JsonIgnore]
        public Guid? DeletedById { get; set; }
        [JsonIgnore]
        public virtual bool IsDeleted
        {
            get
            {
                return DeletedById != null;
            }
        }
        [JsonIgnore]
        public override DateTime tstamp { get => base.tstamp; set => base.tstamp = value; }
        //[JsonIgnore]
        //public override byte[] RowVersion { get => base.RowVersion; set => base.RowVersion = value; }
    }
}
