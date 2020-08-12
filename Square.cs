using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeAgnesIngrid
{
    public class Square
    {
        public Player.Piece SquarePiece { get; set; }

        public Square(Player.Piece s)
        {
            SquarePiece = s;
        }

        //EGEN ANTECKNING: Vilken datatyp? Jo, Piece. Vi vill kunna ändra vad som är i rutan eftersom brädet uppdateras
        //Egenskaper kan ha enkapsulation. Vi kan tex. välja om vi vill ha privat get/set detta kan inte instansvariabler göra


    }
}