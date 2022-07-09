using board;

namespace Chess {
   internal class King : Pieces {

      public King( Board _board , Color _color ) :
         base( _board , _color ) {
      }


      public override bool[ , ] PossibleMoves( ) {

         bool[,] mat = new bool[board.Lines, board.Columns];

         Position position = new Position(0, 0);

         // up
         position.SetPosition( this.position.Line - 1 , this.position.Columm );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;
         // up-right
         position.SetPosition( this.position.Line - 1 , this.position.Columm + 1 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;
         // right
         position.SetPosition( this.position.Line , this.position.Columm + 1 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;
         // down-right
         position.SetPosition( this.position.Line + 1 , this.position.Columm + 1 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;
         // down
         position.SetPosition( this.position.Line + 1 , this.position.Columm );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;
         // down-left
         position.SetPosition( this.position.Line + 1 , this.position.Columm - 1 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;
         // left
         position.SetPosition( this.position.Line , this.position.Columm - 1 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;
         // up-left
         position.SetPosition( this.position.Line - 1 , this.position.Columm - 1 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            mat[ position.Line , position.Columm ] = true;

         return mat;
      }
      public override string ToString( ) {
         return "K";
      }
   }
}
