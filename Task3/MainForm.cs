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

        Bitmap bitmap;
        Graphics G;
        private void MainForm_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(output.Width, output.Height);
            G = Graphics.FromImage(bitmap);
            A = new List<Point>();
            B = new List<Point>();
            Clear();
        }
        private void Upd() => output.Image = bitmap;
        private void Clear()
        {
            G.Clear(Color.White);
            A.Clear();
            B.Clear();
            Upd();
        }

        private void ClearBtn_Click(object sender, EventArgs e) => Clear();

        private void output_MouseDown(object sender, MouseEventArgs e)
        {
            if(A.Count < 3)
            {
                A.Add(e.Location);
                if (A.Count == 3)
                    G.DrawPolygon(Pens.Green, A.ToArray());
            }
            else if(B.Count < 3)
            {
                B.Add(e.Location);
                if(B.Count == 3)
                {
                    G.DrawPolygon(Pens.Red, B.ToArray());
                    List<Point> Cross = TrianglesTools.TriangleCross(A, B);
                    if (Cross != null)
                        G.FillPolygon(Brushes.Blue, Cross.ToArray());
                    A.Clear();
                    B.Clear();
                }
            }
            Upd();
        }
    }
}
