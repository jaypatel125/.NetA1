//Jay Patel, 000881881 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
//Date: 16/09/2023
//Assignment: 1

using Assignment_1;

public class Program
{
    public static void Main(string[] args)
    {
        // Create an array to store Employee objects
        Employee[] employees = new Employee[100];
        int count = 0;

        try
        {
            // Open and read employee data from a text file
            FileStream file = new FileStream("employees.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            string line;

            // Parse each line of the file and create Employee objects
            while ((line = sr.ReadLine()) != null && count < 100)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 4)
                {
                    string name = parts[0].Trim();
                    int number = int.Parse(parts[1].Trim());
                    decimal rate = decimal.Parse(parts[2].Trim());
                    double hours = double.Parse(parts[3].Trim());

                    employees[count] = new Employee(name, number, rate, hours);
                    count++;
                    //Console.WriteLine(count);
                }

            }

            //for (int i = 0; i < employees.Length; i++)
            //{
            //    Console.WriteLine($" ==> {employees[i].GetName()}");
            //}

        }
        // Handle exceptions
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong. Please try again." + ex.Message);
        }

        // Display a menu and handle user input
        bool toggle = true;
        while (toggle)
        {
            string menu =
@"

Menu
1. Sort by Employee Name (ascending)
2. Sort by Employee Number (ascending)
3. Sort by Employee Pay Rate (descending)
4. Sort by Employee Hours (descending)
5. Sort by Employee Gross Pay (descending)
6. Exit

Enter Option:".Trim();
            Console.WriteLine(menu);
            string input = Console.ReadLine();

            // Switch case for each option
            switch (input)
            {

                case "1":
                    SortByEmployeesName(employees);
                    break;

                case "2":
                    SortByEmployeesNumber(employees);
                    break;

                case "3":
                    SortByEmployeesPayRate(employees);
                    break;

                case "4":
                    SortByEmployeesHours(employees);
                    break;

                case "5":
                    SortByEmployeesGrossPay(employees);
                    break;

                case "6":
                    Console.WriteLine("Good bye!");
                    toggle = false;
                    Thread.Sleep(5000);
                    break;


                default:
                    {
                        Console.WriteLine("Try Again. Enter from above options.\n");
                        break;
                    }
            }

        }


    }

    // Method to sort employees by name
    public static void SortByEmployeesName(Employee[] employees){
            int n = employees.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    // Compare employee name to sort in ascending alphabetical order
                    if (employees[j] != null && employees[j].GetName().CompareTo(employees[minIndex].GetName()) < 0)
                    {
                        minIndex = j;
                    }
                }

                // Swap employees
                Employee temp = employees[i];
                employees[i] = employees[minIndex];
                employees[minIndex] = temp;
            }

            PrintEmployees(employees);
        }

    // Method to sort employees by number
    public static void SortByEmployeesNumber(Employee[] employees){
            int n = employees.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    // Compare employee numbers and find the minimum
                    if (employees[j] != null && employees[j].GetNumber() < employees[minIndex].GetNumber())
                    {
                        minIndex = j;
                    }
                }

                // Swap employees
                Employee temp = employees[i];
                employees[i] = employees[minIndex];
                employees[minIndex] = temp;
            }

            PrintEmployees(employees);
        }

    // Method to sort employees by pay rate
    public static void SortByEmployeesPayRate(Employee[] employees){
            int n = employees.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    // Compare employee pay rates and find the maximum
                    if (employees[j] != null && employees[j].GetRate() > employees[maxIndex].GetRate())
                    {
                        maxIndex = j;
                    }
                }

                // Swap employees
                Employee temp = employees[i];
                employees[i] = employees[maxIndex];
                employees[maxIndex] = temp;
            }

            PrintEmployees(employees);
        }

    // Method to sort employees by hours worked
    public static void SortByEmployeesHours(Employee[] employees){
            int n = employees.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    // Compare employee hours and find the maximum
                    if (employees[j] != null && employees[j].GetHours() > employees[maxIndex].GetHours())
                    {
                        maxIndex = j;
                    }
                }

                // Swap employees
                Employee temp = employees[i];
                employees[i] = employees[maxIndex];
                employees[maxIndex] = temp;
            }

            PrintEmployees(employees);
        }

        // Method to sort employees by gross pay
        public static void SortByEmployeesGrossPay(Employee[] employees){
            int n = employees.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    // Compare employee gross pay and find the maximum
                    if (employees[j] != null && employees[j].GetGross() > employees[maxIndex].GetGross())
                    {
                        maxIndex = j;
                    }
                }

                // Swap employees
                Employee temp = employees[i];
                employees[i] = employees[maxIndex];
                employees[maxIndex] = temp;
            }

            PrintEmployees(employees);
        }
    // Reference for Selection sort method: https://www.geeksforgeeks.org/selection-sort/

    // Method to print employee information
    public static void PrintEmployees(Employee[] employees)
        {
            Console.WriteLine("\n=================================================================");
            Console.WriteLine("| Name               | Number  | Rate     | Hours  | Gross Pay  |");
            Console.WriteLine("=================================================================");

            foreach (var employee in employees)
            {
                if (employee != null)
                {
                    string name = employee.GetName().PadRight(18); 
                    string number = employee.GetNumber().ToString().PadLeft(7);
                    string rate = employee.GetRate().ToString().PadLeft(8); 
                    string hours = employee.GetHours().ToString().PadLeft(6);
                    string grosspay = employee.GetGross().ToString().PadLeft(10);

                    Console.WriteLine($"| {name} | {number} | {rate} | {hours} | {grosspay} |");
                }
            }

            Console.WriteLine("=================================================================");
        }

        
}

