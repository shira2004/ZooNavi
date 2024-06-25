using System.Collections.Generic;

namespace Repository.Entities
{
    public enum ERole
    {
        ROLE_USER,
        ROLE_MODERATOR,
        ROLE_ADMIN
    }

    public class Role
    {
        public int Id { get; set; }
        public ERole RoleType { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
