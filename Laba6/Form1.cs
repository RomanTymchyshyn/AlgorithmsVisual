using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;
using FortuneSupport.Mathematics;

namespace Laba6
{
    public partial class Form1 : Form
    {
        public List<Point> Array_of_vertexes = new List<Point>();

        public static List<IDrawable> DrawEvents = new List<IDrawable>();

        public static IDrawable CurrentEvent = new Painting();

        public Form1()
        {
            InitializeComponent();
        }

        private void SetupViewport()
        {
            int w = this.GLControl.Width;
            int h = this.GLControl.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
            GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void GlControl_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.SkyBlue);
            SetupViewport();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //timer1.Start();
        }

        private void GlControl_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            CurrentEvent.Draw();
            GL.Flush();
        }

        private void GlControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }

        private void GenRandVertexes_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int number_of_vertexes = rand.Next(30, 50);
            int x = 0;
            int y = 0;
            Point p;
            for (int i = 0; i < number_of_vertexes; ++i)
            {
                do
                {
                    x = rand.Next(40, GLControl.Width-40);
                    y = rand.Next(40, GLControl.Height-40);
                    p = new Point(x, y);
                }
                while (Array_of_vertexes.Contains(p));
                Array_of_vertexes.Add(p);
            }
            List<Edge> edges = new List<Edge>();
            DrawEvents.Add(new Painting(Array_of_vertexes, edges));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DrawEvents.Count() != 0) CurrentEvent = DrawEvents[0];
            if (DrawEvents.Count() > 1) DrawEvents.RemoveAt(0);
            GLControl.Refresh();
            TextBox.Text = timer1.Interval.ToString();
        }

        private void Djarvis_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Array_of_vertexes.Count(); ++i)
                Array_of_vertexes[i].Highlighted = false;
            DrawEvents.Clear();
            DrawEvents.Add(new Painting(Array_of_vertexes, new List<Edge>()));
            AlgorithmsVisualiser.Djarvis(Array_of_vertexes, DrawEvents);
        }

        private void Kirkpatrick_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Array_of_vertexes.Count(); ++i)
                Array_of_vertexes[i].Highlighted = false;
            DrawEvents.Clear();
            DrawEvents.Add(new Painting(Array_of_vertexes, new List<Edge>()));
            AlgorithmsVisualiser.Kirkpatrick(Array_of_vertexes, DrawEvents);
        }

        private void Grehem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Array_of_vertexes.Count(); ++i)
                Array_of_vertexes[i].Highlighted = false;
            DrawEvents.Clear();
            DrawEvents.Add(new Painting(Array_of_vertexes, new List<Edge>()));
            AlgorithmsVisualiser.Grehem(Array_of_vertexes, DrawEvents);
        }

        private void FastRec_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Array_of_vertexes.Count(); ++i)
                Array_of_vertexes[i].Highlighted = false;
            DrawEvents.Clear();
            DrawEvents.Add(new Painting(Array_of_vertexes, new List<Edge>()));
            AlgorithmsVisualiser.FastRecursive(Array_of_vertexes, DrawEvents);
        }

        private void Fortune_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Array_of_vertexes.Count(); ++i)
                Array_of_vertexes[i].Highlighted = false;
            DrawEvents.Clear();
            DrawEvents.Add(new Painting(Array_of_vertexes, new List<Edge>()));
            List<Vector> Points = new List<Vector>(AlgorithmsVisualiser.Pack_into_ListOfVector(Array_of_vertexes));
            VoronoiGraph graph = new VoronoiGraph();
            graph = AlgorithmsVisualiser.FortuneAlgo(Points);
            List<VoronoiEdge> VE = graph.Edges.ToList<VoronoiEdge>();
            DrawEvents.Add(new Painting(Array_of_vertexes, new List<Edge>(), VE));
        }

        private void Delaunay_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < Array_of_vertexes.Count(); ++i)
                Array_of_vertexes[i].Highlighted = false;
            DrawEvents.Clear();
            DrawEvents.Add(new Painting(Array_of_vertexes, new List<Edge>()));
            List<Vector> Points = new List<Vector>(AlgorithmsVisualiser.Pack_into_ListOfVector(Array_of_vertexes));
            VoronoiGraph graph = new VoronoiGraph();
            graph = AlgorithmsVisualiser.FortuneAlgo(Points);
            List<VoronoiEdge> VE = graph.Edges.ToList<VoronoiEdge>();
            List<Edge> tri = AlgorithmsVisualiser.Delaunay(Array_of_vertexes, graph, DrawEvents);
            foreach(Edge edge in tri)
                edge.color = Color.Red;
            GL.LineWidth(1);
            DrawEvents.Add(new Painting(Array_of_vertexes, tri, VE));
        }

        private void Delaunay1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Array_of_vertexes.Count(); ++i)
                Array_of_vertexes[i].Highlighted = false;
            DrawEvents.Clear();
            List<Vector> Points = new List<Vector>(AlgorithmsVisualiser.Pack_into_ListOfVector(Array_of_vertexes));
            VoronoiGraph graph = new VoronoiGraph();
            graph = AlgorithmsVisualiser.FortuneAlgo(Points);
            List<VoronoiEdge> VE = graph.Edges.ToList<VoronoiEdge>();
            List<Edge> tri = AlgorithmsVisualiser.Delaunay(Array_of_vertexes, graph, DrawEvents);
            DrawEvents.Clear();
            DrawEvents.Add(new Painting(Array_of_vertexes, new List<Edge>()));
            foreach (Edge edge in tri)
                edge.color = Color.Red;
            GL.LineWidth(1);
            DrawEvents.Add(new Painting(Array_of_vertexes, tri, VE));
        }

        private void Render1_Click(object sender, EventArgs e)
        {
            if (timer1.Interval > 50) timer1.Interval -= 50;
        }

        private void Render2_Click(object sender, EventArgs e)
        {
            timer1.Interval += 50;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TextBox.Text) > 0) timer1.Interval = Convert.ToInt32(TextBox.Text);
        }

    }
}
