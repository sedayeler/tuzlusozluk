﻿using TuzluSozluk.Domain.Entities.Common;

namespace TuzluSozluk.Domain.Entities
{
    public class EntryFavorite : BaseEntity
    {
        public Guid EntryId { get; set; }
        public virtual Entry Entry { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}