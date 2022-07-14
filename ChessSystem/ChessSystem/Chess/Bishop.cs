using board;

namespace Chess {
   internal class Bishop : Pieces {

      public Bishop( Board _board , Color _color ) :
         base( _board , _color ) {
      }


      public override bool[ , ] PossibleMoves( ) {
         
         bool[,] moves = new bool[board.Lines, board.Columns];
         Position checkPosition = new Position(0, 0);

         // up-right
         checkPosition.SetPosition( position.Line + 1 , position.Columm + 1 );
         while ( board.ValidatePosition( checkPosition ) && CanMove( checkPosition ) ) {
            moves[ checkPosition.Line , checkPosition.Columm ] = true;

            if ( board.GetPiece( checkPosition ) != null && board.GetPiece( checkPosition ).color != color )
               break;

            checkPosition.Line++;
            checkPosition.Columm++;
         }
         // up-left
         checkPosition.SetPosition( position.Line + 1 , position.Columm - 1 );
         while ( board.ValidatePosition( checkPosition ) && CanMove( checkPosition ) ) {
            moves[ checkPosition.Line , checkPosition.Columm ] = true;

            if ( board.GetPiece( checkPosition ) != null && board.GetPiece( checkPosition ).color != color )
               break;

            checkPosition.Line++;
            checkPosition.Columm--;
         }
         // down-right         
         checkPosition.SetPosition( position.Line - 1 , position.Columm + 1 );
         while ( board.ValidatePosition( checkPosition ) && CanMove( checkPosition ) ) {
            moves[ checkPosition.Line , checkPosition.Columm ] = true;

            if ( board.GetPiece( checkPosition ) != null && board.GetPiece( checkPosition ).color != color )
               break;

            checkPosition.Line--;
            checkPosition.Columm++;
         }
         // down-left
         checkPosition.SetPosition( position.Line - 1 , position.Columm - 1 );
         while ( board.ValidatePosition( checkPosition ) && CanMove( checkPosition ) ) {
            moves[ checkPosition.Line , checkPosition.Columm ] = true;

            if ( board.GetPiece( checkPosition ) != null && board.GetPiece( checkPosition ).color != color )
               break;

            checkPosition.Line--;
            checkPosition.Columm--;
         }


         return ( moves );
      }
      public override string ToString( ) {

         return "B";
      }
   }
}
