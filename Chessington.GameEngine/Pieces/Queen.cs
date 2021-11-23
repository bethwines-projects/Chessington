using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {

            List<Square> availableMoves = new List<Square>();
            availableMoves.AddRange(GetDiagonalMoves(board));
            availableMoves.AddRange(GetLateralMoves(board));
            return RemoveFriendlySquaresFromList(availableMoves,board);
        }
    }
}