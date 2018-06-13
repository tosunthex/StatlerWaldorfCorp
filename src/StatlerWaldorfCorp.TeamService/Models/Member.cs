using System;

namespace StatlerWaldorfCorp.TeamService.Models
{
    public class Member
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Member()
        {
            
        }

        public Member(Guid id):this()
        {
            this.Id = id;
        }

        public override string ToString()
        {
            return this.LastName;
        }
    }
}