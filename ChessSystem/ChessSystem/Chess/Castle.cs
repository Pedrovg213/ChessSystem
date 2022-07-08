using board;

namespace Chess {
   internal class Castle : Pieces {

      public Castle( Board _board , Color _color ) :
         base( _board , _color ) {
      }


      public override string ToString( ) {
         return "C";
      }
   }
}
