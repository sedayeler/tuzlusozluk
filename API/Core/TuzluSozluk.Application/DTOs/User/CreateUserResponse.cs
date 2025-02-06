using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuzluSozluk.Application.DTOs
{
    public class CreateUserResponse
    {
        public Guid UserId { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
