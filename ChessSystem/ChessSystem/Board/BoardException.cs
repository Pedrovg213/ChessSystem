using System;

namespace board {
   internal class BoardException : Exception {

      public BoardException( string _message ) :
         base( _message ) {
      }
   }
}
