using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        public IEnumerable<Square> GetLateralMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();

            for (int col = currentSquare.Col; col >=0; col--)
            {
                availableMoves.Add(new Square(currentSquare.Row,col));
            }
            
            for (int col = currentSquare.Col; col < 8; col++)
            {
                availableMoves.Add(new Square(currentSquare.Row,col));
            }
            
            for (int row = currentSquare.Row; row < 8; row++)
            {
                availableMoves.Add(new Square(row,currentSquare.Col));
            }
            
            for (int row = currentSquare.Row; row >= 0; row--)
            {
                availableMoves.Add(new Square(row,currentSquare.Col));
            }

            availableMoves.RemoveAll(x => x.Col == currentSquare.Col & x.Row == currentSquare.Row);
            return availableMoves;
        }
        
        public IEnumerable<Square> GetDiagonalMoves(Board board)
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