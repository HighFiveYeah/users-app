using System;

namespace UserApi.Entities
{
    public class Site
    {
        public Guid Guid { get; set; }
        public Organization OwningOrganization { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
    }
}