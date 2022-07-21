using board;

namespace Chess {
   internal class ChessPosition {

      public char Columm {
         get; set;
      }
      public int Line {
         get; set;
      }


      public ChessPosition( char _columm , int _line ) {

         Columm = _columm;
         Line = _line;
      }


      public Position ToPosition( ) {

         return ( new Position( 8 - Line , Columm - 'A' ) );

      }
      public override string ToString( ) {

         return "" + Columm + Line;
      }
   }
}
