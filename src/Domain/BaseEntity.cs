using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
public abstract class BaseEntity
    {
        private Guid _id;
        [Key]
        public Guid Id
        {
            get => _id;
            set => _id = value == Guid.Empty ? GenerateId() : value;
        }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        public BaseEntity()
        {
            _id = Guid.Empty;
        }

        protected virtual Guid GenerateId()
        {
            // Use a deterministic ID generation method
            var bytes = new byte[16];
            var typeName = GetType().Name;
            for (int i = 0; i < typeName.Length && i < 16; i++)
            {
                bytes[i] = (byte)typeName[i];
            }
            return new Guid(bytes);
        }

        public void TrackCreation(Guid? userId)
        {
            CreatedBy = userId;
            UpdatedBy = userId;
        }

        public void TrackUpdate(Guid? userId)
        {
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = userId;
        }
    }


    

