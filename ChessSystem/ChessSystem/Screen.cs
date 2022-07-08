using System;
using board;
using Chess;

namespace ChessSystem {
   internal class Screen {

      static void WriteBoard( Board _board , int _line , int _columm ) {

         if ( _board.GetPiece( _line , _columm ) != null )
            WritePiece( _board.GetPiece( _line , _columm ) );
         else
            Console.Write( "- " );
      }
      static void WritePiece( Pieces _piece ) {

         if ( _piece.color == Color.White )
            Console.Write( _piece + " " );
         else {

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write( _piece + " ");
            Console.ForegroundColor = aux;
         }
      }
      public static Position ReadChessPosition( ) {

         string cPos = Console.ReadLine();

         char columm = cPos[0];
         int line = int.Parse(cPos[1] + "");

         return new ChessPosition( columm , line ).ToPosition();
      }
      public static void PrintBoard( Board _board ) {

         for ( int i = 0; i < _board.Lines; i++ ) {

            Console.Write( 8 - i + " " );

            for ( int j = 0; j < _board.Columns; j++ ) {

               WriteBoard( _board , i , j );
            }

            Console.WriteLine();
         }

         Console.WriteLine( "  A B C D E F G H" );
      }
   }
}
