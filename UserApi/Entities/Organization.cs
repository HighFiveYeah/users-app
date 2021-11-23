using System;

namespace UserApi.Entities
{
    public class Organization
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public User Owner { get; set; }
    }
}