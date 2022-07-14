using board;

namespace Chess {
   internal class Queen : Pieces {

      public Queen( Board _board , Color _color ) :
         base( _board , _color ) {
      }


      public override bool[ , ] PossibleMoves( ) {

         bool[,] moves = new bool[board.Lines, board.Columns];
         Position checkPosition = new Position(0, 0);

         // Up
         checkPosition.SetPosition( position.Line - 1 , position.Columm );

         while ( board.ValidatePosition( checkPosition ) && CanMove( checkPosition ) ) {
            moves[ checkPosition.Line , checkPosition.Columm ] = true;

            if ( board.GetPiece( checkPosition ) != null && board.GetPiece( checkPosition ).color != color )
               break;

            checkPosition.Line--;
         }

         // down
         checkPosition.SetPosition( position.Line + 1 , position.Columm );

         while ( board.ValidatePosition( checkPosition ) && CanMove( checkPosition ) ) {
            moves[ checkPosition.Line , checkPosition.Columm ] = true;

            if ( board.GetPiece( checkPosition ) != null && board.GetPiece( checkPosition ).color != color )
               break;

            checkPosition.Line++;
         }

         // left
         checkPosition.SetPosition( position.Line , position.Columm - 1 );

         while ( board.ValidatePosition( checkPosition ) && CanMove( checkPosition ) ) {
            moves[ checkPosition.Line , checkPosition.Columm ] = true;

            if ( board.GetPiece( checkPosition ) != null && board.GetPiece( checkPosition ).color != color )
               break;

            checkPosition.Columm--;
         }

         // right
         checkPosition.SetPosition( position.Line , position.Columm + 1 );

         while ( board.ValidatePosition( checkPosition ) && CanMove( checkPosition ) ) {
            moves[ checkPosition.Line , checkPosition.Columm ] = true;

            if ( board.GetPiece( checkPosition ) != null && board.GetPiece( checkPosition ).color != color )
               break;

            checkPosition.Columm++;
         }

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
         return "Q";
      }
   }
}
