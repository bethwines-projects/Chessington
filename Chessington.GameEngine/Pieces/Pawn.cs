using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            
            availableMoves.AddRange(GetAvailableDiagonalTakes(board));
            
            return availableMoves;
        }

        private List<Square> GetAvailableDiagonalTakes(Board board)
        {
            var currentSquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();

            var sign = 1;
            if (Player == Player.White)
            {
                sign = -1;
            }
            
            var diag1 = new Square(currentSquare.Row + sign, currentSquare.Col + 1);
            var diag2 = new Square(currentSquare.Row + sign, currentSquare.Col - 1);

            var diagonalList = new List<Square>() {diag1, diag2};

            foreach (var diag in diagonalList)
            {
                if (!diag.IsEmpty(board) && diag.Col >= 0 && diag.Col < 8 && diag.Row >= 0 && diag.Row < 8)
                {
                    if (board.GetPiece(diag).Player != Player)
                    {
                        availableMoves.Add(diag);
                    }
                }
            }

            return availableMoves;
        }
    }
}