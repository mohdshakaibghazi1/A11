using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppAssignment11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object[] Data = new object[] {
                "Audi", "Lambo", "BMW", "Buggati"
            };
            using (LargeDataCollection collection = new LargeDataCollection(Data))
            {
                Console.WriteLine("Collection before adding an element:");
                List<object> beforeAdd = collection.GetList();
                PrintCollection(beforeAdd);
                collection.Add("Mercedes");
                Console.WriteLine("Collection after adding Mercedes element:");
                List<object> afterAdd = collection.GetList();
                PrintCollection(afterAdd);
                collection.Remove("Lambo");
                Console.WriteLine("Collection after removing Lambo element:");
                List<object> afterRemove = collection.GetList();
                PrintCollection(afterRemove);
                object element = collection.GetElement(2);
                Console.WriteLine($"Element at index 2: {element}");
            }
            Console.ReadKey();
        }
        static void PrintCollection(List<object> collection)
        {
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
