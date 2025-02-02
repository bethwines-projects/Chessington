﻿using System;
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
            
            bool blocked = false;
            for (int col = currentSquare.Col-1; col >=0 && !blocked; col--)
            {
                availableMoves.Add(new Square(currentSquare.Row,col));
                blocked = !new Square(currentSquare.Row, col).IsEmpty(board);
            }
            
            blocked = false;
            for (int col = currentSquare.Col+1; col < 8 && !blocked; col++)
            {
                availableMoves.Add(new Square(currentSquare.Row,col));
                blocked = !new Square(currentSquare.Row, col).IsEmpty(board);
            }
            
            blocked = false;
            for (int row = currentSquare.Row+1; row < 8 && !blocked; row++)
            {
                availableMoves.Add(new Square(row,currentSquare.Col));
                blocked = !new Square(row,currentSquare.Col).IsEmpty(board);
            }
            
            blocked = false;
            for (int row = currentSquare.Row-1; row >= 0 && !blocked; row--)
            {
                availableMoves.Add(new Square(row,currentSquare.Col));
                blocked = !new Square(row,currentSquare.Col).IsEmpty(board);
            }

            availableMoves.RemoveAll(x => x.Col == currentSquare.Col & x.Row == currentSquare.Row);
            return availableMoves;
        }
        
        public IEnumerable<Square> GetDiagonalMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();
            
            bool blocked = false;
            for (int i = currentSquare.Col+1, j = currentSquare.Row+1; i < 8 && j < 8 && !blocked; j++, i++)
            {
                availableMoves.Add(new Square(j,i));
                blocked = !new Square(j,i).IsEmpty(board);
                
            }
            blocked = false;
            for (int i = currentSquare.Col-1, j = currentSquare.Row+1; i >= 0 && j < 8 && !blocked; j++, i--)
            {
                availableMoves.Add(new Square(j,i));
                blocked = !new Square(j,i).IsEmpty(board);
            }
            blocked = false;
            for (int i = currentSquare.Col+1, j = currentSquare.Row-1; i < 8 && j >= 0 && !blocked; j--, i++)
            {
                availableMoves.Add(new Square(j,i));
                blocked = !new Square(j,i).IsEmpty(board);
            }
            blocked = false;
            for (int i = currentSquare.Col-1, j = currentSquare.Row-1; i >= 0 && j >= 0 && !blocked; j--, i--)
            {
                availableMoves.Add(new Square(j,i));
                blocked = !new Square(j,i).IsEmpty(board);
            }

            availableMoves.RemoveAll(x => x.Col == currentSquare.Col & x.Row == currentSquare.Row);
            return availableMoves;
        }
        
        public List<Square> CheckSquareInBoundsAndAdd(List<Square> availablemoves, Square square)
        {
            if (0 <= square.Row & square.Row< 8 & 0 <= square.Col & square.Col < 8)
            {
                availablemoves.Add(square);
            }

            return availablemoves;
        }

        public List<Square> RemoveFriendlySquaresFromList(List<Square> list,Board board)
        {

            List<Square> newList = new List<Square>();
            
            foreach (var square in list)
            {
                switch (board.GetPiece(square) == null)
                {

                    case true:
                        newList.Add(square);
                        break;

                    case false:
                        if (board.GetPiece(square).Player != Player)
                        {
                            newList.Add(square);
                        }
                        break;
                }
            }
            return newList;
        }

    }
}