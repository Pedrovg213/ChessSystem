using System;
using board;
using Chess;

namespace ChessSystem {
   internal class Program {
      static void Main( string[ ] args ) {

         try {
            Board board = new Board(8, 8);

            board.PutPieces( new Castle( board , Color.Black ) , new Position( 0 , 0 ) );
            board.PutPieces( new Castle( board , Color.Black ) , new Position( 1 , 3 ) );
            board.PutPieces( new King( board , Color.White ) , new Position( 5 , 0 ) );

            Screen.PrintBoard( board );
         } catch ( BoardException be ) {
            Console.WriteLine( be.Message );
         }
      }
   }
}
