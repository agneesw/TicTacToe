using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeAgnesIngrid
{
    public class TicTacToe
    {
        Board board;
        Player player1;
        Player player2;
        Player currentPlayer;


        public void StartGame()
        {

            board = new Board(3);
            player1 = new Player(Player.Piece.X);
            player2 = new Player(Player.Piece.O);
            currentPlayer = player1;


            while (true)
            {
                try
                {


                    Board();


                    Console.WriteLine(" ");
                    Console.WriteLine("Välj en plats!");

                    while (true)
                    {

                        int position = Convert.ToInt32(Console.ReadLine());

                        if (board.IsPositionAvaliable(position))
                        {
                            board.GetCurrentGameState()[position].SquarePiece = currentPlayer.PlayerPiece;
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Nej! Den här platsen är upptagen!");
                        }

                    }

                    if (CheckIfWin())
                    {
                        Console.WriteLine("DU VANN! Människor är smartare än robotar!");
                        Board();

                        break;
                    }

                    if (CheckIfDraw())
                    {
                        Console.WriteLine("Det är oavgjort!");
                        Board();
                        break;
                    }

                    Byt();
                    Console.WriteLine("Nu är det AI:s tur");
                    MakeRandomAIMove();

                    if (CheckIfWin())
                    {
                        Console.WriteLine("AI VANN! Robotar är smartare än människor!");
                        Board();

                        break;
                    }

                    if (CheckIfDraw())
                    {
                        Console.WriteLine("Det är oavgjort!");
                        Board();
                        break;
                    }

                    Byt();

                    Console.Clear();


                }

                catch
                {
                    Console.WriteLine("Nämen, nu är du ute och cyklar. Du får bara skriva siffror som finns på brädet. 0 t.om. sista tal");
                }

            }
        }


        private void Board()

        {

            List<Square> list = board.GetCurrentGameState();

            Console.WriteLine("|     |     |     |");

            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", list[0].SquarePiece, list[1].SquarePiece, list[2].SquarePiece);

            Console.WriteLine("|_____|_____|_____|");

            Console.WriteLine("|     |     |     |");

            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", list[3].SquarePiece, list[4].SquarePiece, list[5].SquarePiece);

            Console.WriteLine("|_____|_____|_____|");

            Console.WriteLine("|     |     |     |");

            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", list[6].SquarePiece, list[7].SquarePiece, list[8].SquarePiece);

            Console.WriteLine("|_____|_____|_____|");


        }

        private void Byt()
        {
            if (currentPlayer == player1)
            {
                currentPlayer = player2;
            }
            else
            {
                currentPlayer = player1;
            }

        }

        public bool CheckIfDraw()
        {
            List<Square> list = board.GetCurrentGameState();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].SquarePiece == Player.Piece.E)
                {
                    return false;
                }

            }

            return true;
        }

        public bool CheckIfWin()
        {
            if (CheckIfWinVågrätt())
            {
                return true;
            }

            else if (CheckIfWinLodrätt())
            {
                return true;
            }


            else if (CheckIfWinDiagonalt())
            {
                return true;
            }

            else if (CheckIfWinAntidiagonal())
            {
                return true;
            }

            return false;

        }

        public bool CheckIfWinVågrätt()
        {

            int checka = 0;

            List<Square> list = board.GetCurrentGameState();
            for (int i = 0; i < board.Radlängd * board.Radlängd; i += board.Radlängd)
            {

                for (int j = i; j < i + board.Radlängd; j++)
                {
                    if (list[j].SquarePiece == currentPlayer.PlayerPiece)
                    {
                        checka++;
                    }
                }
                if (checka == board.Radlängd)
                {
                    return true;
                }
                checka = 0;
            }
            return false;

        }

        public bool CheckIfWinLodrätt()
        {
            int checka = 0;

            List<Square> list = board.GetCurrentGameState();


            for (int i = 0; i < board.Radlängd; i++)
            {
                for (int j = i; j < board.Radlängd * board.Radlängd; j += board.Radlängd)
                {
                    if (list[j].SquarePiece == currentPlayer.PlayerPiece)
                    {
                        checka++;
                    }

                }

                if (checka == board.Radlängd)
                {
                    return true;
                }
                checka = 0;
            }


            return false;
        }

        public bool CheckIfWinDiagonalt()
        {
            int checka = 0;

            List<Square> list = board.GetCurrentGameState();
            for (int i = 0; i < board.Radlängd * board.Radlängd; i += board.Radlängd + 1)
            {
                if (list[i].SquarePiece == currentPlayer.PlayerPiece)
                {
                    checka++;
                }

                if (checka == board.Radlängd)
                {
                    return true;
                }
            }
            return false;

        }

        public bool CheckIfWinAntidiagonal()
        {
            int checka = 0;

            List<Square> list = board.GetCurrentGameState();
            for (int i = board.Radlängd - 1; i < (board.Radlängd * board.Radlängd) - 1; i += board.Radlängd - 1)
            {
                if (list[i].SquarePiece == currentPlayer.PlayerPiece)
                {
                    checka++;
                }

                if (checka == board.Radlängd)
                {
                    return true;
                }

            }
            return false;
        }

        public void MakeRandomAIMove()
        {
            Random rnd = new Random();


            bool söt = true;


            while (söt == true)
            {

                int choice = rnd.Next(1, board.Radlängd * board.Radlängd);

                if (board.IsPositionAvaliable(choice) == true)
                {
                    board.GetCurrentGameState()[choice].SquarePiece = currentPlayer.PlayerPiece;
                    söt = false;
                }

            }

        }

    }
}
