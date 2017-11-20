using Ruaraidheulib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Menace.Board;
using static Ruaraidheulib.List;

namespace Menace
{
    public class Mboard
    {
        Players[,] board;
        int[,] databoard;

        Random r;

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
        public int NoMoves
        {
            get
            {
                int val = 0;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (board[i,j] != Players.E)
                        {
                            val++;
                        }
                    }
                }
                return val;
            }
        }
        public Mboard(int w, int h)
        {
            width = w;
            height = h;
            board = new Players[w, h];
            databoard = new int[w, h];
            r = new Random();
        }
        public void Setboard(Players p, int x, int y)
        {
            board[x, y] = p;
        }
        public void Setval(int val)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (board[i,j] == Players.E)
                    {
                        databoard[i, j] = val;
                    }
                }
            }
        }
        public void Changeval(int val, int x, int y)
        {
            databoard[x, y] += val;
        }
        public bool Pickpos(out int x, out int y)
        {
            int tot = 0;
            foreach(int i in databoard)
            {
                tot += i;
            }
            int val = r.Next(tot)+1;
            int curval = 0;
            for (int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    curval += databoard[i,j];
                    if (curval >= val)
                    {
                        x = i;
                        y = j;
                        return false;
                    }
                }
            }
            x = 0;
            y = 0;
            return true;

        }
        public Players Getloc(int x, int y)
        {
            return board[x, y];
        }
        public bool BoardEqual(Mboard mb)
        {
            if (width == mb.width)
            {
                if (height == mb.height)
                {
                    if (board.To1DList().SequenceEqual(mb.board.To1DList()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool BoardEqual(Board mb)
        {
            if (width == mb.Width)
            {
                if (height == mb.Height)
                {
                    if (board.To1DList().SequenceEqual(mb.board.To1DList()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool Equals(Mboard mb)
        {
            List<Players> brd = board.Cast<Players>().ToList();
            List<Players> brd2 = mb.board.Cast<Players>().ToList();
            List<int> dbrd = databoard.Cast<int>().ToList();
            List<int> dbrd2 = mb.databoard.Cast<int>().ToList();
            if (width == mb.width)
            {
                if (height == mb.height)
                {
                    if (brd.SequenceEqual(brd2))
                    {
                        if (dbrd.SequenceEqual(dbrd2))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
    public class MenaceAI
    {
        public List<Mboard> mb;
        List<int> currentgame;
        List<Twoint> loc;
        public MenaceAI(int w, int h)
        {
            mb = new List<Mboard>();
            currentgame = new List<int>();
            loc = new List<Twoint>();
            
            for (int i = 0; i < Math.Pow(3, w*h); i++)
            {
                int c = i;
                mb.Add(new Mboard(3, 3));
                for (int j = 0; j < w*h; ++j)
                {
                    mb.Last().Setboard((Players)(c%3), j%w, j/h);
                    c /= 3;
                }
                mb.Last().Setval((w*h)-mb.Last().NoMoves);
            }

            List<Mboard> tmp = mb.OrderBy(o=>o.NoMoves).ToList();
            mb = tmp;

            #region Failed
            //int[] arr = new int[w * h* 2];

            //for (int i = 0; i < w*h; i++)
            //{
            //    Mbrecurse(arr, i*2, 0, w, h);
            //}



            //mb.Add(new Mboard(w, h));
            //for (int i = 0; i < w; i++)
            //{
            //    for (int j = 0; j < h; j++)
            //    {
            //        Mbsetup(w, h, 2);
            //        mb.Add(new Mboard(w, h));
            //        mb.Last().Setboard(Players.X, i, j);
            //    }
            //}
            //for (int i = 0; i < w; i++)
            //{
            //    for (int j = 0; j < h; j++)
            //    {
            //        for (int k = 0; k < w; k++)
            //        {
            //            for (int l = 0; l < h; l++)
            //            {
            //                mb.Add(new Mboard(w, h));
            //                if (mb.Last().Getloc(i, j) == Players.E)
            //                {
            //                    mb.Last().Setboard(Players.X, i, j);
            //                }
            //                if (mb.Last().Getloc(k, l) == Players.E)
            //                {
            //                    mb.Last().Setboard(Players.O, k, l);
            //                }
            //            }
            //        }
            //    }
            //}
            //for (int i = 0; i < w; i++)
            //{
            //    for (int j = 0; j < h; j++)
            //    {
            //        for (int k = 0; k < w; k++)
            //        {
            //            for (int l = 0; l < h; l++)
            //            {
            //                for (int m = 0; m < w; m++)
            //                {
            //                    for (int n = 0; n < h; n++)
            //                    {
            //                        mb.Add(new Mboard(w, h));
            //                        mb.Last().Setboard(Players.X, i, j);
            //                        if (mb.Last().Getloc(k, l) == Players.E)
            //                        {
            //                            mb.Last().Setboard(Players.O, k, l);
            //                        }
            //                        if (mb.Last().Getloc(m, n) == Players.E)
            //                        {
            //                            mb.Last().Setboard(Players.X, m, n);
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //for (int i = 0; i < w; i++)
            //{
            //    for (int j = 0; j < h; j++)
            //    {
            //        for (int k = 0; k < w; k++)
            //        {
            //            for (int l = 0; l < h; l++)
            //            {
            //                for (int m = 0; m < w; m++)
            //                {
            //                    for (int n = 0; n < h; n++)
            //                    {
            //                        for (int o = 0; o < w; o++)
            //                        {
            //                            for (int p = 0; p < h; p++)
            //                            {
            //                                mb.Add(new Mboard(w, h));
            //                                mb.Last().Setboard(Players.X, i, j);
            //                                if (mb.Last().Getloc(k, l) == Players.E)
            //                                {
            //                                    mb.Last().Setboard(Players.O, k, l);
            //                                }
            //                                if (mb.Last().Getloc(m, n) == Players.E)
            //                                {
            //                                    mb.Last().Setboard(Players.X, m, n);
            //                                }
            //                                if (mb.Last().Getloc(o, p) == Players.E)
            //                                {
            //                                    mb.Last().Setboard(Players.O, o, p);
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion
        }
        public int Findboard(Board b)
        {
            for(int i = 0; i < mb.Count; i++)
            {
                if (mb[i].BoardEqual(b))
                {
                    return i;
                }
            }
            return 0;
        }
        public void Play(Board b)
        {
            currentgame.Add(Findboard(b));
            Twoint ti = new Twoint();
            mb[currentgame.Last()].Pickpos(out ti._x, out ti._y);
            loc.Add(ti);
        }
        public void HasWon()
        {
            Loop.Foreach<int>(currentgame, (a) => 
            {
                mb[a].Changeval(3, loc[a].X, loc[a].Y);
            });
        }
        public void HasLost()
        {
            Loop.Foreach<int>(currentgame, (a) =>
            {
                mb[a].Changeval(-1, loc[a].X, loc[a].Y);
            });
        }
        public void Newgame()
        {
            currentgame.Clear();
            loc.Clear();
        }

        [Obsolete]
        void Mbsetup(int w, int h, int[] arr, int depth)
        {
            mb.Add(new Mboard(w, h));
            for (int i = 0; i < depth/2; i++)
            {
                if (mb.Last().Getloc(arr[i * 2], arr[(i * 2) + 1]) == Players.E)
                {
                    mb.Last().Setboard((Players)((i % 2) + 1), arr[i * 2], arr[(i * 2) + 1]);
                }
                else
                {
                    mb.RemoveAt(mb.Count - 1);
                    break;
                }
            }
        }
        [Obsolete]
        void Mbrecurse(int[] arr, int totdepth, int depth, int w, int h)
        {
            if (depth == totdepth)
            {
                Mbsetup(w, h, arr, totdepth);
                return;
            }
            if (depth % 2 == 0)
            {
                for (int i = 0; i < w; i++)
                {
                    arr[depth] = i;
                    Mbrecurse(arr, totdepth, depth + 1, w, h);
                }
            }
            else
            {
                for (int i = 0; i < h; i++)
                {
                    arr[depth] = i;
                    Mbrecurse(arr, totdepth, depth + 1, w, h);
                }
            }
        }
    }
}
