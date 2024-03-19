using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    internal static class Utilities
    { 
        public static void RecieveListsCapacity(List<int> aList)
        {
            int capacity = aList.Capacity;
            Console.WriteLine($"The list capacity/ size are:{capacity}"); 
        } 
        internal static void Adding(List<int> aList, int something)
        {
            aList.Add(something);
        }  
        internal static string retrieveInput()
        {
            Console.WriteLine("Please user type in a string:"); 
            string answer = Console.ReadLine();
            return answer; 
        }
    }
}
