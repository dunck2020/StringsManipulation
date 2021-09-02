using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace StringsManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringConversion();
            //StringAsArray();
            //EscapeString();
            //AppendingStrings();
            //InterpolationAndLiteral();
            //StringBuilderDemo();
            //WorkingWithArrays();
            //PadAndTrim();
            //SeachingStrings();
            //OrderingStrings();
            //TestingEquality();
            //GettingASubstring();
            //ReplacingText();
            //InsertingText();
            //RemovingText();
            Console.ReadKey();
        }
        private static void StringConversion()
        {
            string testString = "tHis iS tHe FBI Calling!";
            TextInfo currentTextInfo = CultureInfo.CurrentCulture.TextInfo;

            //can change region for text info
            TextInfo englishTextInfo = new CultureInfo("en-US", false).TextInfo;
            string result;

            //converts all characters to lower case
            result = testString.ToLower();
            Console.WriteLine(result);

            //convert all characters to upper case
            result = testString.ToUpper();
            Console.WriteLine(result);

            //depending on region capitalizes all first letters and allows for acronyms
            result = currentTextInfo.ToTitleCase(testString);
            Console.WriteLine(result);

            //because we are in the US this will be the same as above 
            result = englishTextInfo.ToTitleCase(testString);
            Console.WriteLine(result);

        }

        private static void StringAsArray()
        {
            string testString = "The Dinosaur";

            //allows to treat the string as an array
            for (int i = 0; i < testString.Length; i++)
            {
                Console.WriteLine(testString[i]);
            }
        }

        private static void EscapeString()
        {
            string result;

            // using the backslash as an escape character
            result = "This is my \"test\" string";
            Console.WriteLine(result);

            result = "c:\\Demo\\Test.txt";
            Console.WriteLine(result);

            //at symbol is the string literal
            result = @"C:\Demo\Test.txt";
            Console.WriteLine(result);

        }

        private static void AppendingStrings()
        {
            //performance is about the same for each of these methods - really depends on readability
            string firstName = "Dave";
            string lastName = "Thomas";
            string result;

            //string appending using plus symbol
            result = firstName + ", my name is " + firstName + " " + lastName;
            Console.WriteLine(result);

            //using string format option
            result = string.Format("{0}, my name is {0} {1}", firstName, lastName);
            Console.WriteLine(result);

            //console write line has string.format built in
            Console.WriteLine("{0}, my name is {0} {1}", firstName, lastName);

            //string interpolation - this is probably the easiest to read
            //variable can be a string literal or calculation or method call
            result = $"{firstName}, my name is {firstName} {lastName}";
            Console.WriteLine(result);

        }

        private static void InterpolationAndLiteral()
        {
            //can handle both string literal and string interpolation
            string testString = "Dave Thomas";
            string result = $@"C:\Demo\{testString}\{"\""}Test{"\""}.txt";
            Console.WriteLine(result);
        }

        private static void StringBuilderDemo()
        {
            string testString;

            //this creates a new space for the test string and test is left to be collected by the garbage collector
            testString = "John";

            //this adds even more memory space
            testString += " is a rad dude";

            //using the stopwatch this demonstrates how much faster string builder can be
            //100 thousand vs 10 thousand
            Stopwatch regularStopwatch = new Stopwatch();
            regularStopwatch.Start();

            string test = "";

            for (int i = 0; i < 10000; i++)
            {
                test += i;
            }

            regularStopwatch.Stop();
            Console.WriteLine($"Regular Stopwatch 10,000 iterations: {regularStopwatch.ElapsedMilliseconds} ms");

            Stopwatch builderStopwatch = new Stopwatch();
            builderStopwatch.Start();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 100000; i++)
            {
                sb.Append(i);
            }

            builderStopwatch.Stop();
            Console.WriteLine($"Builder Stopwatch 100,000 iterations: {builderStopwatch.ElapsedMilliseconds} ms");

        }

        private static void WorkingWithArrays()
        {
            int[] ages = { 6, 7, 8, 3, 5 };
            string results;

            results = String.Concat(ages);
            Console.WriteLine(results);

            results = String.Join(",", ages);
            Console.WriteLine(results);
            Console.WriteLine();

            string testString = "John,Tim,Mary,Bob,Jane";
            string[] resultsArray = testString.Split(',');
            Array.ForEach(resultsArray, x => Console.WriteLine(x));
            Console.WriteLine();

            
            testString = "John, Tim, Mary, Bob, Jane";
            resultsArray = testString.Split(", ");
            Array.ForEach(resultsArray, x => Console.WriteLine(x));

            char[] delimitChars = { ',', ' ' };
            resultsArray = testString.Split(delimitChars);
            Array.ForEach(resultsArray, x => Console.WriteLine(x));

        }

        private static void PadAndTrim()
        {
            string testString = "          Hello World          ";
            string results;

            Console.WriteLine($"'{testString}'      Start string");

            results = testString.TrimStart();
            Console.WriteLine($"'{results}'                TrimStart");

            results = testString.TrimEnd();
            Console.WriteLine($"'{results}'                TrimEnd");

            results = testString.Trim();
            Console.WriteLine($"'{results}'                          Trim");
            Console.WriteLine();

            testString = "1.15";
            results = testString.PadLeft(10, '0');
            Console.WriteLine(results);

            results = testString.PadRight(10, '0');
            Console.WriteLine(results);

        }

        private static void SeachingStrings()
        {
            string testString = "This is a test of the search. Let's see how its testing works out.";
            bool resultsBoolean;
            int resultsInt;

            Console.WriteLine(testString);
            resultsBoolean = testString.StartsWith("This is");
            Console.WriteLine($"Starts with \"This is\': {resultsBoolean}");

            resultsBoolean = testString.StartsWith("THis is");
            Console.WriteLine($"Starts with \"THis is\': {resultsBoolean}");

            resultsBoolean = testString.EndsWith("works out.");
            Console.WriteLine($"Ends with \"works out.\': {resultsBoolean}");

            resultsBoolean = testString.EndsWith("works out");
            Console.WriteLine($"Ends with \"works out\': {resultsBoolean}");

            resultsBoolean = testString.Contains("test");
            Console.WriteLine($"Contains with \"test.\': {resultsBoolean}");

            resultsBoolean = testString.Contains("tests");
            Console.WriteLine($"Contains with \"tests\': {resultsBoolean}");

            resultsInt = testString.IndexOf("test");
            Console.WriteLine($"Index of \"test\": {resultsInt}");

            resultsInt = testString.IndexOf("test", 11);
            Console.WriteLine($"Index of \"test\" after character 10: {resultsInt}");

            resultsInt = testString.IndexOf("test", 49);
            Console.WriteLine($"Index of \"test\" after character 48: {resultsInt}");

            resultsInt = testString.LastIndexOf("test");
            Console.WriteLine($"Last Index of \"test\": {resultsInt}");

            resultsInt = testString.LastIndexOf("test", 48);
            Console.WriteLine($"Last Index of \"test\" before character 48: {resultsInt}");

            resultsInt = testString.IndexOf("test", 10);
            Console.WriteLine($"Last Index of \"test\" before character 10: {resultsInt}");

            //way to test through a string to find all instances of a string
            //while(testString.IndexOf("test", i) > -1)
            //{

            //}


        }

        private static void OrderingStrings()
        {
            CompareToHelper("Mary", "Bob");
            CompareToHelper("Mary", null);
            CompareToHelper("Adam", "Bob");
            CompareToHelper("Bob", "Bobby");
            CompareToHelper("Bob", "Bob");

            Console.WriteLine();

            CompareHelper("Mary", "Bob");
            CompareHelper("Mary", null);
            CompareHelper(null, "Bob");
            CompareHelper("Adam", "Bob");
            CompareHelper("Bob", "Bobby");
            CompareHelper("Bob", "Bob");
            CompareHelper(null, null);
        }

        private static void CompareToHelper(string testA, string? testB)
        {
            //compares stringA with stringB if stringA comes before stringB in alphabet
            //will return less than zero, if stringB comes before will return greater than 0
            //if the strings are in the same location (not equal) will return a zero
            int resultsInt = testA.CompareTo(testB);
            switch (resultsInt)
            {
                case > 0:
                    Console.WriteLine($"CompareTo: { testB ?? "null"} comes before { testA }");
                    break;
                case < 0:
                    Console.WriteLine($"CompareTo: { testA } comes before { testB }");
                    break;
                case 0:
                    Console.WriteLine($"CompareTo: { testA } is the same as { testB }");
                    break;
            }
        }

        private static void CompareHelper(string? testA, string? testB)
        {
            int resultsInt = String.Compare(testA, testB);
            switch (resultsInt)
            {
                case > 0:
                    Console.WriteLine($"Compare: { testB ?? "null" } comes before { testA }");
                    break;
                case < 0:
                    Console.WriteLine($"Compare: { testA ?? "null" } comes before { testB }");
                    break;
                case 0:
                    Console.WriteLine($"Compare: { testA ?? "null" } is the same as { testB ?? "null" }");
                    break;
            }

        }

        private static void TestingEquality()
        {
            EqualityHelper("Bob", "Mary");
            EqualityHelper( null, "");
            EqualityHelper("", " ");
            EqualityHelper("Bob", "bob");
        }

        private static void EqualityHelper(string? testA, string? testB)
        {
            bool resultsBoolean;

            //using the string equals method
            resultsBoolean = String.Equals(testA, testB);
            if (resultsBoolean)
            {
                Console.WriteLine($"Equals: '{ testA ?? "null" }' equals '{ testB ?? "null"}'");
            }
            else
            {
                Console.WriteLine($"Equals: '{ testA ?? "null" }' does not '{ testB ?? "null"}'");
            }
            
            //using string equals with string comparison ignore case
            resultsBoolean = String.Equals(testA, testB, StringComparison.InvariantCultureIgnoreCase);
            if (resultsBoolean)
            {
                Console.WriteLine($"Equals (ignore case): '{ testA ?? "null" }' equals '{ testB ?? "null"}'");
            }
            else
            {
                Console.WriteLine($"Equals (ignore case): '{ testA ?? "null" }' does not '{ testB ?? "null"}'");
            }
            
            //using == to determine if equal
            //functions a lot like String.Equal however you can not use ignore case or invariant etc.
            //double equals can also be overridden but don't do it
            resultsBoolean = testA == testB;
            if (resultsBoolean)
            {
                Console.WriteLine($" ==: '{ testA ?? "null" }' equals '{ testB ?? "null"}'");
            }
            else
            {
                Console.WriteLine($" ==: '{ testA ?? "null" }' does not '{ testB ?? "null"}'");
            }
            Console.WriteLine();
        }

        private static void GettingASubstring()
        {
            string testString = "This is a test of substring. Let's see how its testing works out.";
            string results;

            //starts a position
            results = testString.Substring(5);
            Console.WriteLine(results);

            //starts at first integer and go int number of characters
            results = testString.Substring(5, 4);
            Console.WriteLine(results);
        }

        private static void ReplacingText()
        {
            string testString = "This is a test of substring. Let's see how its testing Works out.";
            string results;

            //replace has four overloads
            results = testString.Replace("test", "trial");
            Console.WriteLine(results);

            results = testString.Replace(" test ", " trial ");
            Console.WriteLine(results);

            //overload to ignore case
            results = testString.Replace("works", "makes", StringComparison.InvariantCultureIgnoreCase);
            Console.WriteLine(results);
        }

        private static void InsertingText()
        {
            string testString = "This is a test of insert. Let's see how its testing Works out.";
            string results;

            results = testString.Insert(5, "(test)");
            Console.WriteLine(results);
        }

        private static void RemovingText()
        {
            string testString = "This is a test of remove. Let's see how its testing Works out.";
            string results;

            //removes everything from int on out
            results = testString.Remove(25);
            Console.WriteLine(results);

            //start position and num of chars to remove
            results = testString.Remove(14, 10);
            Console.WriteLine(results);
        }

    }
}
