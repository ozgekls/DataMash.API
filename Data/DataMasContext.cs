using Microsoft.EntityFrameworkCore;
using DataMash.API.Models;

namespace DataMash.API.Data
{
    public class DataMashContext : DbContext
    {
        public DataMashContext(DbContextOptions<DataMashContext> options) : base(options) {}

        public DbSet<StressRecord> StressRecords { get; set; }
    }
}
