using Pukimoni.Domain.Interfaces;
using System.Collections.Generic;

namespace Pukimoni.Api.Core
{
    public class JwtUser : IApplicationUser
    {
        public string Identity { get; set; }
        public int Id { get; set; }
        public IEnumerable<int> PermissionIds { get; set; } = new List<int>();
        public string Email { get; set; }
    }

    public class StarterUser : IApplicationUser
    {
        public string Identity => "Anon";

        public int Id => 0;

        public IEnumerable<int> PermissionIds => new List<int> { 20 };

        public string Email => "pukiAnon@gmail.com";
    }
}
