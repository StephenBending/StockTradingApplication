using SenderPresentation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SenderPres.Models
{
    public class StockContext: DbContext
    {
    
            public StockContext()
                : base("stocksConn")
            {

            }

            public DbSet<StockCost> StockCosts { get; set; }
    }
}