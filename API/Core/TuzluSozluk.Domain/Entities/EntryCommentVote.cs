using TuzluSozluk.Common.Entities;
using TuzluSozluk.Domain.Entities.Common;

namespace TuzluSozluk.Domain.Entities
{
    public class EntryCommentVote : BaseEntity
    {
        public VoteType VoteType { get; set; }
        public Guid EntryCommenyId { get; set; }
        public virtual EntryComment EntryComment { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}