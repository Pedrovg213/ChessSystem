
namespace board {
   internal class Pieces {

      public Position position {
         get; private set;
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


      public Pieces( Board _board , Position _position , Color _color ) {
      
         board = _board;
         position = _position;
         color = _color;
         QuantMoviment = 0;
      }
   }
}
