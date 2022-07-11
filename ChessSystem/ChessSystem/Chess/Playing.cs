using System.Collections.Generic;
using board;

namespace Chess {
   internal class Playing {

      private HashSet<Pieces> PiecesInGame;
      private HashSet<Pieces> CapturedPieces;
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
         PiecesInGame = new HashSet<Pieces>();
         CapturedPieces = new HashSet<Pieces>();

         PutPieces();
      }


      public HashSet<Pieces> GetCapturedPieces( Color _color ) {

         HashSet<Pieces> retn = new HashSet<Pieces>();

         foreach ( Pieces p in CapturedPieces )
            if ( p.color == _color )
               retn.Add( p );

         return retn;
      }
      public HashSet<Pieces> GetInGamePieces( Color _color ) {

         HashSet<Pieces> retn = new HashSet<Pieces>();

         foreach ( Pieces p in PiecesInGame )
            if ( p.color == _color )
               retn.Add( p );

         retn.ExceptWith( GetCapturedPieces( _color ) );

         return retn;
      }
      private void ChangePlayer( ) {

         if ( Player == Color.White )
            Player = Color.Black;
         else {
            Player = Color.White;
            Turn++;
         }
      }
      private void PutNewPiece( Pieces _piece , char _columm , int _line ) {

         board.PutPieces( _piece , new ChessPosition( _columm , _line ).ToPosition() );
         PiecesInGame.Add( _piece );
      }
      public void MovingPiece( Position _from , Position _to ) {

         Pieces piece = board.RemovePiece(_from);
         piece.IncremetMoviment();
         
         Pieces capturedPiece = board.RemovePiece( _to );
         if ( capturedPiece != null )
            CapturedPieces.Add( capturedPiece );

         board.PutPieces( piece , _to );

         ChangePlayer();
      }
      public void PutPieces( ) {

         // White pieces
         Color color = Color.White;
         PutNewPiece( new Castle( board , color ) , 'C' , 1 );
         PutNewPiece( new King( board , color ) , 'D' , 1 );
         PutNewPiece( new Castle( board , color ) , 'E' , 1 );
         PutNewPiece( new Castle( board , color ) , 'C' , 2 );
         PutNewPiece( new Castle( board , color ) , 'D' , 2 );
         PutNewPiece( new Castle( board , color ) , 'E' , 2 );

         // Black pieces
         color = Color.Black;
         PutNewPiece( new Castle( board , color ) , 'C' , 8 );
         PutNewPiece( new King( board , color ) , 'D' , 8 );
         PutNewPiece( new Castle( board , color ) , 'E' , 8 );
         PutNewPiece( new Castle( board , color ) , 'C' , 7 );
         PutNewPiece( new Castle( board , color ) , 'D' , 7 );
         PutNewPiece( new Castle( board , color ) , 'E' , 7 );
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
