using System.Drawing;
using OpenTK.Graphics;

namespace Laba6
{
    public class Edge: IDrawable
    {
        #region Private Fields

        private Point _vertex1;
        private Point _vertex2;

        #endregion

        #region Public Properties

        public Point Vertex1
        {
            get
            {
                return _vertex1;
            }
        }

        public Point Vertex2
        {
            get
            {
                return _vertex2;
            }
        }

        public Color color { get; set; }

        #endregion

        #region CTORS

        public Edge()
        {
            _vertex1 = new Point();
            _vertex2 = new Point();
            color = Color.Black;
        }

        public Edge(Point vertex1, Point vertex2)
        {
            _vertex1 = new Point(vertex1);
            _vertex2 = new Point(vertex2);
            color = Color.Black;
        }

        public Edge(Point vertex1, Point vertex2, Color _color)
        {
            _vertex1 = new Point(vertex1);
            _vertex2 = new Point(vertex2);
            color = _color;
        }

        public Edge(Edge edge)
        {
            _vertex1 = new Point(edge.Vertex1);
            _vertex2 = new Point(edge.Vertex2);
            color = edge.color;
        }

        public Edge(Edge edge, Color _color)
        {
            _vertex1 = new Point(edge.Vertex1);
            _vertex2 = new Point(edge.Vertex2);
            color = _color;
        }

        #endregion

        #region Public Methods

        public void Draw()
        {
            GL.LineWidth(2);
            GL.Begin(BeginMode.Lines);
            GL.Color3(color);
            GL.Vertex2(Vertex1.X, Vertex1.Y);
            GL.Vertex2(Vertex2.X, Vertex2.Y);
            GL.End();
        }

        #endregion

        

        

        
    }
}
