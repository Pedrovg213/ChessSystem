using System;
using board;
using Chess;

namespace ChessSystem {
   internal class Program {
      static void Main( string[ ] args ) {

         /* 
          * king rei.               K - R
          * queen rainha.           Q - D
          * bishop bispo.           B - B
          * knight or horse cavalo. H - C
          * rook (or castle) torre. C - T
          * pawn peão.              P - P
          */

         try {

            Playing play = new Playing();

            while ( !play.Finished ) {

               try {
                  Console.Clear();
                  Screen.PrintBoard( play.board );
                  Console.WriteLine();
                  Console.WriteLine( "Turn: " + play.Turn );
                  Console.Write( "Waiting for play: " );
                  if ( play.Player == Color.Black ) {
                     Console.ForegroundColor = ConsoleColor.Yellow;
                  }
                  Console.WriteLine( play.Player );
                  Console.ForegroundColor = ConsoleColor.Gray;

                  Console.WriteLine();
                  Console.Write( "From: " );
                  Position from = Screen.ReadChessPosition();
                  play.ValidationOriginPosition( from );

                  bool[,] possiblePositions = play.board.GetPiece(from).PossibleMoves();

                  Console.Clear();
                  Screen.PrintBoard( play.board , possiblePositions );
                  Console.WriteLine();
                  Console.WriteLine( "Turn: " + play.Turn );
                  Console.Write( "Waiting for play: " );
                  if ( play.Player == Color.Black ) {
                     Console.ForegroundColor = ConsoleColor.Yellow;
                  }
                  Console.WriteLine( play.Player );
                  Console.ForegroundColor = ConsoleColor.Gray;

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

         } catch ( BoardException be ) {
            Console.WriteLine( be.Message );
         }
      }
   }
}
