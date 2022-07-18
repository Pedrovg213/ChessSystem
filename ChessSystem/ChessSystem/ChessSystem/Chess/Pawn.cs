using board;

namespace Chess {
   internal class Pawn : Pieces {

      private Playing Play;


      public Pawn( Playing _play , Board _board , Color _color ) :
         base( _board , _color ) {

         Play = _play;
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
         if ( board.ValidatePosition( checkPosition ) )
            if ( !HasEnemy( checkPosition ) )
               moves[ checkPosition.Line , checkPosition.Columm ] = CanMove( checkPosition );
         // first move
         checkPosition.SetPosition( position.Line + ( id * 2 ) , position.Columm );
         if ( board.ValidatePosition( checkPosition ) )
            if ( QuantMoviment == 0 && !HasEnemy( checkPosition ) )
               moves[ checkPosition.Line , checkPosition.Columm ] = CanMove( checkPosition );

         // En Passant
         int passantLine = color == Color.Black ? 4 : 3;

         if ( position.Line == passantLine ) {

            Position left = new Position(position.Line, position.Columm -1);
            if ( board.ValidatePosition( left ) )
               if ( HasEnemy( left ) && board.GetPiece( left ) == Play.EnPassant )
                  moves[ left.Line + id , left.Columm ] = true;

            Position right = new Position(position.Line, position.Columm+1);
            if ( board.ValidatePosition( right ) )
               if ( HasEnemy( right ) && board.GetPiece( right ) == Play.EnPassant )
                  moves[ right.Line + id , right.Columm ] = true;
         }

         return ( moves );
      }
      public override string ToString( ) {
         return "P";
      }
   }
}
