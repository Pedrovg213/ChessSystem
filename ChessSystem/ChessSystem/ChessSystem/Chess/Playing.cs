using System.Collections.Generic;
using board;

namespace Chess {
   internal class Playing {

      private HashSet<Pieces> PiecesInGame;
      private HashSet<Pieces> CapturedPieces;
      public Pieces EnPassant {
         get; private set;
      }
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
         EnPassant = null;

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
      private void PutNewPiece( Pieces _piece , Position _position ) {

         board.PutPieces( _piece , _position );
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
         Pieces capturedPiece = board.RemovePiece( _to );

         if ( capturedPiece != null )
            CapturedPieces.Add( capturedPiece );

         board.PutPieces( piece , _to );

         LittleRoque( _from , _to , piece );
         BigRoque( _from , _to , piece );

         if ( piece is Pawn ) {
            if ( _from.Columm != _to.Columm && capturedPiece == null ) {

               int id = piece.color == Color.White ? 1 : -1;
               Position posPawn = new Position(_to.Line + id, _to.Columm);

               capturedPiece = board.GetPiece( posPawn );
               board.RemovePiece( posPawn );
               CapturedPieces.Add( capturedPiece );
            }
         }

         piece.IncremetMoviment();

         return capturedPiece;
      }


      private void LittleRoque( Position _from , Position _to , Pieces _piece ) {

         if ( _piece is King && _from.Columm + 2 == _to.Columm ) {

            Position fromCastle = new Position(_from.Line, _from.Columm + 3);
            Position toCastle = new Position(_from.Line, _from.Columm + 1);

            if ( board.GetPiece( fromCastle ) is Castle )
               RunMovement( fromCastle , toCastle );
         }
      }
      private void BigRoque( Position _from , Position _to , Pieces _piece ) {

         if ( _piece is King && _from.Columm - 2 == _to.Columm ) {

            Position fromCastle = new Position(_from.Line, _from.Columm - 4 );
            Position toCastle = new Position(_from.Line, _from.Columm - 1);

            if ( board.GetPiece( fromCastle ) is Castle )
               RunMovement( fromCastle , toCastle );
         }
      }

      public void MovingPiece( Position _from , Position _to ) {

         Pieces capturedPiece = RunMovement( _from , _to );

         if ( IsCheck( Player ) ) {

            UndoMovement( _from , _to , capturedPiece );
            throw new BoardException( "!!!YOU WILL BE IN CHECK!!!" );
         }

         Pieces pieceTo = board.GetPiece(_to);

         // Pawn promotion
         if ( pieceTo is Pawn ) {

            int promotionLine = pieceTo.color == Color.White ? 0 : 7;
            if ( _to.Line == promotionLine ) {

               pieceTo = board.RemovePiece( _to );
               PiecesInGame.Remove( pieceTo );

               Pieces queen = new Queen(board, pieceTo.color);
               PutNewPiece( queen , _to );
               PiecesInGame.Add( queen );
            }
         }

         Xeque = IsCheck( Adversary( Player ) );

         if ( CheckMateTest( Adversary( Player ) ) )
            Finished = true;
         else
            ChangePlayer();

         // En passant
         if ( pieceTo is Pawn && ( _to.Line == _from.Line - 2 || _to.Line == _from.Line + 2 ) )
            EnPassant = pieceTo;
         else
            EnPassant = null;
      }
      public void PutPieces( ) {

         // White pieces
         Color color = Color.White;
         PutNewPiece( new Castle( board , color ) , 'A' , 1 );
         PutNewPiece( new Horse( board , color ) , 'B' , 1 );
         PutNewPiece( new Bishop( board , color ) , 'C' , 1 );
         PutNewPiece( new Queen( board , color ) , 'D' , 1 );
         PutNewPiece( new King( this , board , color ) , 'E' , 1 );
         PutNewPiece( new Bishop( board , color ) , 'F' , 1 );
         PutNewPiece( new Horse( board , color ) , 'G' , 1 );
         PutNewPiece( new Castle( board , color ) , 'H' , 1 );
         PutNewPiece( new Pawn( this , board , color ) , 'A' , 2 );
         PutNewPiece( new Pawn( this , board , color ) , 'B' , 2 );
         PutNewPiece( new Pawn( this , board , color ) , 'C' , 2 );
         PutNewPiece( new Pawn( this , board , color ) , 'D' , 2 );
         PutNewPiece( new Pawn( this , board , color ) , 'E' , 2 );
         PutNewPiece( new Pawn( this , board , color ) , 'F' , 2 );
         PutNewPiece( new Pawn( this , board , color ) , 'G' , 2 );
         PutNewPiece( new Pawn( this , board , color ) , 'H' , 2 );

         // Black pieces
         color = Color.Black;
         PutNewPiece( new Castle( board , color ) , 'A' , 8 );
         PutNewPiece( new Horse( board , color ) , 'B' , 8 );
         PutNewPiece( new Bishop( board , color ) , 'C' , 8 );
         PutNewPiece( new Queen( board , color ) , 'D' , 8 );
         PutNewPiece( new King( this , board , color ) , 'E' , 8 );
         PutNewPiece( new Bishop( board , color ) , 'F' , 8 );
         PutNewPiece( new Horse( board , color ) , 'G' , 8 );
         PutNewPiece( new Castle( board , color ) , 'H' , 8 );
         PutNewPiece( new Pawn( this , board , color ) , 'A' , 7 );
         PutNewPiece( new Pawn( this , board , color ) , 'B' , 7 );
         PutNewPiece( new Pawn( this , board , color ) , 'C' , 7 );
         PutNewPiece( new Pawn( this , board , color ) , 'D' , 7 );
         PutNewPiece( new Pawn( this , board , color ) , 'E' , 7 );
         PutNewPiece( new Pawn( this , board , color ) , 'F' , 7 );
         PutNewPiece( new Pawn( this , board , color ) , 'G' , 7 );
         PutNewPiece( new Pawn( this , board , color ) , 'H' , 7 );
      }
      public void UndoMovement( Position _from , Position _to , Pieces _capturedPiece ) {

         Pieces piece = board.RemovePiece(_to);
         if ( _capturedPiece != null ) {
            board.PutPieces( _capturedPiece , _to );
            CapturedPieces.Remove( _capturedPiece );
         }
         board.PutPieces( piece , _from );

         if ( piece is King && _from.Columm + 2 == _to.Columm ) {

            Position fromCastle = new Position(_from.Line, _from.Columm + 3);
            Position toCastle = new Position(_from.Line, _from.Columm + 1);

            Pieces castle = board.RemovePiece(toCastle);
            castle.DecrementMovemente();
            board.PutPieces( castle , fromCastle );
         }
         if ( piece is King && _from.Columm - 2 == _to.Columm ) {

            Position fromCastle = new Position(_from.Line, _from.Columm - 4);
            Position toCastle = new Position(_from.Line, _from.Columm - 1);

            Pieces castle = board.RemovePiece(toCastle);
            castle.DecrementMovemente();
            board.PutPieces( castle , fromCastle );
         }
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