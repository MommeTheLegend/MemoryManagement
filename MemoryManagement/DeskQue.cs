using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    internal class DeskQue
    {  
        internal Queue<Person> queue;
        public DeskQue()
        {
            queue = new Queue<Person>();
        } 
        public int getSize()
        {
            return queue.Count();    
        } 
        public void addCustomer(Person aPerson)
        {
            queue.Enqueue(aPerson);
        } 
        public Person removeCustomer() 
        {
            return queue.Dequeue();
        } 
        internal void ViewAllTheCustomer(DeskQue que)
        { 
            foreach (Person person in queue) 
            {
                Console.WriteLine($"{person.FirstName} is still in que \n");
            }
        }       
    }
}
