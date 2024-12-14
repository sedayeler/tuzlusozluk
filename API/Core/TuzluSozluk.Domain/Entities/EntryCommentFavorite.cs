using TuzluSozluk.Domain.Entities.Common;

namespace TuzluSozluk.Domain.Entities
{
    public class EntryCommentFavorite : BaseEntity
    {
        public Guid EntryCommentId { get; set; }
        public virtual EntryComment EntryComment { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}