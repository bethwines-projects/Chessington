using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();

            for (int i = currentSquare.Col, j = currentSquare.Row; i < 8 & j < 8; j++, i++)
            {
                availableMoves.Add(new Square(j,i));
            }
            for (int i = currentSquare.Col, j = currentSquare.Row; i >= 0 & j < 8; j++, i--)
            {
                availableMoves.Add(new Square(j,i));
            }
            for (int i = currentSquare.Col, j = currentSquare.Row; i < 8 & j >= 0; j--, i++)
            {
                availableMoves.Add(new Square(j,i));
            }
            for (int i = currentSquare.Col, j = currentSquare.Row; i >= 0 & j >= 0; j--, i--)
            {
                availableMoves.Add(new Square(j,i));
            }

            availableMoves.RemoveAll(x => x.Col == currentSquare.Col & x.Row == currentSquare.Row);
            return availableMoves;
        }
    }
}