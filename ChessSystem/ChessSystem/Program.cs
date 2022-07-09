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

               Console.Clear();
               Screen.PrintBoard( play.board );

               Console.WriteLine();
               Console.Write( "From: " );
               Position from = Screen.ReadChessPosition();

               bool[,] possiblePositions = play.board.GetPiece(from).PossibleMoves();

               Console.Clear();
               Screen.PrintBoard( play.board , possiblePositions );

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
