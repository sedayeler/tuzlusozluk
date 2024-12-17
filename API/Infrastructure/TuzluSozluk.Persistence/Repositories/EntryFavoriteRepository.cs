﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuzluSozluk.Application.Repositories;
using TuzluSozluk.Domain.Entities;
using TuzluSozluk.Persistence.Contexts;

namespace TuzluSozluk.Persistence.Repositories
{
    public class EntryFavoriteRepository : GenericRepository<EntryFavorite>, IEntryFavoriteRepository
    {
        public EntryFavoriteRepository(TuzluSozlukContext context) : base(context)
        {
        }
    }
}
