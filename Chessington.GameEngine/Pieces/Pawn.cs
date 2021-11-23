using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();

            switch (this.Player)
            {
                case Player.White:
                    availableMoves.Add(new Square(currentSquare.Row-1,currentSquare.Col));
                    break;
                case Player.Black:
                    availableMoves.Add(new Square(currentSquare.Row+1,currentSquare.Col));
                    break;
            }

            return availableMoves;
        }
    }
}