using board;

namespace Chess {
   internal class King : Pieces {

      public King( Board _board , Color _color ) :
         base( _board , _color ) {
      }


      public override string ToString( ) {
         return "K";
      }
   }
}
