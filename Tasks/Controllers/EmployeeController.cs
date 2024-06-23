using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tasks.Data;
using DataAccessLayer.Models;

namespace Tasks.Controllers
{
    public class EmployeeController(DataContext context) : Controller
    {
        private readonly DataContext _context = context;

        public IActionResult Index()
        {
            ////1.Data Source
            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            ////2.Query Creation
            //var numQuery = (from num in numbers
            //               where (num % 2 == 0)//Here We Can Know Type of Linq Array Iterator like <int>
            //               select num).ToArray();//Converting Linq Query into Array Type
            ////3.Query Execution
            //foreach (var num in numQuery)
            //{
            //    Console.WriteLine(num);//Default Execution
            //}

            //--------------------------------------------------------------------------

            //string[] words = { "the", "quick", "brown", "fox", "jumps" };
            //var query = from word in words
            //            orderby word.Length, word.Substring(0, 1) descending//orderby by the length and first word of the word both conditions applied by seprated by comma, this kind of soting called (primary sorting)
            //            select word;
            //foreach (var word in query)
            //{
            //    Console.WriteLine(word);
            //}

            //--------------------------------------------------------------------------

            //Set Operations in Linq, they are:- Union, Intersection, Distinct, Except
            //Lets Assume we have two lists of numbers
            //First List have 1,2,3,4 and Second List have 5,6,7 we want to Combine both the Lists using by Union, After Performing Union Result is 1,2,3,4,5,6,7.

            //int[] list1 = { 1, 2, 3, 4 };
            //int[] list2 = { 5, 6, 7 };
            //var query = from num in list1.Union(list2)
            //            select num;
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}


            ////Intersection the result will contain the numbers which is commonly present in both list1 and list2
            //int[] list1 = { 1, 2, 3, 4, 5, 6 };
            //int[] list2 = { 5, 6, 7, 8 };
            //var query = from num in list1.Intersect(list2)
            //            select num;
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}


            ////Distict keyword works with only one list, the operation will just remove the duplicate numbers and just keep unique numbers in the list
            //int[] list1 = { 1, 2, 3, 3, 4, 5, 5 };

            //var query = from num in list1.Distinct()
            //            select num;
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}


            ////Except keyword In this operation the result will contain all the numbers present in list1 but it will remove the numbers which are present  in list2. In this case the elements common in both the lists are number 5 and 6. so the result contains the numbers 1,2,3 and 4 only.
            //int[] list1 = { 1, 2, 3, 4, 5, 6 };
            //int[] list2 = { 5, 6, 7, 8, 9 };

            //var query = from num in list1.Except(list2)
            //            select num;
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}


            ////let's check how to perform filtering operation using linq, let's suppose we have a list of words and here is the count of letters in each word in the list let's suppose we would like to filter the list and extract only the words whose count of letters is equal to 3.
            //string[] words = { "the", "quick", "brown", "fox", "jumps" };
            //var query = from word in words
            //            where word.Length == 3 && word.Substring(0, 1) == "f"//Here Performing filterning using by f character
            //            select word;
            //foreach (var word in query)
            //{
            //    Console.WriteLine(word);
            //}


            ////Let's Look a Quantifier Operations in Linq, we have three Quantifier Operators in Linq they are: All, Any and Contains, Here 3 Makets near me we want to check Which markets have all the fruits whose Count of letters = 5?
            //var Markets = new[]
            //{
            //    new{MarketName = "Market A", Fruits = new string[] { "kiwi", "cherry", "banana" }},
            //    new{MarketName = "Market B", Fruits = new string[] { "melon", "mango", "olive" }},
            //    new{MarketName = "Market C", Fruits = new string[] { "kiwi", "apple", "orange" }}
            //};

            //var names = from market in Markets
            //            where market.Fruits.All(fruit => fruit.Length == 5)
            //            select market.MarketName;

            //var names = from market in Markets
            //            where market.Fruits.Any(fruit => fruit.StartsWith("k"))//Market names in which any fruit name starts with K character
            //            select market.MarketName;

            //foreach (var word in names)
            //{
            //    Console.WriteLine(word);
            //}

            //--------------------------------------------------------------------------

            ////Projection Operations, Projection is basically refers to the operation of transforming an object into a new form, let's assume we have list of words we required to extract only first letter of each word and create a new list.
            //var words = new string[] { "An", "Apple", "A", "Day" };
            //var query = from word in words
            //            select word.Substring(0, 1);
            //foreach(var letter in query)
            //{
            //    Console.WriteLine(letter);
            //}

            //var sentences = new string[] { "An apple a day", "The quick brown fox" };//Here we spliting our sentences into words
            //var query = from sentence in sentences
            //            from word in sentence.Split(' ')
            //            select word;
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}

            //--------------------------------------------------------------------------

            ////Zip Operator help us to Combines the two lists and create something which is a tupple
            //var list1 = new int[] { 1,2,3,4 };
            //var list2 = new char[] { 'A', 'B', 'C', 'D', 'E' };
            ////var query = Enumerable.Zip(list1, list2, (num, letter) => '(' + num.ToString() + ',' + letter + ')');
            //var query = Enumerable.Zip(list1, list2, (num, letter) => num.ToString() + ',' + letter);
            //foreach (var item in query)
            //{
            //    Console.WriteLine($"({item}),");//Bracket using by Iterpolation
            //}

            //--------------------------------------------------------------------------

            ////Partitioning Data using by Linq, Partitioning is basically refers to the operation of dividing an input sequences.
            //var list = new[] { 'A', 'B', 'C', 'D', 'E' };
            ////var query = list.Skip(3);//Skip For Skiping
            ////var query = list.SkipWhile(i=>i!='C');//SkipWhile For Starting From C Character
            ////var query = list.Take(3);//For Taking Starting data from list
            //var query = list.TakeWhile(i=>i!='C');//TakeWhile stop Taking the elements

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}

            //--------------------------------------------------------------------------

            ////Join Operations in Linq
            //var products = new[]
            //{
            //    new {ProductName="Cola", CategoryID=0},
            //    new {ProductName="Tea", CategoryID=0},
            //    new {ProductName="Apple", CategoryID=1},
            //    new {ProductName="Kiwi", CategoryID=1},
            //    new {ProductName="Carrot", CategoryID=2}
            //};

            //var categories = new[]
            //{
            //    new {CategoryID=0, CategoryName="Beverage"},
            //    new {CategoryID=1, CategoryName="Fruit"},
            //    new {CategoryID=2, CategoryName="Vegetable"}
            //};

            //var query = from product in products
            //            join category in categories on product.CategoryID equals category.CategoryID
            //            select new {product.ProductName, category.CategoryName};

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item.ProductName + ":" + item.CategoryName);
            //}

            //var query = (from country in _context.Countries//Join using by database
            //             join state in _context.States on country.Cid equals state.Cid
            //             select new { country.CName, StateName = state.SName }).AsNoTracking().ToList();

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item.CName + ":" + item.StateName);
            //}

            //--------------------------------------------------------------------------

            ////Grouping data in Linq
            ////Here we group the data on its type like Odd and Even
            //var numbers = new[]
            //{
            //    new{Number="One", Type="Odd"},
            //    new{Number="Two", Type="Even"},
            //    new{Number="Three", Type="Odd"},
            //    new{Number="Four", Type="Even"},
            //    new{Number="One", Type="Odd"}
            //};

            //var query = from number in numbers
            //            group number by number.Type into g
            //            select new { Type = g.Key, Count = g.Count() };
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item.Type + ":" + item.Count);
            //}

            //--------------------------------------------------------------------------

            ////Generation Operations in Linq using by DefaultIfEmpty/Range/Repeat method
            ////List of Empty integers Default value = 0
            ////List of Empty boolean Default value = false

            ////int[] numbers = new int[] { };//Default value is 0
            //bool[] numbers = new bool[] { };//Default value is False
            //foreach (var i in numbers.DefaultIfEmpty())
            //{
            //    Console.WriteLine(i);
            //}


            ////Generate 5 numbers, start with number 1 using by Range Function.
            //var collection = Enumerable.Range(1, 5);

            //foreach(var item in collection)
            //{
            //    Console.WriteLine(item);
            //}


            ////Repeat Function is used for repeating a sentence
            //var collection = Enumerable.Repeat("I Love Programming", 5);

            //foreach (var item in collection)
            //{
            //    Console.WriteLine(item);
            //}

            //--------------------------------------------------------------------------

            ////Element Operations 
            ////int[] collection = { 10, 20, 30, 40, 50 };
            //var item = collection.First();
            //var item = collection.FirstOrDefault();//int defaul value print 0 if list found empty
            //var item = collection.Last();
            //var item = collection.LastOrDefault();
            //var item = collection.ElementAt(3);//For Retriving third place of item that is 40

            //string[] fruits = new string[] { "Apple", "Banana", "Kiwi", "Orange" };
            ////var item = fruits.Single(f => f.Length == 4);//Single Method showed single result maching by condition
            //var item = fruits.Single(f => f.Length == 4);
            //Console.WriteLine(item);

            //--------------------------------------------------------------------------

            ////Concatenation Operation in Linq
            ////We have two tables Cat and Dog we want to Combine both tables data into a single table using by Concat() method
            //var cats = new[]
            //{
            //    new {Name="Barley", Age=8},
            //    new {Name="Boots", Age=4},
            //    new {Name="Whiskers", Age=1}
            //};

            //var dogs = new[]
            //{
            //    new {Name="Bounder", Age=3},
            //    new {Name="Snoopy", Age=14},
            //    new {Name="Fido", Age=9}
            //};

            //var concateCatsDogs = cats.Concat(dogs);

            //foreach (var item in concateCatsDogs)
            //{
            //    Console.WriteLine(item.Name + ":" + item.Age);
            //}

            //--------------------------------------------------------------------------

            //Aggregation Operations performed by Min, Max methods
            var numbers = new int[] { 10, 20, 30, 30, 40, 50 };
            //var value = numbers.Min();
            //var value = numbers.Max();
            //var value = numbers.Sum();
            //var value = numbers.Average();//Average:Sum/Number of items=30
            //var value = numbers.Count();//Count function Count Number of items in the list or use Length Property for this
            //var value = (from number in numbers
            //             where number==30
            //             select number).Count();
            //Console.WriteLine(value);

            //--------------------------------------------------------------------------

            ////Find Occurrence of a word count in a paragraph using Linq

            //string text = "This is a sample text, to check the occurrence of the word sample in this sample text! Thank you.";
            //string searchTerm = "sample";
            //string[] textArray = text.Split(new char[] { ' ', ',', '.' });
            //var matchQuery = from word in textArray
            //                 where word.Equals(searchTerm)
            //                 select word;

            //Console.WriteLine("Count of word 'Sample' = "+matchQuery.Count());

            //--------------------------------------------------------------------------

            ////Extract Numbers from string
            //string text = "ABCD12-3-D-EF-467";
            ////var query = from ch in text
            ////            where Char.IsDigit(ch)
            ////            select ch;

            ////var query = from ch in text
            ////            where Char.IsLetter(ch)
            ////            select ch;

            //var query = from ch in text
            //            where Char.IsDigit(ch) && Char.IsLetter(ch)
            //            select ch;

            //foreach (var ch in query)
            //{
            //    Console.WriteLine(ch);
            //}

            //--------------------------------------------------------------------------

            ////Split Data From File into Multiple Files using Linq
            //string[] file_content = System.IO.File.ReadAllLines(@"C:\Common Library\all_numbers.txt");
            //var even_numbers = from i in file_content
            //                  where Convert.ToInt32(i) % 2 == 0
            //                  select i;
            //var odd_numbers = from i in file_content
            //                 where Convert.ToInt32(i) % 2 != 0
            //                 select i;

            //using (StreamWriter sw = new StreamWriter(@"C:\Common Library\odd_number.txt"))
            //{
            //    foreach (var i in odd_numbers)
            //    {
            //        sw.WriteLine(i);
            //    }
            //}

            //using (StreamWriter sw = new StreamWriter(@"C:\Common Library\even_number.txt"))
            //{
            //    foreach (var i in even_numbers)
            //    {
            //        sw.WriteLine(i);
            //    }
            //}

            //--------------------------------------------------------------------------

            ////Get Specific Files using Linq/Extracting File using Linq
            //string Folder = @"C:\Common Library";
            //string[] fileList = Directory.GetFiles(Folder);
            //var fileQuery = from file in fileList
            //                where Path.GetExtension(file) == ".txt"
            //                select file;
            //foreach (var file in fileQuery)
            //{
            //    Console.WriteLine(file);
            //}

            //--------------------------------------------------------------------------

            //Find the Largest file in the folder using Linq
            string folder = @"C:\Common Library";
            var fileList = new DirectoryInfo(folder).GetFiles();
            var longestFile = (from file in fileList
                               orderby file.Length descending
                               select file).First();
            Console.WriteLine(longestFile.Name + " Size: " + longestFile.Length);

            return View();
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
