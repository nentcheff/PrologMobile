namespace PrologMobile;

public static class Aggregator
{
    public static IEnumerable<Category> Aggregate(IList<Record> records)
    {
        IEnumerable<IGrouping<string?, Record>> v = records.Where(x => x.Quantity != 0).GroupBy(x => x.Category);
        IEnumerable<Category> result = v.Select(g => new Category
		 {
			 CategoryName = g.Key,
			 TotalInventoryValue = g.Sum(x => x.Price * x.Quantity),
			 AvailableRecordCount = g.Count(),
			 Items = [.. g],
             // TODO: mostRecentlyUpdated
		 });
         return result;
    }
}
