using System;

namespace Infrastructure.Persistence.Entities.Log
{
    public class PersonEntity : BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DNI { get; set; }
        public bool IsDeleted { get; set; }
    }
}
