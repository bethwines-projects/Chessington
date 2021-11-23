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
            return RemoveFriendlySquaresFromList(GetDiagonalMoves(board).ToList(),board);
        }
    }
}