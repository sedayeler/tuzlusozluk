using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuzluSozluk.Application.Repositories;
using TuzluSozluk.Domain.Entities;
using TuzluSozluk.Persistence.Contexts;

namespace TuzluSozluk.Persistence.Repositories
{
    public class EntryVoteRepository : GenericRepository<EntryVote>, IEntryVoteRepository
    {
        public EntryVoteRepository(TuzluSozlukContext context) : base(context)
        {
        }
    }
}
