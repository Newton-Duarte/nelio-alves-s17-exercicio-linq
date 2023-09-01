string fileName = "in.txt";
List<Product> products = new();

try
{
  using (StreamReader sr = File.OpenText(fileName))
  {
    while (!sr.EndOfStream)
    {
      string[] line = sr.ReadLine().Split(",");
      string productName = line[0];
      double productPrice = double.Parse(line[1]);

      products.Add(new Product { Name = productName, Price = productPrice });
    }
  }

  var productsAveragePrice = products.Average(p => p.Price);
  System.Console.Write("Products Average Price: ");
  System.Console.WriteLine($"{productsAveragePrice:F2}");

  var productsWithPriceBelowAverage = products.Where(p => p.Price < productsAveragePrice).Select(p => p.Name).OrderByDescending(p => p);
  foreach(var item in productsWithPriceBelowAverage)
  {
    System.Console.WriteLine(item);
  }
}
catch (Exception e)
{
  System.Console.WriteLine(e.Message);
}