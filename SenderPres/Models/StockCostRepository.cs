using SenderPresentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenderPres.Models
{
    public class StockCostRepository
    {
        StockContext context;

        public StockCostRepository()
        {
            context = new StockContext();
        }

        public List<StockCost> GetRecentCosts(int stockId)
        {
            var count = context.StockCosts.Count();

            if (count > 20)
            {
                var stockCostList = context.StockCosts.Where(sc => sc.StockId == stockId)
                    .Take(20)
                    .ToList();
                stockCostList.Reverse();
                return stockCostList;
            }
            else
            {
                return context.StockCosts.Where(sc => sc.StockId == stockId)
                    .ToList();
            }
        }


    }
}