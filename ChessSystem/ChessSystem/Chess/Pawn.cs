using board;

namespace Chess {
   internal class Pawn : Pieces {

      public Pawn( Board _board , Color _color ) :
         base( _board , _color ) {
      }


      private bool HasEnemy( Position _position ) {

         Pieces piece = board.GetPiece( _position );

         return ( piece != null && piece.color != color );
      }
      public override bool[ , ] PossibleMoves( ) {
         bool[,] moves = new bool[board.Lines, board.Columns];
         Position checkPosition = new Position(0, 0);
         int id = color == Color.Black ? 1 : -1;


         // Up-right enemy
         checkPosition.SetPosition( position.Line + id , position.Columm + 1 );
         if ( board.ValidatePosition( checkPosition ) )
            moves[ checkPosition.Line , checkPosition.Columm ] = HasEnemy( checkPosition );
         // Up-right enemy
         checkPosition.SetPosition( position.Line + id , position.Columm - 1 );
         if ( board.ValidatePosition( checkPosition ) )
            moves[ checkPosition.Line , checkPosition.Columm ] = HasEnemy( checkPosition );
         // Up
         checkPosition.SetPosition( position.Line + id , position.Columm );
         if ( !HasEnemy( checkPosition ) && board.ValidatePosition( checkPosition ) )
            moves[ checkPosition.Line , checkPosition.Columm ] = CanMove( checkPosition );
         // first move
         checkPosition.SetPosition( position.Line + ( id * 2 ) , position.Columm );
         if ( QuantMoviment == 0 && !HasEnemy( checkPosition ) && board.ValidatePosition( checkPosition ) )
            moves[ checkPosition.Line , checkPosition.Columm ] = CanMove( checkPosition );

         return ( moves );
      }
      public override string ToString( ) {
         return "P";
      }
   }
}
