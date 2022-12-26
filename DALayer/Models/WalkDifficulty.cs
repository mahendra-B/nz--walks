using System;
using System.Collections.Generic;

#nullable disable

namespace DALayer.models
{
    public partial class WalkDifficulty
    {
        public WalkDifficulty()
        {
            Walks = new HashSet<Walk>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Walk> Walks { get; set; }
    }
}
