using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuzluSozluk.Domain.Entities;

namespace TuzluSozluk.Application.Services
{
    public interface ITokenService
    {
        string CreateToken(int minute, User user);
    }
}
