using Bogus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuzluSozluk.Common;
using TuzluSozluk.Domain.Entities;

namespace TuzluSozluk.Persistence.Contexts
{
    public class SeedData
    {
        private static List<User> GetUsers()
        {
            var users = new Faker<User>()
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.CreatedAt, i => i.Date.Past(3, DateTime.UtcNow))
                .RuleFor(i => i.FirstName, i => i.Person.FirstName)
                .RuleFor(i => i.LastName, i => i.Person.LastName)
                .RuleFor(i => i.UserName, i => i.Internet.UserName())
                .RuleFor(i => i.Email, i => i.Internet.Email())
                .RuleFor(i => i.Password, i => PasswordEncryptor.Encrypt(i.Internet.Password()))
                .RuleFor(i => i.EmailConfirmed, i => i.PickRandom(true, false))
                .Generate(500);

            return users;
        }

        public async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var users = GetUsers();
            var userIds = users.Select(i => i.Id);

            var _context = serviceProvider.GetService<TuzluSozlukContext>();

            await _context.users.AddRangeAsync(users);

            var guids = Enumerable.Range(0, 150).Select(i => Guid.NewGuid()).ToList();
            int counter = 0;

            var entries = new Faker<Entry>()
                .RuleFor(i => i.Id, i => guids[counter++])
                .RuleFor(i => i.CreatedAt, i => i.Date.Past(3, DateTime.UtcNow))
                .RuleFor(i => i.Subject, i => i.Lorem.Sentence(5, 5))
                .RuleFor(i => i.Content, i => i.Lorem.Paragraphs(1, 3))
                .RuleFor(i => i.UserId, i => i.PickRandom(userIds))
                .Generate(150);

            await _context.entries.AddRangeAsync(entries);

            var comments = new Faker<EntryComment>()
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.CreatedAt, i => i.Date.Past(3, DateTime.UtcNow))
                .RuleFor(i => i.Content, i => i.Lorem.Paragraphs(1, 3))
                .RuleFor(i => i.EntryId, i => i.PickRandom(guids))
                .RuleFor(i => i.UserId, i => i.PickRandom(userIds))
                .Generate(1000);

            await _context.entry_comments.AddRangeAsync(comments);
            _context.SaveChanges();
        }
    }
}
