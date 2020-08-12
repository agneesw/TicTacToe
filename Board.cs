using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeAgnesIngrid
{
    public class Board
    {

        List<Square> SquareList;

        public int Radlängd { get; private set; }



        public Board(int radlängd)
        {

            SquareList = new List<Square>();
            Radlängd = radlängd;

            for (int i = 0; i < Radlängd * Radlängd; i++)
            {
                SquareList.Add(new Square(Player.Piece.E));
            }


        }

        public List<Square> GetCurrentGameState()
        {
            return SquareList;
        }


        public bool IsPositionAvaliable(int pos)
        {

            return SquareList[pos].SquarePiece == Player.Piece.E;

        }


    }
}