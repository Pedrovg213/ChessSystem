
namespace board {
   abstract internal class Pieces {

      public Color color {
         get; protected set;
      }
      public Board board {
         get; protected set;
      }
      public Position position {
         get; set;
      }
      public int QuantMoviment {
         get; set;
      }


      public Pieces( Board _board , Color _color ) {

         board = _board;
         color = _color;
         position = null;
         QuantMoviment = 0;
      }


      protected bool CanMove( Position _position ) {

         Pieces piece = board.GetPiece(_position);

         return ( piece == null || piece.color != color );
      }
      public bool CanMoveTo( Position _position ) {

         return PossibleMoves()[ _position.Line , _position.Columm ];
      }
      public abstract bool[ , ] PossibleMoves( );
      public bool HasPossibleMoves( ) {

         foreach ( bool isPossible in PossibleMoves() )
            if ( isPossible )
               return isPossible;

         return false;
      }
      public void IncremetMoviment( ) {

         QuantMoviment++;
      }
      public void DecrementMovemente( ) {

         QuantMoviment--;
      }
   }
}
