using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeAgnesIngrid
{
    public class Player
    {
        //Konstruktor, skaparen av "Spelaren"
        public Player(Piece p)
        {
            PlayerPiece = p;
        }


        public enum Piece { E, X, O };

        //egenskap för spelarens roll X/O ändras inte
        public Piece PlayerPiece { get; private set; }
    }
}