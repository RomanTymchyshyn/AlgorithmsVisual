using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using FortuneSupport.Mathematics;
using FortuneSupport.Data;
using System.Collections;

namespace Laba6
{
    enum direction {right, left};

    public static class AlgorithmsVisualiser
    {
        #region Private Methods

        private static List<Point> Bucket_Sort_Y(List<Point> arr_of_points)
        {
            List<Point> sorted_array = new List<Point>(arr_of_points);
            if (arr_of_points.Count() <= 1) return sorted_array;
            sorted_array.Sort((p1, p2) => p1.Y.CompareTo(p2.Y));
            return sorted_array;   
        }

        private static List<Point> Bucket_Sort_X(List<Point> arr_of_points)
        {
            List<Point> sorted_array = new List<Point>(arr_of_points);
            if (arr_of_points.Count() <= 1) return sorted_array;
            sorted_array.Sort((p1, p2) => p1.X.CompareTo(p2.X));
            return sorted_array;
        }

        private static int max_XCoord(List<Point> arr_of_points)
        {
            if (arr_of_points.Count <= 0) return -1;
            int max = 0;
            for (int i = 1; i < arr_of_points.Count(); ++i)
                if (arr_of_points[i].X > arr_of_points[max].X) max = i;
            return max;
        }

        private static int min_XCoord(List<Point> arr_of_points)
        {
            if (arr_of_points.Count <= 0) return -1;
            int min = 0;
            for (int i = 1; i < arr_of_points.Count(); ++i)
                if (arr_of_points[i].X < arr_of_points[min].X) min = i;
            return min;
        }

        private static int max_YCoord(List<Point> arr_of_points)
        {
            if (arr_of_points.Count <= 0) return -1;
            int max = 0;
            for (int i = 1; i < arr_of_points.Count(); ++i)
                if (arr_of_points[i].Y > arr_of_points[max].Y) max = i;
            return max;
        }

        private static int min_YCoord(List<Point> arr_of_points)
        {
            if (arr_of_points.Count <= 0) return -1;
            int min = 0;
            for (int i = 1; i < arr_of_points.Count(); ++i)
                if (arr_of_points[i].Y < arr_of_points[min].Y) min = i;
            return min;
        }

        private static List<Edge> visitation(ref List<Point> list, direction direct)
        {
            List<Edge> result_edges = new List<Edge>();
            if (direct == direction.left)
            {
                for (int p1 = 0; p1 < list.Count(); ++p1)
                {
                    int p2 = (p1 == list.Count() - 1 ? 0 : p1 + 1);
                    int p3 = (p1 >= list.Count() - 2 ? (p1 == list.Count() - 2 ? 0 : 1) : p1 + 2);
                    Edge e1 = new Edge(list[p1], list[p2]);
                    Edge e2 = new Edge(list[p2], list[p3]);
                    result_edges.Add(e1);
                    result_edges.Add(e2);
                    Form1.DrawEvents.Add(new Painting(list, result_edges));
                    if ((e1.Vertex2.X - e1.Vertex1.X) * (e2.Vertex2.Y - e2.Vertex1.Y) - (e1.Vertex2.Y - e1.Vertex1.Y) * (e2.Vertex2.X - e2.Vertex1.X) < 0)
                    {
                        list.RemoveAt(p2);
                        p1 = -1;//p2 - 3;
                    }
                    result_edges.Clear();
                    Form1.DrawEvents.Add(new Painting(list, result_edges));
                    //if (p1 < 0) p1 = 0;
                }
            }
            if (direct == direction.right)
            {
                for (int p1 = 0; p1 < list.Count(); ++p1)
                {
                    int p2 = (p1 == list.Count() - 1 ? 0 : p1 + 1);
                    int p3 = (p1 >= list.Count() - 2 ? (p1 == list.Count() - 2 ? 0 : 1) : p1 + 2);
                    Edge e1 = new Edge(list[p1], list[p2]);
                    Edge e2 = new Edge(list[p2], list[p3]);
                    result_edges.Add(e1);
                    result_edges.Add(e2);
                    Form1.DrawEvents.Add(new Painting(list, result_edges));
                    if ((e1.Vertex2.X - e1.Vertex1.X) * (e2.Vertex2.Y - e2.Vertex1.Y) - (e1.Vertex2.Y - e1.Vertex1.Y) * (e2.Vertex2.X - e2.Vertex1.X) > 0)
                    {
                        list.RemoveAt(p2);
                        p1 = -1;//p2 - 3;
                    }
                    result_edges.Clear();
                    Form1.DrawEvents.Add(new Painting(list, result_edges));
                    //if (p1 < 0) p1 = 0;
                }
            }

            for (int p1 = 0; p1 < list.Count(); ++p1)
            {
                int p2 = (p1 == list.Count() - 1 ? 0 : p1 + 1);
                list[p1].Highlighted = true;
                list[p2].Highlighted = true;
                result_edges.Add(new Edge(list[p1], list[p2]));
                Form1.DrawEvents.Add(new Painting(list, result_edges));
            }
            return result_edges;
        }

        private static int Deviation(Point p, Edge e)
        {
            int C = e.Vertex1.X * e.Vertex2.Y - e.Vertex2.X * e.Vertex1.Y;
            if ((p.Y * (e.Vertex2.X - e.Vertex1.X) + p.X * (e.Vertex1.Y - e.Vertex2.Y) + C) * (C > 0 ? -1 : 1) > 0) return 1;
            else
                if ((p.Y * (e.Vertex2.X - e.Vertex1.X) + p.X * (e.Vertex1.Y - e.Vertex2.Y) + C) * (C > 0 ? -1 : 1) < 0) return -1;
                else return 0;
        }

        private static void Sort_by_angle(ref List<Point> arr_of_points, ref List<double> angles, ref List<double> distance)
        {
            int N = arr_of_points.Count();
            int t = (int)Math.Ceiling(Math.Log((double)N) / Math.Log(2.0));
            List<int> h = new List<int>();

            //шукаємо значення зміщень по формулі Седжвіка
            int temp = 0;
            int pow_2_1 = 1;
            int pow_2_2 = 1;

            for (int s = 0; s < t; ++s)
            {
                if (s % 2 == 0)
                {
                    temp = 9 * pow_2_1 - 9 * pow_2_2 + 1;
                    if (3 * temp > N) break; else h.Add(temp);
                    pow_2_1 *= 2;
                    pow_2_2 *= 2;
                }
                if (s % 2 == 1)
                {
                    temp = 8 * pow_2_1 - 6 * pow_2_2 + 1;
                    if (3 * temp > N) break; else h.Add(temp);
                    pow_2_1 *= 2;
                }
            }

            //основний цикл
            int H = 0;
            int j = 0;
            double K;
            Point P;
            double dist;

            for (int s = h.Count() - 1; s >= 0; --s)
            {
                H = h[s];
                for (int i = H; i < N; ++i)
                {
                    K = angles[i];
                    P = arr_of_points[i];
                    dist = distance[i];
                    j = i;
                    while (j - h[s] >= 0 && angles[j - h[s]] > K)
                    {
                        angles[j] = angles[j - h[s]];
                        arr_of_points[j] = arr_of_points[j - h[s]];
                        distance[j] = distance[j - h[s]];
                        j = j - h[s];
                    }
                    angles[j] = K;
                    arr_of_points[j] = P;
                    distance[j] = dist;
                }
            }
            return;
        }

        private static double distance(Point P, Edge e)
        {
            double A, B, C;
            A = e.Vertex2.X - e.Vertex1.X;
            B = e.Vertex1.Y - e.Vertex2.Y;
            C = e.Vertex1.X * e.Vertex2.Y - e.Vertex2.X * e.Vertex1.Y;
            double distance = Math.Abs(P.Y * A + P.X * B + C);
            return distance;
        }

        private static List<Point> FastRec(List<Point> S)
        {
            List<Edge> edges = new List<Edge>();
            List<Point> conv = new List<Point>();

            List<Point> points = new List<Point>(Bucket_Sort_X(S));
            if (S.Count() < 3) return conv;
            Point left = points[0];
            Point right = points[points.Count() - 1];
            List<Point> top = new List<Point>();
            List<Point> bottom = new List<Point>();
            Edge base_edge = new Edge(left, right);
            edges.Add(base_edge);
            Form1.DrawEvents.Add(new Painting(points, edges));
            edges.RemoveAt(edges.Count() - 1);
            for (int i = 0; i < points.Count(); ++i)
            {
                if (Deviation(points[i], base_edge) == -1) bottom.Add(points[i]);
                else
                    if (Deviation(points[i], base_edge) == 1) top.Add(points[i]);
            }
            Form1.DrawEvents.Add(new Painting(top, edges));
            Form1.DrawEvents.Add(new Painting(bottom, edges));
            conv.Add(left);
            conv[conv.Count() - 1].Highlighted = true;
            points[0].Highlighted = true;
            
            List<Point> temp_conv1 = new List<Point>(FR(top, left, right));
            for (int i = 0; i < temp_conv1.Count(); ++i)
            {
                conv.Add(temp_conv1[i]);
                conv[conv.Count() - 1].Highlighted = true;
            }
            conv.Add(right);
            conv[conv.Count() - 1].Highlighted = true;

            List<Point> temp_conv2 = FR(bottom, left, right);
            temp_conv2.Reverse();
            for (int i = 0; i < temp_conv2.Count(); ++i)
            {
                conv.Add(temp_conv2[i]);
                conv[conv.Count() - 1].Highlighted = true;
            }

            return conv;
        }

        private static List<Point> FR(List<Point> points, Point left, Point right)
        {
            if (points.Count() < 2) return new List<Point>(points);
            List<Edge> edges = new List<Edge>();
            Point top = points[0];
            Edge base_edge = new Edge(left, right);
            edges.Add(base_edge);
            points.Add(left);
            points.Add(right);
            Form1.DrawEvents.Add(new Painting(points, edges));
            points.RemoveAt(points.Count() - 1);
            points.RemoveAt(points.Count() - 1);
            double dist = distance(top, base_edge);
            for (int i = 1; i < points.Count(); ++i)
            {
                double temp_dist = distance(points[i], base_edge);
                if (temp_dist > dist)
                {
                    top = points[i];
                    dist = temp_dist;
                }
                else if (temp_dist == dist)
                {
                    Edge e1 = new Edge(left, top);
                    if (Deviation(points[i], e1) != Deviation(right, e1))
                    {
                        top = points[i];
                        dist = temp_dist;
                    }
                }
            }
            top.Highlighted = true;
            List<Point> S1 = new List<Point>();
            List<Point> S2 = new List<Point>();
            Edge edge1 = new Edge(left, top);
            Edge edge2 = new Edge(right, top);
            edges.Add(edge1);
            edges.Add(edge2);
            Form1.DrawEvents.Add(new Painting(points, edges));

            int dev = Deviation(right, edge1);
            for (int i = 0; i < points.Count(); ++i)
                if (points[i] != top && Deviation(points[i], edge1) != dev)
                    S1.Add(points[i]);
            Form1.DrawEvents.Add(new Painting(S1, edges));
            dev = Deviation(left, edge2);
            for (int i = 0; i < points.Count(); ++i)
                if (points[i] != top && Deviation(points[i], edge2) != dev)
                    S2.Add(points[i]);
            Form1.DrawEvents.Add(new Painting(S2, edges));
            List<Point> result = FR(S1, left, top);
            result.Add(top);
            List<Point> temp_res = FR(S2, top, right);
            for (int i = 0; i < temp_res.Count(); ++i)
                result.Add(temp_res[i]);
            return result;
        }

        private static VNode ProcessDataEvent(VDataEvent e, VNode Root, VoronoiGraph VG, double ys, out VDataNode[] CircleCheckList)
        {
            if (Root == null)
            {
                Root = new VDataNode(e.DataPoint);
                CircleCheckList = new VDataNode[] { (VDataNode)Root };
                return Root;
            }
            //Знаходимо вузол для заміщення
            VNode C = VNode.FindDataNode(Root, ys, e.DataPoint[0]);
            //Створюємо піддерево з одним ребром, але двома VEdgeNodes
            VoronoiEdge VE = new VoronoiEdge();
            VE.LeftData = ((VDataNode)C).DataPoint;
            VE.RightData = e.DataPoint;
            VE.VVertexA = Fortune.VVUnkown;
            VE.VVertexB = Fortune.VVUnkown;
            VG.Edges.Add(VE);

            VNode SubRoot;
            if (Math.Abs(VE.LeftData[1] - VE.RightData[1]) < 1e-10)
            {
                if (VE.LeftData[0] < VE.RightData[0])
                {
                    SubRoot = new VEdgeNode(VE, false);
                    SubRoot.Left = new VDataNode(VE.LeftData);
                    SubRoot.Right = new VDataNode(VE.RightData);
                }
                else
                {
                    SubRoot = new VEdgeNode(VE, true);
                    SubRoot.Left = new VDataNode(VE.RightData);
                    SubRoot.Right = new VDataNode(VE.LeftData);
                }
                CircleCheckList = new VDataNode[] { (VDataNode)SubRoot.Left, (VDataNode)SubRoot.Right };
            }
            else
            {
                SubRoot = new VEdgeNode(VE, false);
                SubRoot.Left = new VDataNode(VE.LeftData);
                SubRoot.Right = new VEdgeNode(VE, true);
                SubRoot.Right.Left = new VDataNode(VE.RightData);
                SubRoot.Right.Right = new VDataNode(VE.LeftData);
                CircleCheckList = new VDataNode[] { (VDataNode)SubRoot.Left, (VDataNode)SubRoot.Right.Left, (VDataNode)SubRoot.Right.Right };
            }

            //"Застосовуємо" піддерево
            if (C.Parent == null)
                return SubRoot;
            C.Parent.Replace(C, SubRoot);
            return Root;
        }

        private static VNode ProcessCircleEvent(VCircleEvent e, VNode Root, VoronoiGraph VG, double ys, out VDataNode[] CircleCheckList)
        {
            VDataNode a, b, c;
            VEdgeNode e1, e2;
            b = e.NodeN;
            a = VNode.LeftDataNode(b);
            c = VNode.RightDataNode(b);
            if (a == null || b.Parent == null || c == null || !a.DataPoint.Equals(e.NodeL.DataPoint) || !c.DataPoint.Equals(e.NodeR.DataPoint))
            {
                CircleCheckList = new VDataNode[] { };
                return Root; // повертаємось, бо графік змінився
            }
            e1 = (VEdgeNode)b.Parent;
            CircleCheckList = new VDataNode[] { a, c };
            //Створюємо нову вершину
            Vector VNew = new Vector(e.Center[0], e.Center[1]);
            VG.Vertizes.Add(VNew);
            //2. виясняємо, чи а або с знаходяться у віддаленій частині дерева (інший - брат b), і призначаємо нову вершину
            if (e1.Left == b) // c - брат
            {
                e2 = VNode.EdgeToRightDataNode(a);
                // замінюємо e1 правим нащадком
                e1.Parent.Replace(e1, e1.Right);
            }
            else // a - брат
            {
                e2 = VNode.EdgeToRightDataNode(b);

                // замінюємо e1 лівим нащадком
                e1.Parent.Replace(e1, e1.Left);
            }
            e1.Edge.AddVertex(VNew);
            e2.Edge.AddVertex(VNew);

            //Замінюємо e2 новим ребром
            VoronoiEdge VE = new VoronoiEdge();
            VE.LeftData = a.DataPoint;
            VE.RightData = c.DataPoint;
            VE.AddVertex(VNew);
            VG.Edges.Add(VE);

            VEdgeNode VEN = new VEdgeNode(VE, false);
            VEN.Left = e2.Left;
            VEN.Right = e2.Right;
            if (e2.Parent == null)
                return VEN;
            e2.Parent.Replace(e2, VEN);
            return Root;
        }

        public static VCircleEvent CircleCheckDataNode(VDataNode n, double ys)
        {
            VDataNode l = VNode.LeftDataNode(n);
            VDataNode r = VNode.RightDataNode(n);
            if (l == null || r == null || l.DataPoint == r.DataPoint || l.DataPoint == n.DataPoint || n.DataPoint == r.DataPoint)
                return null;
            if (MathTools.ccw(l.DataPoint[0], l.DataPoint[1], n.DataPoint[0], n.DataPoint[1], r.DataPoint[0], r.DataPoint[1], false) <= 0)
                return null;
            Vector Center = CircleCentre(l.DataPoint, n.DataPoint, r.DataPoint);
            VCircleEvent VC = new VCircleEvent();
            VC.NodeN = n;
            VC.NodeL = l;
            VC.NodeR = r;
            VC.Center = Center;
            VC.Valid = true;
            if (VC.Y >= ys)
                return VC;
            return null;
        }
        public static Vector CircleCentre(Vector A, Vector B, Vector C)
        {
            if (A == B || B == C || A == C)
                throw new Exception("Need three different points!");
            double tx = (A[0] + C[0]) / 2;
            double ty = (A[1] + C[1]) / 2;

            double vx = (B[0] + C[0]) / 2;
            double vy = (B[1] + C[1]) / 2;

            double ux, uy, wx, wy;

            if (A[0] == C[0])
            {
                ux = 1;
                uy = 0;
            }
            else
            {
                ux = (C[1] - A[1]) / (A[0] - C[0]);
                uy = 1;
            }

            if (B[0] == C[0])
            {
                wx = -1;
                wy = 0;
            }
            else
            {
                wx = (B[1] - C[1]) / (B[0] - C[0]);
                wy = -1;
            }

            double alpha = (wy * (vx - tx) - wx * (vy - ty)) / (ux * wy - wx * uy);

            return new Vector(tx + alpha * ux, ty + alpha * uy);
        }
        public static Edge Pack_into_Edge(VoronoiEdge VE)
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
            Point p1 = new Point(x1, y1);
            Point p2 = new Point(x2, y2);
            Edge e = new Edge(p1, p2);
            return e;
        }

        #endregion

        #region Public Methods

        public static List<Edge> Kirkpatrick(List<Point> arrayOfVertexes, List<IDrawable> visualSteps)
        {
            List<Edge> edges = new List<Edge>();
            visualSteps.Add(new Painting(arrayOfVertexes, edges));
            if (arrayOfVertexes.Count() <= 1) return edges;
            if (arrayOfVertexes.Count() <= 3)
            {
                for (int i = 0; i < arrayOfVertexes.Count; ++i)
                {
                    int k = (i == 2 ? 0 : i + 1);
                    edges.Add(new Edge(arrayOfVertexes[i], arrayOfVertexes[k]));
                    visualSteps.Add(new Painting(arrayOfVertexes, edges));
                }
                return edges;
            }

            List<Point> points = new List<Point> (Bucket_Sort_Y(arrayOfVertexes));
            List<Point> right_points = new List<Point>();
            List<Point> left_points = new List<Point>();

            int left = 0;
            int right = 0;
            for (int i = 0; i < points.Count(); ++i)
            {
                left = i;
                right = i;
                while (i < points.Count()-1 && points[i + 1].Y == points[i].Y)
                {
                    ++i;
                    if (points[i].X < points[i - 1].X)
                        left = i;
                    if (points[i].X > points[i - 1].X)
                        right = i;
                }
                right_points.Add(points[right]);
                left_points.Add(points[left]);
            }
            visualSteps.Add(new Painting(right_points, edges));
            List<Edge> right_part = new List<Edge>(visitation(ref right_points, direction.left));

            visualSteps.Add(new Painting(left_points, edges));
            List<Edge> left_part = new List<Edge>(visitation(ref left_points, direction.right));

            right_points.Reverse();
            for (int i = 0; i < right_points.Count(); ++i)
                left_points.Add(right_points[i]);
            for (int i = 0; i < left_points.Count(); ++i)
            {
                int k = (i == left_points.Count() - 1 ? 0 : i + 1);
                edges.Add(new Edge(left_points[i], left_points[k]));
            }
            visualSteps.Add(new Painting(left_points, edges));
            visualSteps.Add(new Painting(points, edges));

            return edges;
        }

        public static List<Edge> Djarvis(List<Point> arrayOfVertexes, List<IDrawable> visualSteps)
        {
            List<Edge> edges = new List<Edge>();
            if (arrayOfVertexes.Count() <= 1) return edges;
            if (arrayOfVertexes.Count() <= 3)
            {
                for (int i = 0; i < arrayOfVertexes.Count; ++i)
                {
                    int k = (i == 2 ? 0 : i + 1);
                    edges.Add(new Edge(arrayOfVertexes[i], arrayOfVertexes[k]));
                    visualSteps.Add(new Painting(arrayOfVertexes, edges));
                }
                return edges;
            }

            List<Point> points = new List<Point>(Bucket_Sort_X(arrayOfVertexes));
            List<Point> top_points = new List<Point>();
            List<Point> bottom_points = new List<Point>();

            int max_X = max_XCoord(points);
            int min_X = min_XCoord(points);
            Edge base_edge = new Edge(points[min_X], points[max_X]);
            edges.Add(base_edge);
            visualSteps.Add(new Painting(points, edges));

            top_points.Add(points[min_X]);
            bottom_points.Add(points[min_X]);
            for (int i = 0; i < points.Count(); ++i)
                if (Deviation(points[i], base_edge) == -1) bottom_points.Add(points[i]);
                else 
                    if (Deviation(points[i], base_edge) == 1) top_points.Add(points[i]);
            top_points.Add(points[max_X]);
            bottom_points.Add(points[max_X]);

            List<Edge> top_edges = new List<Edge>();
            top_edges.Add(base_edge);
            visualSteps.Add(new Painting(top_points, top_edges));
            for (int i = 0; i < top_points.Count() - 1; ++i)
            {
                for (int k = i + 1; k < top_points.Count(); ++k)
                {
                    Edge edge = new Edge(top_points[i], top_points[k]);
                    top_edges.Add(edge);
                    visualSteps.Add(new Painting(top_points, top_edges));
                    bool ok = true;
                    int dev = Deviation (top_points[(k!=top_points.Count()-1) ? k+1 : k - 2], edge);
                    for (int j = 0; j < top_points.Count(); ++j)
                    {
                        if (j != i && j != k)
                            if (dev == 0) dev = Deviation(top_points[j], edge);
                            else
                                if (Deviation(top_points[j], edge) != dev && Deviation(top_points[j], edge)!=0) ok = false;
                    }
                    if (ok == false) top_edges.RemoveAt(top_edges.Count()-1);
                    if (ok == true)
                    {
                        i = k - 1;
                        break;
                    }
                }
            }
            visualSteps.Add(new Painting(top_points, top_edges));

            List<Edge> bottom_edges = new List<Edge>();
            bottom_edges.Add(base_edge);
            visualSteps.Add(new Painting(bottom_points, bottom_edges));
            for (int i = 0; i < bottom_points.Count() - 1; ++i)
            {
                for (int k = i + 1; k < bottom_points.Count(); ++k)
                {
                    Edge edge = new Edge(bottom_points[i], bottom_points[k]);
                    bottom_edges.Add(edge);
                    visualSteps.Add(new Painting(bottom_points, bottom_edges));
                    bool ok = true;
                    int dev = Deviation (points[(k!=bottom_points.Count()-1) ? k+1 : k - 2], edge);
                    for (int j = 0; j < bottom_points.Count(); ++j)
                    {
                        if (j != i && j != k)
                            if (dev == 0) dev = Deviation(bottom_points[j], edge);
                            else
                                if (Deviation(bottom_points[j], edge) != dev && Deviation(bottom_points[j], edge) != 0) ok = false;
                    }
                    if (ok == false) bottom_edges.RemoveAt(bottom_edges.Count()-1);
                    if (ok == true)
                    {
                        i = k - 1;
                        break;
                    }
                }
            }
            visualSteps.Add(new Painting(bottom_points, bottom_edges));

            top_edges.RemoveAt(0);
            bottom_edges.RemoveAt(0);
            for (int i = 0; i < bottom_edges.Count(); ++i)
                top_edges.Add(bottom_edges[i]);

            visualSteps.Add(new Painting(points, top_edges));

            return edges;
        }

        public static List<Edge> Grehem(List<Point> arrayOfVertexes, List<IDrawable> visualSteps)
        {
            List<Edge> edges = new List<Edge>();
            if (arrayOfVertexes.Count() <= 1) return edges;
            if (arrayOfVertexes.Count() <= 3)
            {
                for (int i = 0; i < arrayOfVertexes.Count; ++i)
                {
                    int k = (i == 2 ? 0 : i + 1);
                    edges.Add(new Edge(arrayOfVertexes[i], arrayOfVertexes[k]));
                    visualSteps.Add(new Painting(arrayOfVertexes, edges));
                }
                return edges;
            }

            List<Point> points = new List<Point>(arrayOfVertexes);
            List<Point> copy = new List<Point>(arrayOfVertexes);
            List<double> angles = new List<double>();
            List<double> dist = new List<double>();
            double cos = 0.0;
            double distance = 0.0;
            
            int base_point = max_YCoord(points);
            copy.RemoveAt(base_point);
            for (int i = 0; i < copy.Count(); ++i)
            {
                Edge e = new Edge(points[base_point], copy[i]);
                distance = Math.Sqrt((e.Vertex2.X - e.Vertex1.X) * (e.Vertex2.X - e.Vertex1.X) + (e.Vertex2.Y - e.Vertex1.Y) * (e.Vertex2.Y - e.Vertex1.Y));
                cos = (e.Vertex2.X - e.Vertex1.X) / distance;
                angles.Add(Math.Acos(cos));
                dist.Add(distance);
            }

            Sort_by_angle(ref copy, ref angles, ref dist);
            for (int i = 0; i < copy.Count(); ++i)
            {
                Edge e = new Edge(points[base_point], copy[i]);
                edges.Add(e);
                visualSteps.Add(new Painting(points, edges));
            }
            edges.Clear();
            visualSteps.Add(new Painting(points, edges));
            copy.Insert(0, points[base_point]);
            points[base_point].Highlighted = true;
            for (int p1 = 0; p1 < copy.Count(); ++p1)
            {
                if (p1 == copy.Count()) p1 = 0;
                int p2 = (p1 == copy.Count() - 1 ? 0 : p1 + 1);
                int p3 = (p2 == copy.Count() - 1 ? 0 : p2 + 1);
                Edge e1 = new Edge(copy[p1], copy[p2]);
                Edge e2 = new Edge(copy[p2], copy[p3]);
                edges.Add(e1);
                edges.Add(e2);
                visualSteps.Add(new Painting(copy, edges));
                edges.Clear();
                if ((e1.Vertex2.X - e1.Vertex1.X) * (e2.Vertex2.Y - e2.Vertex1.Y) - (e1.Vertex2.Y - e1.Vertex1.Y) * (e2.Vertex2.X - e2.Vertex1.X) > 0)
                {
                    p1 = p2 - 3;
                    copy.RemoveAt(p2);
                }
                visualSteps.Add(new Painting(copy, edges));
                if (p2 < 0) p2 = 0;
            }
            edges.Clear();
            visualSteps.Add(new Painting(copy, edges));

            for (int i = 0; i < copy.Count(); ++i)
            {
                int k = (i == copy.Count() - 1 ? 0 : i + 1);
                Edge e = new Edge(copy[i], copy[k]);
                edges.Add(e);
                visualSteps.Add(new Painting(copy, edges));
            }
            visualSteps.Add(new Painting(points, edges));

            return edges;
        }

        public static List<Edge> FastRecursive(List<Point> S, List<IDrawable> visualSteps)
        {
            List<Point> conv = new List<Point>(FastRec(S));
            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < conv.Count(); ++i)
            {
                int k = (i == conv.Count() - 1 ? 0 : i + 1);
                Edge e = new Edge(conv[i], conv[k]);
                edges.Add(e);
                visualSteps.Add(new Painting(S, edges));
            }
            return edges;
        }

        public static VoronoiGraph FortuneAlgo(List<Vector> points)
        {
            BinaryPriorityQueue PQ = new BinaryPriorityQueue();
            Hashtable CurrentCircles = new Hashtable();
            VoronoiGraph VG = new VoronoiGraph();
            VNode RootNode = null;
            for (int i = 0; i < points.Count; ++i)
                PQ.Push(new VDataEvent(points[i]));
            while (PQ.Count > 0)
            {
                VEvent VE = PQ.Pop() as VEvent;
                VDataNode[] CircleCheckList;
                if (VE is VDataEvent)
                    RootNode = ProcessDataEvent(VE as VDataEvent, RootNode, VG, VE.Y, out CircleCheckList);
                else if (VE is VCircleEvent)
                {
                    CurrentCircles.Remove(((VCircleEvent)VE).NodeN);
                    if (!((VCircleEvent)VE).Valid)
                        continue;
                    RootNode = ProcessCircleEvent(VE as VCircleEvent, RootNode, VG, VE.Y, out CircleCheckList);
                }
                else throw new Exception("Got event of type " + VE.GetType().ToString() + "!");
                foreach (VDataNode VD in CircleCheckList)
                {
                    if (CurrentCircles.ContainsKey(VD))
                    {
                        ((VCircleEvent)CurrentCircles[VD]).Valid = false;
                        CurrentCircles.Remove(VD);
                    }
                    VCircleEvent VCE = CircleCheckDataNode(VD, VE.Y);
                    if (VCE != null)
                    {
                        PQ.Push(VCE);
                        CurrentCircles[VD] = VCE;
                    }
                }
                if (VE is VDataEvent)
                {
                    Vector DP = ((VDataEvent)VE).DataPoint;
                    foreach (VCircleEvent VCE in CurrentCircles.Values)
                    {
                        if (MathTools.Dist(DP[0], DP[1], VCE.Center[0], VCE.Center[1]) < VCE.Y - VCE.Center[1] && Math.Abs(MathTools.Dist(DP[0], DP[1], VCE.Center[0], VCE.Center[1]) - (VCE.Y - VCE.Center[1])) > 1e-10)
                            VCE.Valid = false;
                    }
                }
            }
            VNode.CleanUpTree(RootNode);
            foreach (VoronoiEdge VE in VG.Edges)
            {
                if (VE.Done)
                    continue;
                if (VE.VVertexB == Fortune.VVUnkown)
                {
                    VE.AddVertex(Fortune.VVInfinite);
                    if (Math.Abs(VE.LeftData[1] - VE.RightData[1]) < 1e-10 && VE.LeftData[0] < VE.RightData[0])
                    {
                        Vector T = VE.LeftData;
                        VE.LeftData = VE.RightData;
                        VE.RightData = T;
                    }
                }
            }

            ArrayList MinuteEdges = new ArrayList();
            foreach (VoronoiEdge VE in VG.Edges)
            {
                if (!VE.IsPartlyInfinite && VE.VVertexA.Equals(VE.VVertexB))
                {
                    MinuteEdges.Add(VE);
                    foreach (VoronoiEdge VE2 in VG.Edges)
                    {
                        if (VE2.VVertexA.Equals(VE.VVertexA))
                            VE2.VVertexA = VE.VVertexA;
                        if (VE2.VVertexB.Equals(VE.VVertexA))
                            VE2.VVertexB = VE.VVertexA;
                    }
                }
            }
            foreach (VoronoiEdge VE in MinuteEdges)
                VG.Edges.Remove(VE);

            return VG;
        }

        public static List<Edge> Delaunay(List<Point> points, VoronoiGraph VG, List<IDrawable> visualSteps)
        {
            List<VoronoiEdge> edges = new List<VoronoiEdge>();
            List<Edge> edges_to_paint = new List<Edge>();
            edges = VG.Edges.ToList<VoronoiEdge>();
            List<Edge> result = new List<Edge>();
            for (int i = 0; i < edges.Count(); ++i)
            {
                Edge e_temp = new Edge(Pack_into_Edge(edges[i]), Color.Yellow);
                edges_to_paint.Add(e_temp);
                visualSteps.Add(new Painting(points,edges_to_paint, edges));
                Point p1 = new Point((int)edges[i].LeftData[0], (int)edges[i].LeftData[1]);
                Point p2 = new Point((int)edges[i].RightData[0], (int)edges[i].RightData[1]);
                Edge e = new Edge(p1, p2, Color.Yellow);
                result.Add(e);
                edges_to_paint.Add(e);
                visualSteps.Add(new Painting(points,edges_to_paint, edges));
                edges_to_paint.RemoveAt(edges_to_paint.Count - 2);
            }
            return result;
        }

        public static List<Vector> Pack_into_ListOfVector(List<Point> points)
        {
            List<Vector> packed_list = new List<Vector>(points.Count);
            for (int i = 0; i < points.Count; ++i)
            {
                Vector V = new Vector(2);
                V[0] = points[i].X;
                V[1] = points[i].Y;
                packed_list.Add(V);
            }
            return packed_list;
        }

        #endregion
    }
}
