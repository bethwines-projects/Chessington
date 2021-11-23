using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        private IEnumerable<Square> GetPotentialMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();

            switch (this.Player)
            {
                case Player.White:
                    availableMoves = CheckSquareInBoundsAndAdd( availableMoves, new Square(currentSquare.Row - 1, currentSquare.Col));
                    
                    if (currentSquare.Row == 6)
                    {
                        availableMoves.Add(new Square(currentSquare.Row - 2, currentSquare.Col));
                    }

                    break;
                    
                case Player.Black:
                    availableMoves = CheckSquareInBoundsAndAdd( availableMoves, new Square(currentSquare.Row + 1, currentSquare.Col));
                    
                    if (currentSquare.Row == 1)
                    {
                        availableMoves.Add(new Square(currentSquare.Row + 2, currentSquare.Col));
                    }
                    break;
            }

            return availableMoves;
            
            
            
            
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> potentialMoves = GetPotentialMoves(board).ToList();
            List<Square> availableMoves = new List<Square>();

            if (potentialMoves.Count >0 && potentialMoves[0].IsEmpty(board))
            {
                availableMoves.Add(potentialMoves[0]);
                
                if (potentialMoves.Count == 2 & potentialMoves[potentialMoves.Count-1].IsEmpty(board))
                {
                    availableMoves.Add(potentialMoves[1]);
                }
            }

            return availableMoves;
        }
    }
}