using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();

            int i = 1;
            int j = 2;

            for (int k = 0; k < 4; k++)
            {
                availableMoves = CheckSquareInBoundsAndAdd(availableMoves, new Square(currentSquare.Row + j, currentSquare.Col + i));
                availableMoves = CheckSquareInBoundsAndAdd(availableMoves, new Square(currentSquare.Row + j, currentSquare.Col - i));
                var iTemp = i;
                i = -j;
                j = iTemp;
            }
            return RemoveFriendlySquaresFromList(availableMoves,board);
        }
    }
}