using board;

namespace Chess {
   internal class Pawn : Pieces {

      public Pawn( Board _board , Color _color ) : base( _board , _color ) {
      }


      private bool HasEnemy( Position _position ) {

         Pieces piece = board.GetPiece(_position);
         return piece != null && piece.color != color;
      }
      private bool IsFree( Position _position ) {

         return board.GetPiece( _position ) == null;
      }
      public override bool[ , ] PossibleMoves( ) {

         bool[,] mat = new bool[board.Lines, board.Columns];

         int id = color == Color.Black ? 1 : -1;

         Position position = new Position(this.position.Line+id, this.position.Columm -1);
         if ( HasEnemy( position ) && board.ValidatePosition( position ) )
            mat[ position.Line , position.Columm ] = true;

         position.SetPosition( this.position.Line + id , this.position.Columm + 1 );
         if ( HasEnemy( position ) && board.ValidatePosition( position ) )
            mat[ position.Line , position.Columm ] = true;

         position.SetPosition( this.position.Line + id , this.position.Columm );
         if ( IsFree( position ) && board.ValidatePosition( position ) )
            mat[ position.Line , position.Columm ] = true;

         if ( QuantMoviment == 0 && mat[this.position.Line+id, this.position.Columm] ) {
            position.SetPosition( this.position.Line + id * 2 , this.position.Columm );
            if ( IsFree( position ) && board.ValidatePosition( position ) )
               mat[ position.Line , position.Columm ] = true;

         }

         return mat;
      }
      public override string ToString( ) {
         return "P";
      }
   }
}
