using System.Drawing;
using OpenTK.Graphics;

namespace Laba6
{
    public class Point: IDrawable
    {
        #region Private Fields

        private int _x;

        private int _y;

        #endregion

        #region Public Properties

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public bool Highlighted { get; set; }

        #endregion

        #region CTORS

        public Point()
        {
            _x = 0;
            _y = 0;
            Highlighted = false;
        }

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
            Highlighted = false;
        }

        public Point(Point P)
        {
            _x = P.X;
            _y = P.Y;
            Highlighted = P.Highlighted;
        }

        #endregion

        #region Public methods

        public void Draw()
        {
            if (Highlighted) GL.PointSize(7);
            else GL.PointSize(5);
            GL.Begin(BeginMode.Points);
            GL.Color3(Color.Red);
            GL.Vertex2(_x, _y);
            GL.End();
        }

        #endregion
    }
}
