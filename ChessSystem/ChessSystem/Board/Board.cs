using System;

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

         ValidatePosition( _position );
         return GetPiece( _position ) != null;
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
         pieces[ _position.Line , _position.Columm ] = _piece;
         _piece.position = _position;
      }
      public void ValidatePosition( Position _position ) {

         bool isValid =
            !( _position.Line < 0 ||
            _position.Line >= Lines ||
            _position.Columm < 0 ||
            _position.Columm >= Columns );

         if ( !isValid )
            throw new BoardException( "Invalid position." );
      }
   }
}
