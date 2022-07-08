using System;
using board;

namespace ChessSystem {
   internal class Screen {

      public static void PrintBoard( Board _board ) {

         for ( int i = 0; i < _board.Lines; i++ ) {
            for ( int j = 0; j < _board.Columns; j++ ) {

               WriteBoard( _board , i , j );
            }

            Console.WriteLine();
         }
      }
      static void WriteBoard( Board _board , int _line , int _columm ) {

         if ( _board.Pieces( _line , _columm ) != null )
            Console.Write( _board.Pieces( _line , _columm ) + " " );
         else
            Console.Write( "- " );
      }
   }
}
