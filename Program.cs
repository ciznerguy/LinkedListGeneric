using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGeneric
{
    public class Program
    {



        //ללא חוליית דמה
        public static Node<int> BuildListFromNumber(int number)
        {

            Node<int> head = new Node<int>(number % 10);
            number = number / 10;
            Node<int> pos = head;
            while (number > 0)
            {
                pos.SetNext(new Node<int>(number % 10));
                number = number / 10;
                pos = pos.GetNext();
            }
            return head;
        }

        // עם חוליית דמה
        public static Node<int> BuildListFromNumber2(int number)

        {
            if (number == 0)
            {
                return null;
            }

            Node<int> Deme = new Node<int>(-999);
            Node<int> pos = Deme;
            while (number > 0)
            {
                pos.SetNext(new Node<int>(number % 10));
                number = number / 10;
                pos = pos.GetNext();
            }
            return Deme.GetNext();
        }


        public static int MidValue(Node<int> head)
        {
            if (head == null)

            {
                return 0;
            }

            Node<int> slow = head, fast = head;



            while (fast.HasNext() && fast.GetNext().HasNext())
            {
                slow = slow.GetNext();
                fast = fast.GetNext().GetNext();
            }

            return slow.GetValue();
        }
        public static int SumOfList(Node<int> head)
        {
            int sum = 0;
            while (head != null)
            {
                sum += head.GetValue();
                head = head.GetNext();
            }
            return sum;
        }

        public static int LengthOfList(Node<int> head)
        {
            int count = 0;
            while (head != null)
            {
                count++;
                head = head.GetNext();
            }
            return count;
        }

        public static Node<int> InsertAtPosition(Node<int> head, int position, int value)
        {
            // Bounds check error: should be position > LengthOfList(head) to verify if insertion is valid.
            if (position <= LengthOfList(head)) return head;

            // Loop correction: start at i = 0, iterate until position - 1 to stop at correct point.
            Node<int> curr = head;
            for (int i = 0; i < position - 1; i++)
            {
                curr = curr.GetNext();
            }

            // Head insertion case is not handled.
            if (position == 0)
            {
                return new Node<int>(value, head);
            }

            // Insert the new node.
            Node<int> nodeToAdd = new Node<int>(value, curr.GetNext());
            curr.SetNext(nodeToAdd);

            return head;
        }

        public static Node<int> RemoveAtPosition(Node<int> head, int position)
        {
            if (head == null)
            {
                return null;
            }
            if (position == 1)
            {
                return head.GetNext();
            }
            if (position > LengthOfList(head))
            {
                return head;
            }
            Node<int> curr = head;
            for (int i = 1; i < position - 1; i++)
            {

                curr = curr.GetNext();
            }
            curr.SetNext(curr.GetNext().GetNext());
            return head;






        }

        public static Node<int> buildListFromArr(int[] arr)
        {
            if (arr.Length == 0) return null;
            Node<int> head = new Node<int>(arr[0]);
            Node<int> pos = head;
            for (int i = 1; i < arr.Length; i++)
            {
                pos.SetNext(new Node<int>(arr[i]));
                pos = pos.GetNext();
            }
            return head;
        }
        //יש לכתוב פעולה המקבלת מערך
        // ומחזירה הפניה לרשימה הכוללת רק את הערכים הזוגיים

        public static Node<int> BuildListOfEvenFromArr(int[] arr)
        {
            Node<int> head = null;
            Node<int> pos = head;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    if (head == null)
                    {
                        head = new Node<int>(arr[i]);
                        pos = head;
                    }
                    else
                    {
                        pos.SetNext(new Node<int>(arr[i]));
                        pos = pos.GetNext();

                    }


                }
            }
            return head;

        }


        //יש לכתוב פעולה המקבלת הפניה לרשימה
        //ומחזירה הפניה לרשימה חדשה רק עם הערכים הזוגיים
        public static int sumDominos(Node<Domino> head)
        {
            int sum = 0;
            while (head != null)
            {
                sum += head.GetValue().GetSum();
                head = head.GetNext();
            }
            return sum;
        }

        //פעולה המקבלת הפניה לרשימת אבני דומינו
        //מחזירה רשימה חדש של אבני דומינו שסכומן 7
        public static Node<Domino> SumSeven(Node<Domino> l)

        {
            Node<Domino> newListOfDomino = new Node<Domino>(new Domino());
            Node<Domino> current = newListOfDomino;
            while (l != null)
            {
                if (l.GetValue().GetSum() == 7)
                {
                    current.SetNext(new Node<Domino>(l.GetValue()));
                    current = current.GetNext();
                }
                l = l.GetNext();
            }
            return newListOfDomino.GetNext();
        }



        //--- פעולה מחזירה את המספר הקטן ביותר התחלת הרשימה ---
        public static int MinInSubList(Node<int> lst)
        {
            int min = lst.GetValue();
            lst = lst.GetNext();

            while (lst != null)
            {
                if (lst.GetValue() < min)
                    min = lst.GetValue();
                lst = lst.GetNext();
            }
            return min;
        }
        public static bool IsArranged(Node<int> lst)
        {
            int k = Size(lst);
            if (k % 2 != 0)
                return false;
            int max = MaxInSubList(lst, k / 2);

            Node<int> pos = GetPosition(lst, k / 2);
            int min = MinInSubList(pos);

            return min >= max;
        }

        //--- פעולה מחזירה את מספר האיברים ברשימה ---
        public static int Size(Node<int> lst)
        {
            int count = 0;

            while (lst != null)
            {
                count++;
                lst = lst.GetNext();
            }

            return count;
        }

        //--- פעולה מחזירה את הצוב במקום בותר ברשימה ---
        public static Node<int> GetPosition(Node<int> lst, int size)
        {
            while (lst != null && size > 0)
            {
                lst = lst.GetNext();
                size--;
            }
            return lst;
        }

        //--- פעולה מחזירה את המספר הגדול ביותר התחלת הראשונה ---
        public static int MaxInSubList(Node<int> lst, int size)
        {
            int max = lst.GetValue();
            lst = lst.GetNext();
            size--;

            while (lst != null && size > 0)
            {
                if (lst.GetValue() > max)
                    max = lst.GetValue();
                lst = lst.GetNext();
                size--;
            }
            return max;
        }

        //פעולה המסירה את האיבר הראשון

        public static Node<int> RemoveFirst(Node<int> head)
        {
            if (head == null)
            {
                return null;
            }
            return head.GetNext();
        }

        //פעולה המסירה את האיבר האחרון
        public static Node<int> RemoveLast(Node<int> head)
        {
            if (head == null || !head.HasNext())
            {
                return null;
            }

            Node<int> prev = null;
            Node<int> temp = head;

            while (temp.HasNext())
            {
                prev = temp;
                temp = temp.GetNext();
            }

            if (prev != null)
            {
                prev.SetNext(null);
            }

            return head;
        }

        // פעולה המחזירה את ערך המקסימום

        public static int FindMaxValue(Node<int> head)
        {
            if (head == null)
            {
                return int.MinValue;
            }

            int maxValue = head.GetValue();
            Node<int> temp = head;

            while (temp != null)
            {
                if (temp.GetValue() > maxValue)
                {
                    maxValue = temp.GetValue();
                }
                temp = temp.GetNext();
            }

            return maxValue;
        }

        // הסרת כל המופעים של ערך מסויים
        public static Node<int> RemoveAllOccurrences(Node<int> head, int value)
{
            if (head == null)
            {
                return null;
            }

            // הסרת כל המופעים של הערך מההתחלה
            while (head != null && head.GetValue() == value)
            {
                head = head.GetNext();
            }

            Node<int> current = head;
            Node<int> prev = null;

            while (current != null)
            {
                if (current.GetValue() == value)
                {
                    if (prev != null)
                    {
                        prev.SetNext(current.GetNext());
                    }
                }
                else
                {
                    prev = current;
                }
                current = current.GetNext();
            }

            return head;
        }



        public static Node<int> ModifyList(Node<int> head)
        {
            // בדיקת קצה: אם הרשימה ריקה או יש רק אלמנט אחד, אין צורך להמשיך.
            if (head == null || head.GetNext() == null)
                return head;

            // שלב 1: מציאת המקסימום לפני הסרת הראש והזנב
            int max = head.GetValue();
            Node<int> current = head;
            Node<int> maxNode = head;
            Node<int> previous = null;

            // מעבר על הרשימה למציאת המקסימום
            while (current != null)
            {
                if (current.GetValue() > max)
                {
                    max = current.GetValue();
                    maxNode = current;
                }
                previous = current;
                current = current.GetNext();
            }

            // שמירת המידע אם המקסימום היה באלמנט הראשון או האחרון
            bool maxWasInFirst = (head.GetValue() == max);
            bool maxWasInLast = (previous != null && previous == maxNode);

            // שלב 2: הסרת האלמנט הראשון
            head = head.GetNext();
            // שלב 3: הסרת האלמנט האחרון
            current = head;
            previous = null;

            // הולכים עד לאלמנט האחרון
            while (current.HasNext())
            {
                previous = current;
                current = current.GetNext();
            }

            // הסרה של האלמנט האחרון
            if (previous != null)
                previous.SetNext(null);
            else
                return null;

            // אם המקסימום לא היה בראשון או באחרון, הסר אותו מהרשימה
            if (!maxWasInFirst && !maxWasInLast)
            {
                current = head;
                Node<int> prevMax = null;

                while (current != null)
                {
                    if (current == maxNode)
                    {
                        if (prevMax != null)
                            prevMax.SetNext(current.GetNext());
                        break;
                    }
                    prevMax = current;
                    current = current.GetNext();
                }
            }

            return head;
        }

        public static string Word(Node<TavPlace> head)
        {
            // חישוב אורך הרשימה
            int length = GetListLength(head);
            if (length <= 0)
            {
                return ""; // אורך הרשימה אינו חוקי
            }

            char[] wordArray = new char[length];
            Node<TavPlace> current = head;

            // מעבר על כל החוליות והצבה במקום הנכון במערך
            while (current != null)
            {
                TavPlace currentPlace = current.GetValue();
                if (currentPlace.Place < 1 || currentPlace.Place > length)
                {
                    return ""; // מיקום לא חוקי
                }
                if (wordArray[currentPlace.Place - 1] != '\0')
                {
                    return ""; // זוהתה כפילות במיקום
                }

                wordArray[currentPlace.Place - 1] = currentPlace.Tav; // המיקום מתחיל מ-1 לכן נוריד 1 כדי לגשת למקום הנכון במערך
                current = current.GetNext();
            }

            // בניית המחרוזת מתוך המערך
            return new string(wordArray);
        }
        private static int GetListLength(Node<TavPlace> head)
        {
            int length = 0;
            Node<TavPlace> current = head;

            while (current != null)
            {
                length++;
                current = current.GetNext();
            }

            return length;
        }

        public static Node<int> Delete(Node<int> head, int valueToDelete)
        {
            // יצירת ראש חדש עבור הרשימה החדשה
            Node<int> dummy = new Node<int>(-99);
            Node<int> newCurrent = dummy;
            Node<int> current = head;

            // מעבר על כל הרשימה והוספה של ערכים שאינם תואמים ל-valueToDelete
            while (current != null)
            {
                if (current.GetValue() != valueToDelete)
                {
                    newCurrent.SetNext(new Node<int>(current.GetValue()));
                    newCurrent = newCurrent.GetNext();
                }

                current = current.GetNext();
            }

            return dummy.GetNext();
        }


        public static int CountUnbalancedDraws(Node<int[]> lotteryResults)
        {
            int count = 0;
            Node<int[]> currentNode = lotteryResults;

            while (currentNode != null)
            {
                int[] draw = currentNode.GetValue();
                int maxValue = int.MinValue;
                int minValue = int.MaxValue;

                // מציאת ערכי מקס ומינימום
                foreach (int number in draw)
                {
                    if (number > maxValue)
                    {
                        maxValue = number;
                    }
                    if (number < minValue)
                    {
                        minValue = number;
                    }
                }

                if (maxValue - minValue > 20)
                {
                    count++;
                }

                currentNode = currentNode.GetNext();
            }

            return count;
        }

        public static double CalculateClassAverage(Node<Student> students, string targetClass)
        {
            double totalSum = 0;
            int studentCount = 0;
            Node<Student> currentNode = students;

            while (currentNode != null)
            {
                Student student = currentNode.GetValue();
                if (student.StudentClass == targetClass)
                {
                    totalSum += student.CalculateAverage();
                    studentCount++;
                }
                currentNode = currentNode.GetNext();
            }
              return totalSum / studentCount;
        }
        public static Node<string> GetStudentsAboveClassAverage(Node<Student> students)
        {
            Node<string> aboveAverageStudents = new Node<string>("dummy");
            Node<Student> currentNode = students;

            while (currentNode != null)
            {
                if(currentNode.GetValue().CalculateAverage() > CalculateClassAverage(students, currentNode.GetValue().StudentClass))
                {
                    aboveAverageStudents.SetNext(new Node<string>(currentNode.GetValue().Name));
                    aboveAverageStudents = aboveAverageStudents.GetNext();
                }
                currentNode = currentNode.GetNext();
            }

            return aboveAverageStudents.GetNext();
        }

        public static int CountCarsWithUnpaidTickets(Node<Car> carsHead)
        {
            int count = 0;
            Node<Car> currentCarNode = carsHead;
            while (currentCarNode != null)
            {
                Node<Ticket> currentTicketNode = currentCarNode.GetValue().GetTickets();
                while (currentTicketNode != null)
                {
                    if (!currentTicketNode.GetValue().GetIsPaid())
                    {
                        count++;
                    }
                    currentTicketNode = currentTicketNode.GetNext();

                }
            }
            return count;
        }

        public static class CarOperations
        {
            public static int CountCarsWithUnpaidTickets(Node<Car> carsHead)
            {
                int count = 0;
                Node<Car> currentCarNode = carsHead;
                while (currentCarNode != null)
                {
                    Node<Ticket> currentTicketNode = currentCarNode.GetValue().GetTickets();
                    while (currentTicketNode != null)
                    {
                        if (!currentTicketNode.GetValue().GetIsPaid())
                        {
                            count++;
                        }
                        currentTicketNode = currentTicketNode.GetNext();
                    }
                    currentCarNode = currentCarNode.GetNext();
                }
                return count;
            }

            // פעולה חיצונית להחזרת רשימה חדשה של כל הרכבים עם מעל 3 דוחות שלא שולמו
            public static Node<string> GetCarsWithMoreThanThreeUnpaidTickets(Node<Car> carsHead)
            {
                Node<string> dummyHead = new Node<string>("DUMMY");
                Node<string> currentNode = dummyHead;
                Node<Car> currentCarNode = carsHead;

                while (currentCarNode != null)
                {
                    int unpaidCount = 0;
                    Node<Ticket> currentTicketNode = currentCarNode.GetValue().GetTickets();
                    while (currentTicketNode != null)
                    {
                        if (!currentTicketNode.GetValue().GetIsPaid())
                        {
                            unpaidCount++;
                        }
                        currentTicketNode = currentTicketNode.GetNext();
                    }
                    if (unpaidCount > 3)
                    {
                        currentNode.SetNext(new Node<string>(currentCarNode.GetValue().GetLicenseNumber()));
                        currentNode = currentNode.GetNext();
                    }
                    currentCarNode = currentCarNode.GetNext();
                }

                return dummyHead.GetNext();
            }
        }





        public static void Main()
        {
            //Node<TavPlace> lst = new Node<TavPlace>(new TavPlace('L', 1));
            //lst.SetNext(new Node<TavPlace>(new TavPlace('U', 2)));
            //lst.GetNext().SetNext(new Node<TavPlace>(new TavPlace('C', 3)));
            //lst.GetNext().GetNext().SetNext(new Node<TavPlace>(new TavPlace('K', 4)));

            //Console.WriteLine(Word(lst)); // Expected output: LUCK
            // Arrange
            OrderList orderedList = new OrderList();

            // יצירת הרשימה לפי התרשים
            Node<NumCount> thirdNode = new Node<NumCount>(new NumCount(8, 2));
            Node<NumCount> secondNode = new Node<NumCount>(new NumCount(5, 2), thirdNode);
            Node<NumCount> firstNode = new Node<NumCount>(new NumCount(3, 9), secondNode);
            Console.WriteLine(orderedList);
        }




    }
}
