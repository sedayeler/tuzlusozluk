using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuzluSozluk.Application.Services
{
    public interface IUserService
    {
        Task<string> LoginAsync(string email, string password);
    }
}
