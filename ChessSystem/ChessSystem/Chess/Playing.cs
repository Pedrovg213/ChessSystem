using System;
using board;

namespace Chess {
   internal class Playing {

      public Board board {
         get; private set;
      }
      public bool Finished {
         get; private set;
      } = false;
      private int Turn;
      private Color Player;


      public Playing( ) {

         board = new Board( 8 , 8 );
         Turn = 1;
         Player = Color.White;

         PutPieces();
      }


      public void MovingPiece( Position _from , Position _to ) {

         Pieces piece = board.RemovePiece(_from);
         piece.IncremetMoviment();
         Pieces capturedPiece = board.RemovePiece( _to );

         board.PutPieces( piece , _to );
      }
      public void PutPieces( ) {

         // White pieces
         Color color = Color.White;
         board.PutPieces( new Castle( board , color ) , 'A' , 1 );
         board.PutPieces( new King( board , color ) , 'E' , 1 );
         board.PutPieces( new Castle( board , color ) , 'H' , 1 );

         // Black pieces
         color = Color.Black;
         board.PutPieces( new Castle( board , color ) , 'A' , 8 );
         board.PutPieces( new King( board , color ) , 'D' , 8 );
         board.PutPieces( new Castle( board , color ) , 'H' , 8 );
      }
   }
}
