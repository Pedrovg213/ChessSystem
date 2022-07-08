using System;
using board;
using Chess;

namespace ChessSystem {
   internal class Program {
      static void Main( string[ ] args ) {

         try {

            Playing play = new Playing();

            while ( !play.Finished ) {

               Console.Clear();

               Screen.PrintBoard( play.board );

               Console.WriteLine();
               Console.Write( "From: " );
               Position from = Screen.ReadChessPosition();
               Console.Write( "To: " );
               Position to = Screen.ReadChessPosition();

               play.MovingPiece( from , to );
            }

         } catch ( BoardException be ) {
            Console.WriteLine( be.Message );
         }
      }
   }
}
