namespace LR5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                float x1 = float.Parse(textBox1.Text);
                float y1 = float.Parse(textBox2.Text);
                float x2 = float.Parse(textBox3.Text);
                float y2 = float.Parse(textBox4.Text);
                float x3 = float.Parse(textBox5.Text);
                float y3 = float.Parse(textBox6.Text);
                float x4 = float.Parse(textBox7.Text);
                float y4 = float.Parse(textBox8.Text);

                panel1.Refresh();
                DrawBezierCurve(x1, y1, x2, y2, x3, y3, x4, y4);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DrawBezierCurve(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Blue, 2);

            g.DrawRectangle(pen, x1 - 2, y1 - 2, 4, 4);
            g.DrawRectangle(pen, x2 - 2, y2 - 2, 4, 4);
            g.DrawRectangle(pen, x3 - 2, y3 - 2, 4, 4);
            g.DrawRectangle(pen, x4 - 2, y4 - 2, 4, 4);

            PointF[] points = { new PointF(x1, y1), new PointF(x2, y2), new PointF(x3, y3), new PointF(x4, y4) };
            g.DrawBezier(pen, points[0], points[1], points[2], points[3]);

            pen.Dispose();
            g.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                float sideLength = float.Parse(textBox9.Text);
                int order = int.Parse(textBox10.Text);

                panel2.Refresh();
                DrawKochFractal(sideLength, order);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DrawKochFractal(float sideLength, int order)
        {
            Graphics g = panel2.CreateGraphics();
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Red, 2);

            float centerX = panel2.Width / 2;
            float centerY = panel2.Height / 2;
            float halfSide = sideLength / 2;

            PointF p1 = new PointF(centerX - halfSide, centerY - halfSide);
            PointF p2 = new PointF(centerX + halfSide, centerY - halfSide);
            PointF p3 = new PointF(centerX + halfSide, centerY + halfSide);
            PointF p4 = new PointF(centerX - halfSide, centerY + halfSide);

            DrawKochLine(g, pen, p1, p2, order);
            DrawKochLine(g, pen, p2, p3, order);
            DrawKochLine(g, pen, p3, p4, order);
            DrawKochLine(g, pen, p4, p1, order);

            pen.Dispose();
            g.Dispose();
        }

        private void DrawKochLine(Graphics g, Pen pen, PointF start, PointF end, int order)
        {
            if (order == 0)
            {
                g.DrawLine(pen, start, end);
                return;
            }

            float dx = end.X - start.X;
            float dy = end.Y - start.Y;
            PointF p1 = start;
            PointF p2 = new PointF(start.X + dx / 3, start.Y + dy / 3);
            PointF p3 = new PointF(start.X + dx / 2, start.Y + dy / 2 - (float)(dx / (2 * Math.Sqrt(3))));
            PointF p4 = new PointF(start.X + 2 * dx / 3, start.Y + 2 * dy / 3);
            PointF p5 = end;

            DrawKochLine(g, pen, p1, p2, order - 1);
            DrawKochLine(g, pen, p2, p3, order - 1);
            DrawKochLine(g, pen, p3, p4, order - 1);
            DrawKochLine(g, pen, p4, p5, order - 1);
        }
    }
}
