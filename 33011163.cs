using System;
using System.Collections.Generic;

namespace p4cs
{

  class TrinaryConverter
  {
    public static void Convertion() //this class is made public so that it can be accessed in the switch case which is outside this class
    {
        Console.WriteLine("You have chosen the Trinary Converter");
        Console.Write("Please enter a trinary number (0, 1, 2):");
        string trinary = Console.ReadLine(); //this holds the trinary value as a string when user inputs
        int decimalNum = TrinaryToDecimal(trinary); //this calls the TrinaryToDecimal method which the trinary value is a string and the result will be given as an integer due to the convertion of the trinary to decimal process.
        Console.WriteLine("Decimal equivalent: " + decimalNum);
    }

    private static int TrinaryToDecimal(string trinary) //this method is kept private so that it can only be accessed within the trinary converter class and not outside of it and static is created as an instance
    //the private static gives in parameter of string trinary which is what the user inputs the values of 0,1,2 and it gets converted into an integer because of the conversion of the trinary to decimal as decimal is stored as an integer.
    {
        int decimalNum = 0; //declared variable decimalnum as a O until further input is given
        int power = 0; //declared variable power as a O until further input is given

        for (int i = trinary.Length - 1; i >= 0; --i) //for integer being i check the trinary value's length as it decrements through the trinary value inputted and the loop will continue to execute until i is greater or equal to 0 and checks till the last trinary value inputted
        {
            int number = trinary[i] - '0'; //checks position of the trinary digit which the - 0 converts that into a integer as minusing from 0 gives the same integer as before and assigns the variable to number
            //subtracting by 0 makes the digit to its equal integer value 

            if (number < 0 || number > 2) //checks if number is less than 0 OR more than 2 as the trinary numbers can only accept the values of 0,1,2
            {
                Console.WriteLine("Only enter numbers of 0, 1 and 2:"); //this is the output if numbers outside of this IF statement are inputted
                return 0 ; // Return an error value
            }
            else
            {
                decimalNum += number * (int)Math.Pow(3, power); //  https://www.geeksforgeeks.org/ternary-number-system-or-base-3-numbers/      i got the calculation for trinary converter from this website
                power++; //  https://www.geeksforgeeks.org/ternary-number-system-or-base-3-numbers/      i got the calculation for trinary converter from this website
            }
        }
      return decimalNum; //i have put this outside the else statement because it allows the process of the conversion to occur completely then give the result out
        
    }
}

class SchoolRoster
{
  private static Dictionary<int, List<string>> roster = new Dictionary<int, List<string>>(); //roster is declared as this dictionary and int is the type of key in dictionary that'll represent form and string will represent studentName
  public static void Roster()
  {
    Console.WriteLine("You have chosen the School Roster");
    Console.Write("Enter your student name: ");
    string studentName = Console.ReadLine();
    Console.Write("Enter your form: ");
    int form = int.Parse(Console.ReadLine());

    AddStudents(studentName, form); //assigned methods to be used in the public class with the given parameter
    Enrolment(form); //assigned methods to be used in the public class with the given parameter
    
  }
  
  private static void AddStudents(string studentName, int form)
  {
    if (!roster.ContainsKey(form)) //  https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-find-a-key-in-a-dictionary-with-C-Sharp/      i have used this website to understand how to find the keys in dictionaries 
    //this if statement checks if there isnt the key form in the roster dictionary then it'll add form to the list located in form in the dictionary delcared roster     
    {
        roster.Add(form, new List<string>()); //and if not then it adds the form (key) inputted from the user and to store the studentName to the specific form which creates a new instance
    }
    
        roster[form].Add(studentName); //this adds the form to the studentName inputted
        roster[form].Sort(); //this is the built in sort function and this sorts the forms and studentNames once added.

    if (roster.ContainsKey(form)) //  https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-find-a-key-in-a-dictionary-with-C-Sharp/     i have used this website to understand how to find the keys in dictionaries
    { //this checks if there is a key in form and executes to the user to add the student to inputted form

        Console.WriteLine("Add " + studentName + " to" + " form " + form); 
        Console.WriteLine("OK.");
        }

    }

  private static void Enrolment(int form)
  {
    if (roster.ContainsKey(form)) //  https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-find-a-key-in-a-dictionary-with-C-Sharp/     i have used this website to understand
    {
        Console.WriteLine("Which students are in " + "form " + form + "?");
        Console.WriteLine("We've got " + string.Join(", ", roster[form]) + " just for now."); //   https://www.geeksforgeeks.org/c-sharp-join-method-set-1/   i used this website to under how to join strings together using this method to adapt to my program
    }
  }
}



class ISBNVerifier
{
    public static void Verification() //this class is made public so that it can be accessed in the switch case which is outside this class
    {
        Console.WriteLine("You have chosen the ISBN Verifier");
        Console.Write("Enter ISBN values:"); //user inputs an isbn value which is treated as a string

        string isbn = Console.ReadLine().Replace("-", "").ToUpper(); //https://learn.microsoft.com/en-us/dotnet/api/system.string.replace?view=net-8.0   I used this website to find how to replace the hyphens into just a list of numbers without hyphens so it can be calculated 
        //this line of code replaces with the .Replace the hyphen to without hyphens as the hyphens are used in this ISBN verifier for formatting purposes and the ISBN can do the calculations.
        //i have wrote .ToUpper for any user that inputs X it can be handled as an uppercase even if the user writes "x" in lowercase as it is case sensitive.

        if (isbn.Length != 10) //checks if the length of the isbn is not equal to 10
        {
            Console.WriteLine("Only enter 10 numbers:"); //if yes then this statement will be executed
            return;
        }

        int sum = CalculateISBN(isbn); //this calls the method CalculateISBN and passes isbn as a string and returns int value of variable sum whatever as been calculated.
        int lastDigit = CheckDigit(isbn, sum); //this calls the method CheckDigit and passes the parameter isbn and sum which is needed to check the checkdigit adn the method returns as an integer and assigned to lastDigit

        if ((lastDigit == isbn[9]-'0') || (lastDigit == 10 && isbn[9] == 'X')) //checks if the lastDigit equals to the 10th isbn value through the index 0 - 9 OR if the lastDigit equals 10 AND if the 9th index which is the 10th digit equals to X which also counts as 10.
        {
            Console.WriteLine("The ISBN value is valid."); //if the sum equal to 0 then the ISBN value is valid
        }
        else
        {
            Console.WriteLine("The ISBN value is invalid."); //if not then this statement will be executed
        }
    }

    private static int CalculateISBN(string isbn) //this method can only be accessed within the class as this is where the calculation 
    { //of ISBN happens as it's converting the string of numbers that the user inputted and convert it all to an integer value

        int sum = 0; //the variable sum is set as an integer and is set to 0

        for (int i = 0; i < 9; i++) //for integer being i check the isbn's length as it ascends through the ISBN inputted and the loop will continue to execute until i is equal to 0 and greater than 9 and checks until the last ISBN number value inputted
        {
            int digit= isbn[i] - '0'; //checks position of the ISBN number which the - 0 converts that into a integer as minusing from 0 gives the same integer as before and assigns the variable to number
            //subtracting by 0 makes the ISBN number to its equal integer value 

            sum += digit * (10 - i); //https://www.geeksforgeeks.org/program-check-isbn/3-598-21507-X  i used this website to find how to do the calculation for ISBN
        }
        return sum; //this returns the sum calculated by the CalculateISBN method
    }

    private static int CheckDigit(string isbn, int sum)
    {
      int remainder = sum % 11; //this gets the calculation of the sum in the class above and does MOD 11 to check if the ISBN is valid or not as it should equal to 0 when sum is MOD by 11 and gives the remainder to the statement below
      int checkDigit = (11 - remainder) % 11; //https://en.wikipedia.org/wiki/ISBN  i used this website to check how to calculate for checkdigit in ISBN

      return checkDigit; //this returns the calculated checkDigit 
    }


        class Menu
        {
            public static void Main()
            {
                string value;
                do
                    {
                        Console.WriteLine("Choose one of the following options:");
                        Console.WriteLine("a - Trinary Converter");
                        Console.WriteLine("b - School Roster");
                        Console.WriteLine("c - ISBN Verifier");
                        Console.WriteLine("q - End the program");
                        Console.Write("Please enter your choice of options: ");
                        value = Console.ReadLine(); 

                    switch (value)
                    {
                        case "a":
                            TrinaryConverter.Convertion();
                            break;
                
                        case "b":
                            SchoolRoster.Roster();
                            break;
                        
                        case "c":
                            ISBNVerifier.Verification();
                            break;

                        case "q":
                            Console.WriteLine("You have chosen to end the program");
                            break;

                        default:
                            Console.WriteLine("Invalid Response. Please enter one of the following values: a, b, c, q.");
                            break;
                        }   
                } while (value != "q");
           }}}}
        