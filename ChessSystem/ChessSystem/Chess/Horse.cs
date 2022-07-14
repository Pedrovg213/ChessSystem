using board;

namespace Chess {
   internal class Horse : Pieces {

      public Horse( Board _board , Color _color ) :
         base( _board , _color ) {
      }


      public override bool[ , ] PossibleMoves( ) {

         bool[,] moves = new bool[board.Lines, board.Columns];
         Position checkPosition = new Position(0, 0);

         // up-up-right
         checkPosition.SetPosition( position.Line + 2 , position.Columm + 1 );
         if ( board.ValidatePosition( checkPosition ) )
            moves[ checkPosition.Line , checkPosition.Columm ] = CanMove( checkPosition );
         // up-right-right
         checkPosition.SetPosition( position.Line + 1 , position.Columm + 2 );
         if ( board.ValidatePosition( checkPosition ) )
            moves[ checkPosition.Line , checkPosition.Columm ] = CanMove( checkPosition );
         // up-up-left
         checkPosition.SetPosition( position.Line + 2 , position.Columm - 1 );
         if ( board.ValidatePosition( checkPosition ) )
            moves[ checkPosition.Line , checkPosition.Columm ] = CanMove( checkPosition );
         // up-left-left
         checkPosition.SetPosition( position.Line + 1 , position.Columm + 2 );
         if ( board.ValidatePosition( checkPosition ) )
            moves[ checkPosition.Line , checkPosition.Columm ] = CanMove( checkPosition );
         // down-down-right
         checkPosition.SetPosition( position.Line - 2 , position.Columm + 1 );
         if ( board.ValidatePosition( checkPosition ) )
            moves[ checkPosition.Line , checkPosition.Columm ] = CanMove( checkPosition );
         // down-right,right
         checkPosition.SetPosition( position.Line + 1 , position.Columm + 2 );
         if ( board.ValidatePosition( checkPosition ) )
            moves[ checkPosition.Line , checkPosition.Columm ] = CanMove( checkPosition );
         // down-down-left
         checkPosition.SetPosition( position.Line - 2 , position.Columm - 1 );
         if ( board.ValidatePosition( checkPosition ) )
            moves[ checkPosition.Line , checkPosition.Columm ] = CanMove( checkPosition );
         // down-left-left
         checkPosition.SetPosition( position.Line - 1 , position.Columm - 2 );
         if ( board.ValidatePosition( checkPosition ) )
            moves[ checkPosition.Line , checkPosition.Columm ] = CanMove( checkPosition );

         return ( moves );
      }
      public override string ToString( ) {
         return "H";
      }
   }
}
