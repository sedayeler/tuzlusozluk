using TuzluSozluk.Common.Entities;
using TuzluSozluk.Domain.Entities.Common;

namespace TuzluSozluk.Domain.Entities
{
    public class EntryVote : BaseEntity
    {
        public VoteType VoteType { get; set; }
        public Guid EntryId { get; set; }
        public virtual Entry Entry { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}