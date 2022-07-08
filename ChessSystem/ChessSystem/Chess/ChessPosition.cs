using board;

namespace Chess {
   internal class ChessPosition {

      public char Columm {
         get; set;
      }
      public int Line {
         get; set;
      }


      public ChessPosition( int _line , char _columm ) {

         Columm = _columm;
         Line = _line;
      }


      public Position ToPosition( ) {

         return new Position( 8 - Line , Columm - 'A' );
      }
      public override string ToString( ) {

         return "" + Columm + Line;
      }
   }
}
