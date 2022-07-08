using System;
using board;
using Chess;

namespace ChessSystem {
   internal class Program {
      static void Main( string[ ] args ) {

         ChessPosition chessPosition = new ChessPosition(7, 'C');

         Console.WriteLine( chessPosition );
         Console.WriteLine( chessPosition.ToPosition() );
      }
   }
}
