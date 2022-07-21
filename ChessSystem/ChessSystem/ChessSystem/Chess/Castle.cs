using board;

namespace Chess {
   internal class Castle : Pieces {

      public Castle( Board _board , Color _color ) :
         base( _board , _color ) {
      }


      public override bool[ , ] PossibleMoves( ) {

         bool[,] mat = new bool[board.Lines, board.Columns];

         Position position = new Position(0, 0);

         // up
         position.SetPosition( this.position.Line - 1 , this.position.Columm );

         while ( board.ValidatePosition( position ) && CanMove( position ) ) {

            mat[ position.Line , position.Columm ] = true;

            if ( board.GetPiece( position ) != null && board.GetPiece( position ).color != color )
               break;

            position.Line--;

         }

         // down
         position.SetPosition( this.position.Line + 1 , this.position.Columm );

         while ( board.ValidatePosition( position ) && CanMove( position ) ) {
            mat[ position.Line , position.Columm ] = true;

            if ( board.GetPiece( position ) != null && board.GetPiece( position ).color != color )
               break;

            position.Line++;
         }

         // right
         position.SetPosition( this.position.Line , this.position.Columm + 1 );

         while ( board.ValidatePosition( position ) && CanMove( position ) ) {
            mat[ position.Line , position.Columm ] = true;

            if ( board.GetPiece( position ) != null && board.GetPiece( position ).color != color )
               break;

            position.Columm++;
         }
         // left
         position.SetPosition( this.position.Line , this.position.Columm - 1 );

         while ( board.ValidatePosition( position ) && CanMove( position ) ) {
            mat[ position.Line , position.Columm ] = true;

            if ( board.GetPiece( position ) != null && board.GetPiece( position ).color != color )
               break;

            position.Columm--;
         }

         return mat;
      }
      public override string ToString( ) {
         return "C";
      }
   }
}
