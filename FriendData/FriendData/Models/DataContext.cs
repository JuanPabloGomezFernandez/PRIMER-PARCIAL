using System.Data.Entity;

namespace FriendData.Models
{
    public class DataContext:DbContext

    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<FriendData.Models.PERSONALSTUFFS> PERSONALSTUFFS { get; set; }
    }
}