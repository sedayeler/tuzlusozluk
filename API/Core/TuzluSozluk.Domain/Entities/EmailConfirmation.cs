using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuzluSozluk.Domain.Entities.Common;

namespace TuzluSozluk.Domain.Entities
{
    public class EmailConfirmation : BaseEntity
    {
        public string OldEmail { get; set; }
        public string NewEmail { get; set; }
    }
}
