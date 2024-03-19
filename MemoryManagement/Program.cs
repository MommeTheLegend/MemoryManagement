


using System.Diagnostics;

namespace MemoryManagement
{
    internal class Program
    {
        //Que för fråga fyra, placeraalla tecken i queue 
        
        static void Main(string[] args)
        {
            /* Frågor: 
             * 1: Stacken, kan betraktas som tallriks högar. Där den första tallriken
             * placeras längst ner för att placera andra tallrikar över den. Högen
             * av tallrikar utgör ellerbestårav value Types samt metoder. Vill man åt
             * den understa tallriken måste resterande tallrikar ovanför plockas bort 
             * först i följd innan man kommer åt den önskvärda tallriken i botten.
             * Alltså LIFO, last in first out. Utöver detta sköter den sig självt effektivt,
             * ingen GC, garbage collecter behövs. En metodanrop gör att metoden placeras
             * i stakken med tillhörande variabler om en annan metod anropimetoden exekveras kommer 
             * den andra metod kroppen att placeras i stakken och därefter exekveras den för
             * att återgå till metoden under den i stacken o.s.v.  
             * 1: Heapen, Heapen har i allmenhet en större livslängd och mer dynamiskt i sin
             * natur. Till skillnad från stacken är strukturen annorlunda då man kan nå den, 
             * exemplet ni angav om kläder är perfekt. Vilket innebär att objekter, klasser, 
             * interfaces och liknande med längra livslängd befinnser sig där. Vissa gånger kan
             * öka i storlek och uppta stor utrymme. Därför behövs GC, alltså viktigt 
             * att objekten iheapen ska ha pointers riktat mot dem, för att inte riskera 
             * bli av med dem
             * 2: Value types, är färdiga och avklarade värden som finns i System.ValueType 
             * Reference types är reference som pekar till objekt exempelvis. 
             * 
             * 3:Svaret ligger i att valuetyperna påförsta metoden hamnar i stacken 
             * och en kopia av InputInt + 5 placeras i result behållaren. InputInt behållaren 
             * kvarstår och förändras inte. Alltså en kopia placeras i behållaren. 
             * 
             * Den andra fallet är att en objekt med attributen MyValue i objektet placeras i heapen
             * x och y som är en instans av MyInt befinner sig i heapen med attributet MyValue
             * x.MyValue attributet eller behållaren i objektet har 3 i. Med y = x; 
             * pekar både referensvariabler mot samma objekt, y.MyValue = 4; såuppdateras 
             * attributet i objektet till 4, alltså referensvariablerna kommer ge samma
             * uppdaterade resultatet. 
             */

             ExamineList();
            /* 1. Kolla ExamineListmetoden samt Utilities
             * 2 och 3. Den underliggande arrayens storlekhar en grund storlek
             * på 0, där den ökas med 4 element då max capacity överskrids.  
             * 4. Man vill inte ha en massa arrayer i minnet. Därför när
             * man skapar array i minnet och försätter värdena i arrayen har 
             * man en ny array med 4 element större. 
             * 5. Nej, när capacitet ökas kommer den underliggande arrayen inte 
             * minskas. Vilket är dåligt då minnesupptagning består fast kanske 
             * man inte är i behov av elementen.     
             * 6. När man vet hur många elemnt man nyttjar i förväg. Alltså i förväg 
             * kan man deklarera storleken på arrayen. Annars är List bäst och man behöver
             * inte bekymmra sig över storleken då den förändras dynamiskt. 
             */
            // Övning 2
            ExamineQueue();
            // Övning 3  
            /*
             * 1. Kön kommer bli orättvist, alltså den som tog sig först till kön 
             * kommer expedieras sist. Är möjligt att plocka ut alla kunder ur stacken
             * för att sedan placera de in i en ny stack, men detta måste uföras 
             * varje gång en ny kund ställer sig i kön, mödosamt, oeffektivt och upptar 
             * mer minnesutrymme. 
             * 2.
             */
            ExamineStack();
            //Övning 4 
            bool play = true;
            do
            {
                Console.WriteLine("You have two options available at your disposal: " +
                    "\npress y: If you wish to analyze if a string is wellformed" +
                    "\npress e: If you wish to exit the game");
                string answer = Console.ReadLine().ToLower();
                switch (answer)
                {
                    case "y":
                        CheckParantheses();
                        break;
                    case "e":
                        play = false;
                        break;
                }

            } while (play);
        }
        public static void CheckParantheses()
        {
            char[] openEndedParantheses = {'{', '[', '('};
            char[] closedEndedParantheses = {'}', ']', ')'};
            string answer = Utilities.retrieveInput(); 
            char[] chars = answer.ToCharArray();
            //Vi behöver en queue för att placera tecknena från sträng
            Queue<char> queue = new Queue<char>(); 
            Stack<char> stack = new Stack<char>(); 

            //Placera alla open-ended paranteser i stack
            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < openEndedParantheses.Length; j++)
                {
                    if (chars[i] == openEndedParantheses[j])
                    {
                        stack.Push(chars[i]);
                    } 
                    //Placeraalla closed ended paranteser i heap 
                    if (chars[i] == closedEndedParantheses[j])
                    {
                        queue.Enqueue(chars[i]);
                    }
                    }
            }
            bool sizeSame = isSizeOfStackAndQueueEqual(queue, stack);
            bool paranthesisEqualOrNot = false;
            if (sizeSame)
            {
               paranthesisEqualOrNot = CompareParantheses(queue, stack);
            }
            if (paranthesisEqualOrNot)
            {
                Console.WriteLine("The string is välformad");
            }
            else
            {
                Console.WriteLine("The string is not wellformed");
            }
        } 
        //Om storleken inte är lika innebär det att uppgiften ej är uppfylld
        internal static bool isSizeOfStackAndQueueEqual(Queue<char> aQueue, Stack<char> aStack)
        {
            if (aQueue.Count == aStack.Count)
            {
                return true;
            }
            else
            {
                return false;
            }   
        }
        public static bool CompareParantheses(Queue<char> aQueue, Stack<char> aStack)
        {
            bool answer = true;
            //Storleken på queue och stack är detsamma ommetoden exekveras
            if (aQueue.Count > 0 && answer)
            {
                char paranthesisInQue = aQueue.Dequeue();
                char paranthesisInStack = aStack.Pop();
                answer = IsEqual(paranthesisInQue, paranthesisInStack);
                Console.WriteLine("Size of Queue: " + aQueue.Count);
            }
            return answer; 
        }
        public static bool IsEqual(char queChar, char stackChar)
        {
           bool answer = false;
           if (stackChar == '{' && queChar == '}')
           {
                answer = true;
           }else if (stackChar == '(' && queChar == ')')
           {
                answer = true;
           }else if (stackChar == '[' && queChar == ']')
           {
                answer = true;
            }
            else
            {
                answer = false;
            }
            return answer;
        }

        public static void ExamineStack()
        {
            string answer = "";
            Stack<char> reverseName = new Stack<char>();
            bool play = true; 
            do
            {
                Console.WriteLine("Dear user you have two options:  " +
                    "\npress y: If you wish to reverse a word " +
                    "\npress q: If you wish to quit program "); 
                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "y":
                        string aString = Utilities.retrieveInput();
                        Console.WriteLine(aString);
                        char[] acharArr = aString.ToCharArray();

                        foreach (char c in acharArr)
                        {
                            reverseName.Push(c);
                        }
                        int sizeOfStack = reverseName.Count;
                        for (int i = 0; i < sizeOfStack; i++)
                        {
                            answer += reverseName.Pop();
                        }
                        break; 
                    case "q": 
                        play = false;
                        break;
                    default:
                        Console.WriteLine("Dear user, please type in y or q");
                        break;
                }
                Console.WriteLine(answer); 
                //Försöker ta bort charactärerna i strängen för att spela om den 
                answer.Remove(0);
            } while (play);
        }
        public static void ExamineQueue()
        {
            string answer = "empty";
            bool gameLoop = true;
            DeskQue aQue = new DeskQue();
            string aName; 
            do
            {
                Console.WriteLine($"ICA Que have {aQue.getSize()} if you want a new person in pay desk" +
                    $"\npress i: include new person in pay desk.  " +
                    $"\npress l: a person leaves que in pay desk " +
                    $"\npress q: You wish to exit game" +
                    $"\npress v: to view all the members on the que");  
                answer = Console.ReadLine().ToLower();

                switch (answer)
                {
                    case "i":
                        Console.WriteLine("Type in the first name of customer:");
                        aName = Console.ReadLine();
                        Person customer = new Person(aName);
                        aQue.addCustomer(customer);
                        Console.WriteLine($"{customer.FirstName} is on the que");
                        break;
                    case "l":
                        Person aCustomer = aQue.removeCustomer();
                        Console.WriteLine($"{aCustomer.FirstName} has been served and left que");
                        break;
                    case "q":  
                        gameLoop = false;
                        break;
                    case "v":
                        aQue.ViewAllTheCustomer(aQue);
                        break;
                    default:
                        Console.WriteLine("Please type in correct option!");
                        break;
                }
                QueStatus(aQue);
            } while (gameLoop);
        }
        private static void QueStatus(DeskQue que)
        {
            Console.WriteLine($"There are {que.getSize()} customer");  
        }
        public static void ExamineList()
        {   
            List<int> list = new List<int>(); 
            //Ursprungs capaciteten är 0
            Utilities.RecieveListsCapacity(list);// Spottar ut 0
            Utilities.Adding(list, 1);
            Utilities.Adding(list, 2);
            //Storleken på listan eller capaciteten förändrades till 4
            Utilities.RecieveListsCapacity(list); // Spottar ut 4
            list.Add(3); 
            list.Add(4);
            //Fortfarande 4, capaciteten justeras inte då ej överskridit max antalet
            Utilities.RecieveListsCapacity(list); // Fortfarande 4 
            list.Add(1);
            Utilities.RecieveListsCapacity(list);// 8

            list.Remove(1);  
            list.Remove(3);
            Utilities.RecieveListsCapacity(list);// Fortfarande 8, listans capacitet minskas inte
        }
    }
}
