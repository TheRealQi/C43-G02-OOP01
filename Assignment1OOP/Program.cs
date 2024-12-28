namespace Assignment1OOP
{
    #region 1 - Create an Enum called "WeekDays" with the days of the week (Monday to Sunday) as its members. Then, write a C# program that prints out all the days of the week using this Enum.

    public enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    #endregion

    #region 2 - Create an Enum called "Seas on" with the four seasons (Spring, Summer, Autumn, Winter) as its members. Write a C# program that takes a season name as input from the user and displays the corresponding month range for that season. Note range for seasons ( spring march to may , summer june to august , autumn September to November , winter December to February)

    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    #endregion

    #region 3 - Assign the following Permissions (Read, write, Delete, Execute) in a form of Enum. Create Variable from previous Enum to Add and Remove Permission from variable, check if specific Permission existed inside variable.

    [Flags]
    internal enum Permission : byte
    {
        Delete = 1,
        Execute = 2,
        Read = 4,
        Write = 8
    }

    internal class User
    {
        public int Id { get; set; }
        public Permission Permissions { get; set; }
    }

    #endregion

    #region 4 - Create an Enum called "Colors" with the basic colors (Red, Green, Blue) as its members. Write a C# program that takes a color name as input from the user and displays a message indicating whether the input color is a primary color or not.

    public enum Colors
    {
        Red,
        Green,
        Blue
    }

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            #region 1 - Create an Enum called "WeekDays" with the days of the week (Monday to Sunday) as its members. Then, write a C# program that prints out all the days of the week using this Enum

            foreach (WeekDays day in Enum.GetValues(typeof(WeekDays))) // Use WeekDays instead of Weekdays
            {
                Console.WriteLine(day); // Also add 'day' to actually print each value
            }

            #endregion

            #region 2 - Create an Enum called "Seas on" with the four seasons (Spring, Summer, Autumn, Winter) as its members. Write a C# program that takes a season name as input from the user and displays the corresponding month range for that season. Note range for seasons ( spring march to may , summer june to august , autumn September to November , winter December to February)

            Console.WriteLine("Enter a season: ");
            String season = Console.ReadLine();
            string range = season switch
            {
                "Spring" => "March to May",
                "Summer" => "June to August",
                "Autumn" => "September to November",
                "Winter" => "December to February",
                _ => "invalid input"
            };
            Console.WriteLine(range);

            #endregion

            #region 3 - Assign the following Permissions (Read, write, Delete, Execute) in a form of Enum. Create Variable from previous Enum to Add and Remove Permission from variable, check if specific Permission existed inside variable.

            User user = new User();
            user.Id = 10;
            user.Permissions = Permission.Read | Permission.Execute | Permission.Write | Permission.Delete;
            user.Permissions &= ~Permission.Delete;
            user.Permissions &= ~Permission.Write;


            if ((user.Permissions & Permission.Write) == Permission.Write)
            {
                Console.WriteLine("Write permission exists");
            }
            else
            {
                Console.WriteLine("Write permission does not exist");
            }

            if ((user.Permissions & Permission.Delete) == Permission.Delete)
            {
                Console.WriteLine("Delete permission exists");
            }
            else
            {
                Console.WriteLine("Delete permission does not exist");
            }

            if ((user.Permissions & Permission.Read) == Permission.Read)
            {
                Console.WriteLine("Read permission exists");
            }
            else
            {
                Console.WriteLine("Read permission does not exist");
            }

            if ((user.Permissions & Permission.Execute) == Permission.Execute)
            {
                Console.WriteLine("Execute permission exists");
            }
            else
            {
                Console.WriteLine("Execute permission does not exist");
            }

            #endregion

            #region 4 - Create an Enum called "Colors" with the basic colors (Red, Green, Blue) as its members. Write a C# program that takes a color name as input from the user and displays a message indicating whether the input color is a primary color or not.

            Console.WriteLine("Enter a color: ");
            String color = Console.ReadLine();
            if (Enum.TryParse<Colors>(color, out Colors result))
            {
                Console.WriteLine("Primary color");
            }
            else
            {
                Console.WriteLine("Not a primary color");
            }

            #endregion
        }
    }
}