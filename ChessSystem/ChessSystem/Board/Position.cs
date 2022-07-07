
namespace board {
   internal class Position {
      public int Line {
         get; private set;
      }
      public int Columm {
         get; private set;
      }


      public Position( int _line , int _columm ) {
      
         Line = _line;
         Columm = _columm;
      }


      public override string ToString( ) {
         
         return $"position: {Line} , {Columm}";
      }
   }
}
