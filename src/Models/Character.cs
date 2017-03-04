using System;

namespace IEvangelist.Angular.Models
{
    public class Character
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string RealName { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Description { get; set; }
        public string Powers { get; set; }
        public string Abilities { get; set; }
    }
}