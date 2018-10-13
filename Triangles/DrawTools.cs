using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Triangles
{
    public static class DrawTools
    {
        private static void SetPixel(Bitmap bitmap, int X, int Y,Color color)
        {
            if (X < 0 || Y < 0 || X >= bitmap.Width || Y >= bitmap.Height)
                return;
            bitmap.SetPixel(X, Y, color);
        }
        private static bool GetX(int Y, Point A, Point B, out int X)
        {
            if(B.Y == A.Y)
            {
                X = 0;
                return false;
            }
            X = (Y - A.Y) * (B.X - A.X) / (B.Y - A.Y) + A.X;
            return X >= Math.Min(A.X, B.X) && X <= Math.Max(A.X, B.X) && Y >= Math.Min(A.Y,B.Y) && Y <= Math.Max(A.Y, B.Y); 
        }
        public static void FillPolygon(Bitmap bitmap, List<Point> polygon, Color color)
        {
            if (polygon.Count < 3)
                return;
            int Ymin = polygon[0].Y;
            int Ymax = polygon[0].Y;
            foreach (var item in polygon)
            {
                if (item.Y > Ymax)
                    Ymax = item.Y;
                if (item.Y < Ymin)
                    Ymin = item.Y;
            }
            List<int> Xpoints = new List<int>();
            int X = 0;
            for (int Y = Ymin; Y <= Ymax; Y++)
            {
                Xpoints.Clear();
                for (int i = 0; i < polygon.Count; i++)
                {
                    if(polygon[i].Y == polygon[(i + 1) % polygon.Count].Y && polygon[i].Y == Y)
                    {
                        Xpoints.Add(polygon[i].X);
                        Xpoints.Add(polygon[(i + 1) % polygon.Count].X);
                    }
                    if (GetX(Y, polygon[i], polygon[(i + 1) % polygon.Count], out X) && ! Xpoints.Contains(X))
                        Xpoints.Add(X);
                }
                Xpoints.Sort();
                for (int index = 0; index < Xpoints.Count/2; index++)
                {
                    for (X = Xpoints[2 * index]; X <= Xpoints[2*index + 1]; X++)
                    {
                        SetPixel(bitmap, X, Y, color);
                    }
                }
            }
        }
        public static void DrawLine(Bitmap bitmap, Point A, Point B, Color color)
        {
            int Dx = Math.Abs(B.X - A.X);
            int Dy = Math.Abs(B.Y - A.Y);
            if(Dy == 0)
            {
                int Y = A.Y;
                for (int X = Math.Min(A.X, B.X); X < Math.Max(A.X, B.X); X++)
                {
                    SetPixel(bitmap, X, Y, color);
                }
                return;
            }
            if(Dx == 0)
            {
                int X = A.X;
                for (int Y = Math.Min(A.Y, B.Y); Y < Math.Max(A.Y, B.Y); Y++)
                {
                    SetPixel(bitmap, X, Y, color);
                }
                return;
            }
            if(Dx > Dy)
            {
                int Y = 0;
                for (int X = Math.Min(A.X, B.X); X < Math.Max(A.X,B.X); X++)
                {
                    Y = (X - A.X) * (B.Y - A.Y) / (B.X - A.X) + A.Y;
                    SetPixel(bitmap, X, Y, color);
                }
            }
            else
            {
                int X = 0;
                for (int Y = Math.Min(A.Y, B.Y); Y < Math.Max(A.Y,B.Y); Y++)
                {
                    X = (Y - A.Y) * (B.X - A.X) / (B.Y - A.Y) + A.X;
                    SetPixel(bitmap, X, Y, color);
                }
            }
        }
        public static void DrawPolygon(Bitmap bitmap, List<Point> polygon,Color color)
        {
            for (int index = 0; index < polygon.Count; index++)
                DrawLine(bitmap, polygon[index], polygon[(index + 1) % polygon.Count], color);
        }
        public static void DrawElipse(Bitmap bitmap, Point O, int A, int B, Color color)
        {
            int X = 0;
            int Y = 0;
            for (X = 0; X < A / Math.Sqrt(2); X++)
            {
                Y = YbyXEl(X, A, B);
                Set4Points(bitmap, O, color, X, Y);
            }
            for (Y = 0; Y < B/Math.Sqrt(2); Y++)
            {
                X = YbyXEl(Y, B, A);
                Set4Points(bitmap, O, color, X, Y);
            }
        }
        
        private static void Set4Points(Bitmap bitmap, Point O, Color color, int X, int Y)
        {
            SetPixel(bitmap, O.X + X, O.Y + Y, color);
            SetPixel(bitmap, O.X + X, O.Y - Y, color);
            SetPixel(bitmap, O.X - X, O.Y + Y, color);
            SetPixel(bitmap, O.X - X, O.Y - Y, color);
        }

        private static int YbyXEl(double X, double A, double B) => (int)(B * Math.Sqrt(1 - X * X / (A * A)));
    }
}
