using Ruaraidheulib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menace
{
    public class Board
    {
        public enum Players
        {
            E, X, O 
        }
        Players[,] _board;
        public Players[,] board
        {
            get { return _board; }
        }
        int width;
        public int Width
        {
            get { return width; }
        }
        int height;
        public int Height
        {
            get { return height; }
        }
        public Board(int w, int h)
        {
            width = w;
            height = h;
            _board = new Players[w, h];
        }
        public void Play(Players p, int w, int h)
        {
            if (w <= width && h <= height)
            {
                _board[w, h] = p;
            }
        }
        public bool IsWon()
        {
            for (int a = 0; a < width; a++)
            { 
                bool win = true;
                Players i = _board[a, 0];
                if (i != Players.E)
                {
                    for (int b = 0; b < height; b++)
                    {
                        if (_board[a, b] != i)
                        {
                            win = false;
                            break;
                        }
                    }
                    if (win)
                    {
                        return win;
                    }
                }
            }
            for (int a = 0; a < height; a++)
            {
                bool win = true;
                Players i = _board[a, 0];
                if (i != Players.E)
                {
                    for (int b = 0; b < width; b++)
                    {
                        if (_board[b, a] != i)
                        {
                            win = false;
                            break;
                        }
                    }
                    if (win)
                    {
                        return win;
                    }
                }
            }
            if (width == height)
            {
                bool win = true;
                Players i = _board[0, 0];
                if (i != Players.E)
                {
                    for (int b = 0; b < height; b++)
                    {
                        if (_board[b, b] != i)
                        {
                            win = false;
                            break;
                        }
                    }
                    if (win)
                    {
                        return win;
                    }
                }
                win = true;
                i = _board[width-1, 0];
                if (i != Players.E)
                {
                    for (int b = 0; b < height; b++)
                    {
                        if (_board[(width-1) - b, b] != i)
                        {
                            win = false;
                            break;
                        }
                    }
                    if (win)
                    {
                        return win;
                    }
                }
            }
            return false;
        }
        public Players WhoWon()
        {
            return 0;
        }
    }
}
