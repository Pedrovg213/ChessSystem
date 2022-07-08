using System;

namespace board {
   internal class Board {

      public int Lines {
         get; set;
      }
      public int Columns {
         get; set;
      }
      private Pieces[,] pieces;


      public Board( int _lines , int _columns ) {

         Lines = _lines;
         Columns = _columns;
         pieces = new Pieces[ _lines , _columns ];
      }


      public Pieces Pieces( int _line , int _columm ) {

         return pieces[ _line , _columm ];
      }
      public void PutPieces( Pieces _piece , Position _position ) {

         pieces[ _position.Line , _position.Columm ] = _piece;
         _piece.position = _position;
      }
   }
}
