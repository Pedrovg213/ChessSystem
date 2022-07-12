using board;

namespace Chess {
   internal class Bishop : Pieces {

      public Bishop( Board _board , Color _color ) :
         base( _board , _color ) {
      }


      public override bool[ , ] PossibleMoves( ) {

         bool[,] mat = new bool[board.Lines, board.Columns];

         // Up-right
         Position position = new Position(this.position.Line+1, this.position.Columm+1);

         while (board.ValidatePosition(position) && CanMove( position ) ) {
            mat[ position.Line , position.Columm ] = true;

            if ( board.GetPiece( position ) != null && board.GetPiece( position ).color != color )
               break;

            position.Line++;
            position.Columm++;
         }
         // Down-right
         position.SetPosition(this.position.Line-1, this.position.Columm+1);

         while ( board.ValidatePosition( position ) && CanMove( position ) ) {
            mat[ position.Line , position.Columm ] = true;

            if ( board.GetPiece( position ) != null && board.GetPiece( position ).color != color )
               break;

            position.Line--;
            position.Columm++;
         }
         // Down-left
         position.SetPosition(this.position.Line-1, this.position.Columm-1);

         while ( board.ValidatePosition( position ) && CanMove( position ) ) {
            mat[ position.Line , position.Columm ] = true;

            if ( board.GetPiece( position ) != null && board.GetPiece( position ).color != color )
               break;

            position.Line--;
            position.Columm--;
         }
         // Up-left
         position.SetPosition(this.position.Line+1, this.position.Columm-1);

         while ( board.ValidatePosition( position ) && CanMove( position ) ) {
            mat[ position.Line , position.Columm ] = true;

            if ( board.GetPiece( position ) != null && board.GetPiece( position ).color != color )
               break;

            position.Line++;
            position.Columm--;
         }

         return mat;
      }


      public override string ToString( ) {
         return "B";
      }
   }
}
