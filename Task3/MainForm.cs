using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Triangles;
namespace Task3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        List<Point> A, B;
        float mult = 1;
        float multMax = 20;
        float speed = 0.005f;
        bool MoveActive = false;
        Point LastStart;
        Point Start = new Point(0, 0);
        Point ClickPoint;
        Bitmap clone;
        Bitmap bitmap;
        private void MainForm_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(output.Width, output.Height);
            A = new List<Point>();
            B = new List<Point>();
            Clear();
            output.MouseWheel += Output_MouseWheel;
        }

        private void Output_MouseWheel(object sender, MouseEventArgs e)
        {
            int X = (int)(e.X / mult) + Start.X;
            int Y = (int)(e.Y / mult) + Start.Y;
            mult += e.Delta * speed;
            mult = Math.Max(mult, 1);
            mult = Math.Min(mult, multMax);
            X -= (int)(e.X / mult);
            Y -= (int)(e.Y / mult);
            SetStart(X, Y);
            Upd();
        }

        private void Upd()
        {
            clone?.Dispose();
            clone = bitmap.Clone(new Rectangle(Start, new Size((int)(output.Width / mult), (int)(output.Height / mult))), bitmap.PixelFormat);
            output.Image = clone;
        }

        private void Clear()
        {
            bitmap?.Dispose();
            bitmap = new Bitmap(output.Width, output.Height);
            Graphics.FromImage(bitmap).Clear(Color.White);
            A.Clear();
            B.Clear();
            Upd();
        }

        private void ClearBtn_Click(object sender, EventArgs e) => Clear();

        private void output_MouseDown(object sender, MouseEventArgs e)
        {
            if (AddPointBtn.Checked && e.Button == MouseButtons.Left)
                AddPoint(new Point((int)(e.X / mult) + Start.X, (int)(e.Y / mult) + Start.Y));
            else
            {
                ClickPoint = e.Location;
                MoveActive = true;
                LastStart = Start;
            }
            Upd();
        }
        

        private void output_MouseUp(object sender, MouseEventArgs e) => MoveActive = false;

        private void output_MouseMove(object sender, MouseEventArgs e)
        {
            if(MoveActive)
            {
                int X = (int)((-e.X + ClickPoint.X) / mult) + LastStart.X;
                int Y = (int)((-e.Y + ClickPoint.Y) / mult) + LastStart.Y;
                SetStart(X, Y);
                Upd();
            }
        }

        private void SetStart(int X, int Y)
        {
            X = Math.Max(0, X);
            X = Math.Min((int)(output.Width * (1 - 1 / mult)), X);
            Y = Math.Max(0, Y);
            Y = Math.Min((int)(output.Height * (1 - 1 / mult)), Y);
            Start = new Point(X, Y);
        }

        private void AddPoint(Point Location)
        {
            int R = 3;
            if (A.Count < 3)
            {
                A.Add(Location);
                DrawTools.DrawElipse(bitmap, Location, R, R, Color.Green);
                if (A.Count == 3)
                    DrawTools.DrawPolygon(bitmap, A, Color.Green);
            }
            else if (B.Count < 3)
            {
                B.Add(Location);
                DrawTools.DrawElipse(bitmap, Location, R, R, Color.Red);
                if (B.Count == 3)
                {
                    DrawTools.DrawPolygon(bitmap, B, Color.Red);
                    List<Point> Cross = TrianglesTools.TriangleCross(A, B);
                    if (Cross != null)
                        DrawTools.FillPolygon(bitmap, Cross, Color.Blue);
                    A.Clear();
                    B.Clear();
                }
            }
        }
    }
}
