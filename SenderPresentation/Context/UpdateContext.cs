using SenderPresentation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SenderPresentation.Context
{
    public class UpdateContext : DbContext
    {
        public DbSet<Update> StockTableSender { get; set; }
    }

}
