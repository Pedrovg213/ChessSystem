
namespace board {
   abstract internal class Pieces {

      public Position position {
         get; set;
      }
      public Color color {
         get; protected set;
      }
      public int QuantMoviment {
         get; set;
      }
      public Board board {
         get; protected set;
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
      public abstract bool[ , ] PossibleMoves( );
      public void IncremetMoviment( ) {

         QuantMoviment++;
      }
   }
}
