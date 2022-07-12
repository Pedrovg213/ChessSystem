using board;

namespace Chess {
   internal class Horse : Pieces {

      public Horse( Board _board , Color _color ) :
         base( _board , _color ) {
      }

      public override bool[ , ] PossibleMoves( ) {

         bool[,] mat = new bool[board.Lines, board.Columns];

         // Up-up-right
         Position position = new Position(this.position.Line+2, this.position.Columm+1);
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;

         // Up-right-right
         position.SetPosition( this.position.Line+1 , this.position.Columm+2 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;

         // Down-right-right
         position.SetPosition( this.position.Line - 1 , this.position.Columm + 2 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;

         // Down-down-right
         position.SetPosition( this.position.Line -2 , this.position.Columm + 1 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;

         // Down-down-left
         position.SetPosition( this.position.Line -2 , this.position.Columm - 1 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;

         // Down-left-left
         position.SetPosition( this.position.Line - 1 , this.position.Columm - 2 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;

         // Up-left-left
         position.SetPosition( this.position.Line + 1 , this.position.Columm - 2 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;

         // Up-up-left
         position.SetPosition( this.position.Line +2 , this.position.Columm -1 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;

         return mat;
      }
      public override string ToString( ) {
         return "H";
      }
   }
}
