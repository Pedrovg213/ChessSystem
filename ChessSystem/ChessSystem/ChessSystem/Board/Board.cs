using System;
using Chess;

namespace board {
   internal class Board {

      // Variables
      public int Lines {
         get; set;
      }
      public int Columns {
         get; set;
      }
      private Pieces[,] pieces;

      // Constructs
      public Board( int _lines , int _columns ) {

         Lines = _lines;
         Columns = _columns;
         pieces = new Pieces[ _lines , _columns ];
      }

      // Methods
      public bool HasPiece( Position _position ) {

         ValidatingPosition( _position );
         return ( GetPiece( _position ) != null );
      }
      public Pieces GetPiece( int _line , int _columm ) {

         return pieces[ _line , _columm ];
      }
      public Pieces GetPiece( Position _position ) {

         return pieces[ _position.Line , _position.Columm ];
      }
      public Pieces RemovePiece( Position _position ) {

         if ( GetPiece( _position ) == null )
            return null;

         Pieces aux = GetPiece(_position);
         aux.position = null;
         SetPiece( null , _position );

         return aux;
      }
      public void PutPieces( Pieces _piece , Position _position ) {

         if ( HasPiece( _position ) )
            throw new BoardException( "This position already has a piece." );
         SetPiece( _piece , _position );
         _piece.position = _position;
      }
      public void PutPieces( Pieces _piece , char _columm , int _line ) {

         PutPieces( _piece , new ChessPosition( _columm , _line ).ToPosition() );
      }
      public void SetPiece( Pieces _piece , Position _position ) {

         pieces[ _position.Line , _position.Columm ] = _piece;
      }
      public bool ValidatePosition( Position _position ) {

         if ( _position.Line < 0 || _position.Line >= Lines || _position.Columm < 0 || _position.Columm >= Columns )
            return false;

         return true;
      }
      public void ValidatingPosition( Position _position ) {

         if ( !ValidatePosition( _position ) )
            throw new BoardException( "Invalid position." );
      }
   }
}
