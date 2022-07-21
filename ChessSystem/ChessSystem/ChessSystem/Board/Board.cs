using System;
using Chess;

namespace board {
   internal class Board {

      private Pieces[,] pieces;
      public int Lines {
         get; set;
      }
      public int Columns {
         get; set;
      }


      public Board( int _lines , int _columns ) {

         Lines = _lines;
         Columns = _columns;
         pieces = new Pieces[ _lines , _columns ];
      }


      private bool HasPiece( Position _position ) {

         ValidatingPosition( _position );
         return ( GetPiece( _position ) != null );
      }
      private void SetPiece( Pieces _piece , Position _position ) {

         pieces[ _position.Line , _position.Columm ] = _piece;
      }
      private void ValidatingPosition( Position _position ) {

         if ( !ValidatePosition( _position ) )
            throw new BoardException( "Invalid position." );
      }
      public Pieces GetPiece( int _line , int _columm ) {

         return pieces[ _line , _columm ];

      }
      public Pieces GetPiece( Position _position ) {

         return pieces[ _position.Line , _position.Columm ];
      }
      public void PutPieces( Pieces _piece , Position _position ) {

         if ( HasPiece( _position ) )
            throw new BoardException( "This position already has a piece." );
         SetPiece( _piece , _position );
         _piece.position = _position;
      }      
      public Pieces RemovePiece( Position _position ) {

         if ( GetPiece( _position ) == null )
            return null;

         Pieces aux = GetPiece(_position);
         aux.position = null;
         SetPiece( null , _position );

         return aux;
      }
      public bool ValidatePosition( Position _position ) {

         if ( _position.Line < 0 || _position.Line >= Lines || _position.Columm < 0 || _position.Columm >= Columns )
            return false;

         return true;
      }
   }
}
