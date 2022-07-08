
namespace board {
   internal class Pieces {

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
   }
}
