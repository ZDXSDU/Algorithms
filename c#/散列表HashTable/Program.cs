using System.Collections;
Hashtable phone_book = new()
{
    { "jenny", 8675309 },
    { "emergency", 911 }
};
Console.WriteLine(phone_book["jenny"]);