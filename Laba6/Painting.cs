using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using OpenTK.Graphics;
using FortuneSupport.Mathematics;

namespace Laba6
{
    public class Painting: IDrawable
    {
        #region Private Fields

        private List<IDrawable> _points;

        private List<IDrawable> _edges;
        
        private List<VoronoiEdge> LVE;

        #endregion

        #region Public Properties

        public List<IDrawable> Points
        {
            get
            {
                return _points;
            }
        }

        public List<IDrawable> Edges
        {
            get
            {
                return _edges;
            }
        }

        public List<VoronoiEdge> VoronoiEdges
        {
            get
            {
                return LVE;
            }
        }

        #endregion

        #region CTORS

        public Painting()
        {
            _points = new List<IDrawable>();
            _edges = new List<IDrawable>();
            LVE = new List<VoronoiEdge>();
        }

        public Painting(List<Point> points, List<Edge> edges)
        {
            _points = new List<IDrawable>();
            AddPoints(points);
            _edges = new List<IDrawable>();
            AddEdges(edges);
            LVE = new List<VoronoiEdge>();
        }

        public Painting(List<Point> points, List<Edge> edges, List<VoronoiEdge> VE)
        {
            _points = new List<IDrawable>();
            AddPoints(points);
            _edges = new List<IDrawable>();
            AddEdges(edges);
            LVE = new List<VoronoiEdge>(VE);
        }

        public Painting(Painting painting)
        {
            _points = new List<IDrawable>(painting.Points);
            _edges = new List<IDrawable>(painting.Edges);
            LVE = new List<VoronoiEdge>(painting.VoronoiEdges);
        }

        #endregion

        #region Private Methods

        private void DrawVoronoiEdge(VoronoiEdge VE)
        {
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            if (VE.IsInfinite)
            {
                x1 = (int)(1000 * VE.DirectionVector[0] + VE.FixedPoint[0]);
                y1 = (int)(1000 * VE.DirectionVector[1] + VE.FixedPoint[1]);
                x2 = (int)(-1000 * VE.DirectionVector[0] + VE.FixedPoint[0]);
                y2 = (int)(-1000 * VE.DirectionVector[1] + VE.FixedPoint[1]);
            }
            else if (VE.IsPartlyInfinite)
            {
                x1 = (int)VE.FixedPoint[0];
                y1 = (int)VE.FixedPoint[1];
                x2 = (int)(1000 * VE.DirectionVector[0] + VE.FixedPoint[0]);
                y2 = (int)(1000 * VE.DirectionVector[1] + VE.FixedPoint[1]);
            }
            else
            {
                x1 = (int)VE.VVertexA[0];
                y1 = (int)VE.VVertexA[1];
                x2 = (int)VE.VVertexB[0];
                y2 = (int)VE.VVertexB[1];
            }
            GL.LineWidth(1);
            GL.Begin(BeginMode.Lines);
            GL.Color3(Color.Black);
            GL.Vertex2(x1, y1);
            GL.Vertex2(x2, y2);
            GL.End();
        }

        private void AddPoints(List<Point> points)
        {
            foreach (var p in points)
            {
                _points.Add(p);
            }
        }

        private void AddEdges(List<Edge> edges)
        {
            foreach (var e in edges)
            {
                _edges.Add(e);
            }
        }

        #endregion

        #region Public Methods

        public void Draw()
        {
            for (int i = 0; i < Points.Count(); ++i)
                Points[i].Draw();
            for (int i = 0; i < VoronoiEdges.Count; ++i)
                DrawVoronoiEdge(VoronoiEdges[i]);
            for (int i = 0; i < Edges.Count(); ++i)
                Edges[i].Draw();
        }

        #endregion
    }
}
