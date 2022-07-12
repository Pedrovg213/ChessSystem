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
      public bool Xeque {
         get; private set;
      }
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
         Xeque = false;

         PutPieces();
      }


      private Color Adversary( Color _checker ) {

         return ( _checker == Color.White ?
            Color.Black : Color.White );
      }
      private Pieces GetKing( Color _color ) {

         foreach ( Pieces p in GetInGamePieces( _color ) )
            if ( p is King )
               return p;

         return null;
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
      
      public bool CheckMateTest( Color _color ) {

         if ( !IsCheck( _color ) )
            return false;

         foreach ( Pieces p in GetInGamePieces( _color ) ) {

            bool[,] mat = p.PossibleMoves();
            for ( int i = 0; i < board.Lines; i++ ) {
               for ( int j = 0; j < board.Columns; j++ ) {
                  if ( mat[ i , j ] ) {

                     Position piecePosition = p.position;
                     Position matPosition = new Position( i , j );
                     Pieces capturedPiece = RunMovement(piecePosition, matPosition);
                     bool isInCheck = IsCheck(_color);
                     UndoMovement( piecePosition , matPosition , capturedPiece );

                     if ( !isInCheck )
                        return false;
                  }
               }
            }
         }

         return true;
      }
      public bool IsCheck( Color _color ) {

         Pieces king = GetKing(_color);
         if ( king == null )
            throw new BoardException( $"Have no king {_color} on the board." );

         foreach ( Pieces p in GetInGamePieces( Adversary( _color ) ) ) {

            bool [,] mat = p.PossibleMoves();
            if ( mat[ king.position.Line , king.position.Columm ] )
               return true;
         }
         return false;
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
      public Pieces RunMovement( Position _from , Position _to ) {

         Pieces piece = board.RemovePiece(_from);
         piece.IncremetMoviment();
         Pieces capturedPiece = board.RemovePiece( _to );
         if ( capturedPiece != null )
            CapturedPieces.Add( capturedPiece );
         board.PutPieces( piece , _to );

         return capturedPiece;
      }
      public void MovingPiece( Position _from , Position _to ) {

         Pieces capturedPiece = RunMovement( _from , _to );

         if ( IsCheck( Player ) ) {

            UndoMovement( _from , _to , capturedPiece );
            throw new BoardException( "!!!YOU WILL BE IN CHECK!!!" );
         }

         Xeque = IsCheck( Adversary( Player ) );

         if ( CheckMateTest( Adversary( Player ) ) )
            Finished = true;
         else
            ChangePlayer();
      }
      public void PutPieces( ) {

         // White pieces
         Color color = Color.White;
         PutNewPiece( new Castle( board , color ) , 'C' , 1 );
         PutNewPiece( new King( board , color ) , 'D' , 1 );
         PutNewPiece( new Castle( board , color ) , 'H' , 7 );

         // Black pieces
         color = Color.Black;
         PutNewPiece( new Castle( board , color ) , 'B' , 8 );
         PutNewPiece( new King( board , color ) , 'A' , 8 );
      }
      public void UndoMovement( Position _from , Position _to , Pieces _capturedPiece ) {

         Pieces piece = board.RemovePiece(_to);
         if ( _capturedPiece != null ) {
            board.PutPieces( _capturedPiece , _to );
            CapturedPieces.Remove( _capturedPiece );
         }
         board.PutPieces( piece , _from );
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