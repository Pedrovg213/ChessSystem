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
   }
}
