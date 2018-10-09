using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Triangles
{
    public static class TrianglesTools
    {
        public static bool LineCross(Point A1, Point B1, Point A2, Point B2, out Point O)
        {
            O = new Point();
            double t1 = (A2.X - A1.X) * (B2.Y - A2.Y) + (B2.X - A2.X) * (A1.Y - A2.Y);
            double t2 = (B1.X - A1.X) * (B2.Y - A2.Y) - (B2.X - A2.X) * (B1.Y - A1.Y);
            double t = t1 / t2;
            if (t < 0 || t > 1)
                return false;
            t1 = (A1.X - A2.X) * (B1.Y - A1.Y) + (B1.X - A1.X) * (A2.Y - A1.Y);
            t2 = (B2.X - A2.X) * (B1.Y - A1.Y) - (B1.X - A1.X) * (B2.Y - A2.Y);
            t = t1 / t2;
            if (t < 0 || t > 1)
                return false;
            O = new Point((int)(A2.X + t * (B2.X - A2.X)), (int)(A2.Y + t * (B2.Y - A2.Y)));
            return true;
        }
        public static bool PointInTringle(Point A, Point B, Point C, Point O)
        {
            Point D = new Point(Math.Max(Math.Max(A.X, B.X), C.X) + 20, O.Y + 20);
            int count = 0;
            if (LineCross(A, B, O, D, out Point M))
                count++;
            if (LineCross(A, C, O, D, out M))
                count++;
            if (LineCross(B, C, O, D, out M))
                count++;
            return count == 1;
        }
        public static bool PointInTringle(List<Point> B, Point O) => PointInTringle(B[0], B[1], B[2], O);
        public static bool AinB(List<Point> A, List<Point> B)
        {
            foreach (var item in A)
            {
                if (!PointInTringle(B, item))
                    return false;
            }
            return true;
        }
        public static double Dist(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
        }
        public static List<Point> TriangleCross(List<Point> A, List<Point> B)
        {
            if (A.Count != 3 || B.Count != 3)
                throw new ArgumentException();
            if (AinB(A, B))
                return new List<Point>(A);
            if (AinB(B, A))
                return new List<Point>(B);
            List<Point> Cross = new List<Point>();
            for (int i = 0; i < A.Count; i++)
            {
                Point F = A[i], 
                    S = A[(i + 1) % 3];
                if (PointInTringle(B, F))
                    Cross.Add(F);
                bool L = false, R = false;
                List<Point> CrossPoints = new List<Point>();
                List<Point> InPoints = new List<Point>();
                for (int j = 0; j < B.Count; j++)
                {
                    Point F2 = B[j], S2 = B[(j + 1) % 3];
                    if(LineCross(F,S,F2,S2,out Point O))
                    {
                        CrossPoints.Add(O);
                        if (PointInTringle(A, F2) && !InPoints.Contains(F2))
                        {
                            InPoints.Add(F2);
                            if (CrossPoints.Count == 1)
                                L = true;
                            else
                                R = true;
                        }
                        if (PointInTringle(A, S2) && !InPoints.Contains(S2))
                        {
                            InPoints.Add(S2);
                            if (CrossPoints.Count == 1)
                                L = true;
                            else
                                R = true;
                        }
                    }
                }
                if(CrossPoints.Count == 1)
                {
                    Cross.Add(CrossPoints[0]);
                    if (Cross.Count >= 2 && Cross[Cross.Count - 2] == F && InPoints.Count != 0)
                        Cross.Add(InPoints[0]);
                }
                if (CrossPoints.Count == 2)
                {
                    if(Dist(CrossPoints[0],F) > Dist(CrossPoints[1],F))
                    {
                        CrossPoints.Reverse();
                        InPoints.Reverse();
                        bool t = R;
                        R = L;
                        L = t;
                    }
                    Cross.Add(CrossPoints[0]);
                    if(InPoints.Count == 2)
                    {
                        Cross.Add(InPoints[0]);
                        Cross.Add(InPoints[1]);
                    }
                    Cross.Add(CrossPoints[1]);
                    if(InPoints.Count == 1 && R)
                        Cross.Add(InPoints[0]);
                }
            }
            if (Cross.Count == 0)
                return null;
            return Cross;
        }
    }
}
