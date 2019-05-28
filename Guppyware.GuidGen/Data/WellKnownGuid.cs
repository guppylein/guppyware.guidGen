using System;

namespace Guppyware.GuidGen.Data
{
    public class WellKnownGuid
    {
        public WellKnownGuid(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
