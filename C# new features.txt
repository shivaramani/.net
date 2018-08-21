## C# 7 Features

## 1) out variables
   Prior versions - need to declare out variable before passing it
   	ex: int x;
         var square = getSquare(out x);
   New - this can be declared and passed in the function
    ex:  var square = getSquare(out int x);
	
	typical use case on try catch pattern
	try{
		int square = getSquare(s, out int x);
		
		// also "discards" are available
		ex: getSquare(out int x, out _);   // I care only about x. this lets to ignore parameters you dont care about
	}
	catch(Exception){
	
	}
	
##2) Pattern matching - variables can be declared in the middle of an expression, and can be used within the nearest surrounding scope
	 - pattern variables are mutable similar to out
     - through "is" and "switch"
	 - is expressions can now have a pattern on the right hand side, instead of just a type
	 - case clauses in switch statements can now match on patterns, not just constant values
	 
	 ex:
	public void PrintStars(object o)
	{
		if (o is null) return;     // constant pattern "null"
		if (!(o is int i)) return; // type pattern "int i"
		WriteLine(new string('*', i));
	}
	
	switch(shape)
	{
		case Circle c:
			WriteLine($"circle with radius {c.Radius}");
			break;
		case Rectangle s when (s.Length == s.Height):
			WriteLine($"{s.Length} x {s.Height} square");
		case Rectangle r:
			WriteLine($"{r.Length} x {r.Height} rectangle");
			break;
		default:
			WriteLine("<unknown shape>");
			break;
		case null:
			throw new ArgumentNullException(nameof(shape));
	}
	
	NOTE - The order of case clauses now matters (check Rectangle case variants above)
		 - The default clause is always evaluated last eventhough null case is declared below default
		 - The null clause at the end is not unreachable: This is because type patterns follow the example of the current is expression and do not match null.
	
	
## Tuples
	- It is common to want to return more than one value from a method.	
	- System.Tuple<...> return types: Verbose to use and require an allocation of a tuple object.
	
	 - ex: The method now effectively returns three strings, wrapped up as elements in a tuple value.
	 		(string, string, string) LookupName(long id) // tuple return type
			{
				... // retrieve first, middle and last from data storage
				return (first, middle, last); // tuple literal
			}
	
			or 
			(string first, string middle, string last) LookupName(long id) // tuple elements have names
			
	- The caller of the method will receive a tuple, and can access the elements individually:
		- var names = LookupName(id);
		  WriteLine($"found {names.Item1} {names.Item3}.");
		  
		  or
		  var names = LookupName(id);
		  WriteLine($"found {names.first} {names.last}.");
	
	
## Deconstruction
   -  A deconstructing declaration is a syntax for splitting a tuple (or other value) into its parts and assigning those parts individually to fresh variables
   -  Deconstructing can be done not only for tuples. Any types can be deconstructed.
   
   - ex: Tupes
   		(string first, string middle, string last) = LookupName(id1); // deconstructing declaration
		WriteLine($"found {first} {last}.");
		
		- while deconstructing can use "var" 
		- ex: (var first, var middle, var last) = LookupName(id1); // var inside
			  or
			  var (first, middle, last) = LookupName(id1); // var outside
	
	- ex: methods/functions
		class Point
		{
			public int X { get; }
			public int Y { get; }

			public Point(int x, int y) { X = x; Y = y; }
			public void Deconstruct(out int x, out int y) { x = X; y = Y; }
		}

		(var myX, var myY) = GetPoint(); // calls Deconstruct(out myX, out myY);
	
## Local functions

	- helper functions inside a single method which uses it.
	
		ex: 
		class MyClass
		{
			static void Main(string[] args)  
			{  
			  int Add(int a, int b)  
			  {  
				return a + b;  
			  }  
			  Display("howdy");
			  Console.WriteLine(Add(3,4));  
			  Console.ReadKey();
			}   
			
			public static void Display(string str)
			{
				DisplayText();
				
				void DisplayText()
				{
					// some process here
					Console.WriteLine(str);
				}
			}
		}	

## Literal Improvements

 - C# 7 allows "_" to use as digit separator
 - The purpose of a digit separator is to improve readability, nothing more. The value of the variable is unaffected by this literal.
 - ex: var num = 1_000_000;  
 	   var hex = 0xAB_CD_EF;   
	   value of the above variables are 1000000 and ABCDEF.
	

## Refs returns and locals

- Like pass by reference (with the ref modifier), you can now return them by reference, and also store them by reference in local variables.

-  ex: 
		public ref int Find(int number, int[] numbers)
		{
			for (int i = 0; i < numbers.Length; i++)
			{
				if (numbers[i] == number) 
				{
					return ref numbers[i]; // return the storage location, not the value
				}
			}
			throw new IndexOutOfRangeException($"{nameof(number)} not found");
		}

		int[] array = { 1, 15, -39, 0, 7, 14, -12 };
		ref int place = ref Find(7, array); // aliases 7's place in the array
		place = 9; // replaces 7 with 9 in the array
		WriteLine(array[4]); // prints 9
	

## throws expressions

- can throw expression in the middle of an expression

  - ex: public Person(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
        public string GetLastName() => throw new NotImplementedException();
	
	
	
	
## C# 6 New features

## Read-only auto-properties

- Read-only auto-properties provide a more concise syntax to create immutable types. 
- ex: public string FirstName { get; private set; }
	
	
## Auto-Property Initializers

- Auto-Property Initializers let you declare the initial value for an auto-property as part of the property declaration. 	

- ex: 
	public Student(string firstName, string lastName)
	{
		FirstName = firstName;
		LastName = lastName;
	}


## Expression-bodied function members

- The body of a lot of members that we write consist of only one statement that can be represented as an expression.
- You can reduce that syntax by writing an expression-bodied member instead. It works for methods and read-only properties. F

- ex: 
	public override string ToString() => $"{LastName}, {FirstName}";
	public string FullName => $"{FirstName} {LastName}";
	
## using static

- The using static enhancement enables you to import the static methods of a single class. 
- Previously, the using statement imported all types in a namespace.	

- ex: using static System.Math;
	  using static System.String;
	  
## Null Conditional Operators
  - The right hand side operand of the ?. operator is not limited to properties or fields. You can also use it to conditionally invoke methods.
  - ex: var first = person?.FirstName; 
          first = person?.FirstName ?? "Unspecified";
	
        this.SomethingHappened?.Invoke(this, eventArgs);
		
## String Interpolation

- C# 6 contains new syntax for composing strings from a format string and expressions that are evaluated to produce other string values.		
- ex: public string FullName => $"{FirstName} {LastName}";
	  public string GetGradePointPercentage() => $"Name: {LastName}, {FirstName}. G.P.A: {Grades.Average():F2}";
	
## Exception Filters

- Exception Filters are clauses that determine when a given catch clause should be applied. 
- If the expression used for an exception filter evaluates to true, the catch clause performs its normal processing on an exception. 
- If the expression evaluates to false, then the catch clause is skipped.

- ex:  try
        {
            var responseText = await stringTask;
            return responseText;
        }
        catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
        {
            return "Site Moved";
        }
		
		// NOTE earlier versions we write as below
		try {
			var responseText = await streamTask;
			return responseText;
		} catch (System.Net.Http.HttpRequestException e)
		{
			if (e.Message.Contains("301"))
				return "Site Moved";
			else
				throw;
		}
	

## Await in Catch and Finally blocks

- You can now use await in catch or finally expressions.
-  ex: 
	public static async Task<string> MakeRequestAndLogFailures()
	{ 
		await logMethodEntrance();
		var client = new System.Net.Http.HttpClient();
		var streamTask = client.GetStringAsync("https://localHost:10000");
		try {
			var responseText = await streamTask;
			return responseText;
		} catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
		{
			await logError("Recovered from redirect", e);
			return "Site Moved";
		}
		finally
		{
			await logMethodExit();
			client.Dispose();
		}
	}
	
## Index Initializers

-  Dictionary<TKey,TValue> collections and similar types.
- Index Initializers is one of two features that make collection initializers more consistent with index usage. I	

- ex:
   private Dictionary<int, string> webErrors = new Dictionary<int, string>
	{
		[404] = "Page not Found",
		[302] = "Page moved, but left a forwarding address.",
		[500] = "The web server can't come out to play today."
	};
	
	// NOTE earlier it used to be 
	private List<string> messages = new List<string> 
	{
		"Page not Found",
		"Page moved, but left a forwarding address.",
		"The web server can't come out to play today."
	};
	

## Extension Add methods in collection initializers

## Improved overload resolution
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
- References	
https://blogs.msdn.microsoft.com/dotnet/2017/03/09/new-features-in-c-7-0/

https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-6