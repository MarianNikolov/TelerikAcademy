using System;

class BankAccountData
{

    //Problem 11. Bank Account Data

    //A bank account has a holder name (first name, middle name and last name), 
    //available amount of money (balance), bank name, IBAN, 3 credit card numbers associated with the account.
    //Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.

    static void Main()
    {
        string firstName = "Marian";
        string middleName = "Stefanov";
        string lastName = "Nikolov";
        decimal balance = 2344.223m;
        string customerIBAN = "IBAN5365337643";
        string customerFirstCardsNumber = "4555 6665 8522 2265 5525";
        string customerSecondCardsNumber = "4555 6665 8522 2265 1235";
        string customerThirdCardsNumber = "4555 6665 8522 2265 2315";
        Console.WriteLine(firstName + " " + middleName + " " + lastName);
        Console.WriteLine(balance);
        Console.WriteLine(customerIBAN);
        Console.WriteLine(customerFirstCardsNumber);
        Console.WriteLine(customerSecondCardsNumber);
        Console.WriteLine(customerThirdCardsNumber);
    }

}

