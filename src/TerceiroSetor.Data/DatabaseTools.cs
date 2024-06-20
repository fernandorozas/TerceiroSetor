using Microsoft.EntityFrameworkCore;

namespace TerceiroSetor.Data
{
    public static class DatabaseTools
    {
        public static void CheckDatabase(DbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
