using board;

namespace Chess {
   internal class King : Pieces {

      private Playing Play;


      public King( Playing _play , Board _board , Color _color ) :
         base( _board , _color ) {

         Play = _play;
      }


      private bool CheckForRoque( Position _position ) {

         Pieces castle = board.GetPiece(_position);

         return ( castle is Castle && castle.QuantMoviment == 0 && castle.color == color );
      }
      public override bool[ , ] PossibleMoves( ) {

         bool[,] moves = new bool[board.Lines, board.Columns];

         Position position = new Position(0, 0);

         // up
         position.SetPosition( this.position.Line - 1 , this.position.Columm );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            moves[ position.Line , position.Columm ] = true;
         // up-right
         position.SetPosition( this.position.Line - 1 , this.position.Columm + 1 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            moves[ position.Line , position.Columm ] = true;
         // right
         position.SetPosition( this.position.Line , this.position.Columm + 1 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            moves[ position.Line , position.Columm ] = true;
         // down-right
         position.SetPosition( this.position.Line + 1 , this.position.Columm + 1 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            moves[ position.Line , position.Columm ] = true;
         // down
         position.SetPosition( this.position.Line + 1 , this.position.Columm );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            moves[ position.Line , position.Columm ] = true;
         // down-left
         position.SetPosition( this.position.Line + 1 , this.position.Columm - 1 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            moves[ position.Line , position.Columm ] = true;
         // left
         position.SetPosition( this.position.Line , this.position.Columm - 1 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            moves[ position.Line , position.Columm ] = true;
         // up-left
         position.SetPosition( this.position.Line - 1 , this.position.Columm - 1 );
         if ( board.ValidatePosition( position ) && CanMove( position ) )
            moves[ position.Line , position.Columm ] = true;

         // check roque
         if ( QuantMoviment == 0 && !Play.Xeque ) {

            position.SetPosition( this.position.Line , this.position.Columm + 3 );

            if ( board.ValidatePosition( position ) ) {
               
               bool toRoqueFree =
                  board.GetPiece(this.position.Line, this.position.Columm + 1) == null &&
                  board.GetPiece(this.position.Line, this.position.Columm + 2) == null;
               
               if ( toRoqueFree )
                  moves[ this.position.Line , this.position.Columm +2 ] = CheckForRoque( position );
            }

            position.SetPosition( this.position.Line , this.position.Columm - 4 );
            if ( board.ValidatePosition( position ) ) {
               
               bool toRoqueFree =
                  board.GetPiece(this.position.Line, this.position.Columm - 1) == null &&
                  board.GetPiece(this.position.Line, this.position.Columm - 2) == null &&
                  board.GetPiece(this.position.Line, this.position.Columm - 3) == null;
               
               if ( toRoqueFree )
                  moves[ this.position.Line , this.position.Columm - 2 ] = CheckForRoque( position );
            }
         }


         return moves;
      }
      public override string ToString( ) {
         return "K";
      }
   }
}
