using System;
using board;

namespace ChessSystem {
   internal class Screen {

      public static void PrintBoard( Board _board ) {

         for ( int i = 0; i < _board.Lines; i++ ) {
            for ( int j = 0; j < _board.Columns; j++ ) {

               if (_board.Pieces(i, j) != null)
                  Console.Write( _board.Pieces( i , j ) + " ");
               else
                  Console.Write("- ");
            }
            Console.WriteLine();
         }
      }
   }
}
