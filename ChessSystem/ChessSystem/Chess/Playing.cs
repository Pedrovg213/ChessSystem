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
      public int Turn {
         get; private set;
      }
      public Color Player {
         get; private set;
      }


      public Playing( ) {

         board = new Board( 8 , 8 );
         Turn = 1;
         Player = Color.White;

         PutPieces();
      }


      private void ChangePlayer( ) {

         if ( Player == Color.White )
            Player = Color.Black;
         else {
            Player = Color.White;
            Turn++;
         }
      }
      public void MovingPiece( Position _from , Position _to ) {

         Pieces piece = board.RemovePiece(_from);
         piece.IncremetMoviment();
         Pieces capturedPiece = board.RemovePiece( _to );

         board.PutPieces( piece , _to );

         ChangePlayer();
      }
      public void PutPieces( ) {

         // White pieces
         Color color = Color.White;
         board.PutPieces( new Castle( board , color ) , 'C' , 1 );
         board.PutPieces( new King( board , color ) , 'D' , 1 );
         board.PutPieces( new Castle( board , color ) , 'E' , 1 );
         board.PutPieces( new Castle( board , color ) , 'C' , 2 );
         board.PutPieces( new Castle( board , color ) , 'D' , 2 );
         board.PutPieces( new Castle( board , color ) , 'E' , 2 );

         // Black pieces
         color = Color.Black;
         board.PutPieces( new Castle( board , color ) , 'C' , 8 );
         board.PutPieces( new King( board , color ) , 'D' , 8 );
         board.PutPieces( new Castle( board , color ) , 'E' , 8 );
         board.PutPieces( new Castle( board , color ) , 'C' , 7 );
         board.PutPieces( new King( board , color ) , 'D' , 7 );
         board.PutPieces( new Castle( board , color ) , 'E' , 7 );
      }
      public void ValidationTargetPosition( Position _from , Position _to ) {

         if ( !board.GetPiece( _from ).CanMoveTo( _to ) )
            throw new BoardException( "Invalid target position." );
      }
      public void ValidationOriginPosition( Position _origin ) {

         if ( board.GetPiece( _origin ) == null )
            throw new BoardException( "There is no piece in this position." );
         if ( Player != board.GetPiece( _origin ).color )
            throw new BoardException( "This piece is not yours." );
         if ( !board.GetPiece( _origin ).HasPossibleMoves() )
            throw new BoardException( "This piece is blocked." );
      }
   }
}
