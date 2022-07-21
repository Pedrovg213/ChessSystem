using System;
using board;
using Chess;

namespace ChessSystem {
   internal class Program {
      static void Main( string[ ] args ) {

         try {

            Playing play = new Playing();

            while ( !play.Finished ) {
               try {

                  Console.Clear();
                  Screen.PrintPlay( play );

                  Console.WriteLine();
                  Console.Write( "From: " );
                  Position from = Screen.ReadChessPosition();
                  play.ValidationOriginPosition( from );

                  bool[,] possiblePositions = play.board.GetPiece(from).PossibleMoves();

                  Console.Clear();
                  Screen.PrintPlay( play , possiblePositions );

                  Console.WriteLine();
                  Console.Write( "To: " );
                  Position to = Screen.ReadChessPosition();
                  play.ValidationTargetPosition( from , to );

                  play.MovingPiece( from , to );

               } catch ( BoardException be ) {

                  Console.WriteLine( be.Message );
                  Console.WriteLine( "Press enter." );
                  Console.ReadLine();

               }
            }

            Console.Clear();
            Screen.PrintPlay( play );

         } catch ( BoardException be ) {
            Console.WriteLine( be.Message );
         }
      }
   }
}
