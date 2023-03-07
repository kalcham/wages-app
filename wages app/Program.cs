//imports
using System;
using System.Collections.Generic;

namespace wages_app
{
    class Program
    {
        //global variables
        static string topEarner = "";
        static int topEarnerhours = 9;

        //methods and/or functions


        static string CheckFlag()
        {
            while (true)
            {
                Console.WriteLine("Press < ENTER > to add another or type 'xxx' to quit\n");
                string UserInput = Console.ReadLine();

                //Convert User Input to uppercase
                UserInput = UserInput.ToUpper();

                if (UserInput.Equals("XXX") || UserInput.Equals("") )
                {
                    return UserInput;
                }
                Console.WriteLine("Error: Please enter a correct choice.");
            }
           
        }
    
        static string CheckName()
        {
            while (true)
            {
                //get name
                Console.WriteLine("Enter the employeename name:\n");
                string name = Console.ReadLine();

                if (!name.Equals(""))
                {
                    //convert swimmer name to capitalised name
                    name = name[0].ToString().ToUpper() + name.Substring(1);
                    return name;
                }
                Console.WriteLine("Error: You must enter a name for the employeename");
            }
        }

            static void CalculateWages(int totalHourWorked, string employeename)
        {
            //display the toal weekly hours stored
            Console.WriteLine($"total Hour Worked : {totalHourWorked}hrs");

            //add 5 hours id sumhours >30
            if (totalHourWorked >= 30)
            {
                totalHourWorked += 5;

                //if bouns hours have been given display correct amount
                Console.WriteLine($"5 bonus hours addded: {totalHourWorked}hrs");
            }

            if(totalHourWorked > topEarnerhours)
            {
                topEarnerhours = totalHourWorked;
                topEarner = employeename;
            }

            //calculate wage at a rate of 22/hr
            int wages = totalHourWorked * 22;

            float tax = 0.07f;

            //calculate tax
            if (wages > 450) 
            {
                tax = 0.08f;
            }
            //calculate final pay

            float finalPay = wages - (float)Math.Round(wages * tax, 2);

            //display the results of the calculate followed by two blank lines
            Console.WriteLine($"weekly Pay: {wages}\n" +
                $"Tax Rate {tax}\n" +
                $"Tax:{Math.Round(wages * tax, 2)}\n" +
                $"Final Pay: {finalPay}\n\n\n");

        }

        static void OneEmployee()
            
        {
            List<string> weekday = new List<string>() { "monday", "tuesday", "wednesday", "thursday", "friday" };

            //Enter and store employee name
            string employeeName = CheckName();

            //display Employee name
            Console.WriteLine(employeeName);

            int sumHoursWorked = 0;

            //loop 5
            for (int dayindex = 0; dayindex < 5; dayindex++)
            {
                Random randGen = new Random();

                //Randomly generate the number of hours worked by a worker each day
                int hourrsWorked = randGen.Next(2, 7);

                //Assign the name of the day of the week to a variable called

                string day = weekday[dayindex];

                //store the number of hours worked over the five day
                sumHoursWorked += hourrsWorked;


                //display the name of the day and the nuber of hours generate
                Console.WriteLine($"\tHours worked on {day}: {hourrsWorked}");
                    
            }


            //call the CalculateWages
            CalculateWages(sumHoursWorked, employeeName);
        }

        //when run or main process
        static void Main(string[] args)
        {
            string flagmain = "";
            while(!flagmain.Equals("XXX"))
            {
                OneEmployee();


                flagmain = CheckFlag();
            }

            Console.WriteLine($"{topEarner} the most hours worked: {topEarnerhours}hrs");

        }
    }
}
