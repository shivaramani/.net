using System;
using System.Collections;
public class SamplesArrayList  {

   public static void Main()  {

      // Creates and initializes a new ArrayList.
      ArrayList myAL = new ArrayList();
      myAL.Add( "the" );
      myAL.Add( "quick" );
      myAL.Add( "brown" );
      myAL.Add( "fox" );
      myAL.Add( "jumped" );
      myAL.Add( "over" );
      myAL.Add( "the" );
      myAL.Add( "lazy" );
      myAL.Add( "dog" );

      // Displays the ArrayList.
      Console.WriteLine( "The ArrayList initially contains the following:" );
      PrintValues( myAL );

      // Removes the element containing "the".
      myAL.Remove( "the" );

      // Displays the current state of the ArrayList.
      Console.WriteLine( "After removing \"the\":" );
      PrintValues( myAL );
      Console.WriteLine( "Above removed only the first \"the\":" );

      // Removes the element at index 5.
      myAL.RemoveAt( 5 );

      // Displays the current state of the ArrayList.
      Console.WriteLine( "After removing the element at index 5:" );
      PrintValues( myAL );

      // Removes three elements starting at index 4.
      myAL.RemoveRange( 4, 3 );

      // Displays the current state of the ArrayList.
      Console.WriteLine( "After removing three elements starting at index 4:" );
      PrintValues( myAL );
   }

   public static void PrintValues( IEnumerable myList )  {
      foreach ( Object obj in myList )
         Console.Write( "   {0}", obj );
      Console.WriteLine();
   }

}
