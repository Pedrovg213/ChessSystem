
namespace board {
   internal class Position {

      public int Line {
         get; set;
      }
      public int Columm {
         get; set;
      }


      public Position( int _line , int _columm ) {

         if ( _line > 7 || _line < 0 || _columm > 7 || _columm < 0 )
            throw new BoardException( "Invalid Position." );

         Line = _line;
         Columm = _columm;

      }


      public override string ToString( ) {

         return $"position: {Line} , {Columm}";
      }
      public void SetPosition( int _line , int _columm ) {

         Line = _line;
         Columm = _columm;
      }
   }
}
