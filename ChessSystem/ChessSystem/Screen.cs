using System;
using System.Collections.Generic;
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
            Console.Write( _piece + " " );
            Console.ForegroundColor = aux;
         }
      }
      public static Position ReadChessPosition( ) {

         string cPos = Console.ReadLine().ToUpper();

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
      public static void PrintBoard( Board _board , bool[ , ] _positions ) {

         ConsoleColor originBackGround = Console.BackgroundColor;
         ConsoleColor markBackGround = ConsoleColor.DarkGray;

         for ( int i = 0; i < _board.Lines; i++ ) {

            Console.Write( 8 - i + " " );

            for ( int j = 0; j < _board.Columns; j++ ) {

               Console.BackgroundColor =
                  _positions[ i , j ] ? markBackGround : originBackGround;

               WriteBoard( _board , i , j );
               Console.BackgroundColor = originBackGround;
            }

            Console.WriteLine();
            Console.BackgroundColor = originBackGround;
         }

         Console.WriteLine( "  A B C D E F G H" );
      }
      private static void PrintCapturedPieces( Playing _play ) {

         Console.WriteLine( "Captured Pieces:" );
         Console.Write( "White: " );
         PrintColor( _play.GetCapturedPieces( Color.White ) );
         Console.Write( "Black: " );
         Console.ForegroundColor = ConsoleColor.Yellow;
         PrintColor( _play.GetCapturedPieces( Color.Black ) );
         Console.ForegroundColor = ConsoleColor.Gray;
      }
      private static void PrintColor( HashSet<Pieces> _pieces ) {

         Console.Write( "[ " );
         foreach ( Pieces p in _pieces )
            Console.Write( p + " " );
         Console.WriteLine( "]" );
      }
      public static void PrintPlay( Playing _play ) {

         PrintBoard( _play.board );
         Console.WriteLine();
         PrintCapturedPieces( _play );
         Console.WriteLine();
         if ( !_play.Finished ) {

            Console.WriteLine( "Turn: " + _play.Turn );
            Console.WriteLine( "Waiting for player: " );
            if ( _play.Player == Color.Black ) {
               Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine( _play.Player.ToString().ToUpper() );
            if ( _play.Xeque ) {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine( "!!!YOU ARE IN CHECK!!!" );
            }
            Console.ForegroundColor = ConsoleColor.Gray;
         } else {
            Console.WriteLine( "!!!XEQUEMATE!!!" );
            if ( _play.Player == Color.Black )
               Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine( "Vencedor: " + _play.Player );
         }

      }
      public static void PrintPlay( Playing _play , bool[ , ] _positions ) {

         PrintBoard( _play.board , _positions );
         Console.WriteLine();
         PrintCapturedPieces( _play );
         Console.WriteLine();
         Console.WriteLine( "Turn: " + _play.Turn );
         Console.WriteLine( "Waiting for player: " );
         if ( _play.Player == Color.Black ) {
            Console.ForegroundColor = ConsoleColor.Yellow;
         }
         Console.WriteLine( _play.Player.ToString().ToUpper() );
         if ( _play.Xeque ) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine( "!!!YOU ARE IN CHECK!!!" );
         }
         Console.ForegroundColor = ConsoleColor.Gray;

      }
   }
}
