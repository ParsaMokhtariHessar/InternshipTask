using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipTask.Application.ApplicationModels.Identity
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
