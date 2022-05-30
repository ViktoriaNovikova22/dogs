using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dogs
{
    internal class LabClass
    {
        public enum State
        {
            Wall,
            Cell,
            Visited,
            First
        }

        public State[,] Map;
        public Point currentCell;
        public Point endCell;
        public Stack<Point> stack;
        public int side = 40;
        public int X;
        public int Y;
        public int width = 17;
        public int height = 9;
        public bool builded = false;

        public LabClass()
        {
            Map = new State[width, height];
            stack = new Stack<Point>();
            currentCell = new Point(1, 1);
            endCell = new Point(15, 7);
        }

        public void CreateMap()
        {
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    if (i % 2 != 0 && j % 2 != 0 && i < width && j < height)
                        Map[i, j] = State.Cell;
                    else
                        Map[i, j] = State.Wall;
                }
            }
        }

        public void BuildMap()
        {
            Random rnd = new Random();
            while (true)
            {
                var neighbours = GetNeighbours(currentCell, 2, true);
                if (neighbours.Length != 0)
                {
                    var randNum = rnd.Next(neighbours.Length);
                    var neighbourCell = neighbours[randNum];
                    if (neighbours.Length > 1)
                        stack.Push(currentCell);
                    Remove(currentCell, neighbourCell);
                    Map[currentCell.X, currentCell.Y] = State.Visited;
                    currentCell = neighbourCell;
                }
                else if (stack.Count > 0)
                {
                    Map[currentCell.X, currentCell.Y] = State.Visited;
                    currentCell = stack.Pop();
                }
                else
                    break;
            }
        }

        private Point[] GetNeighbours(Point point, int distance, bool needToCheckVisited)
        {
            var neigh = new List<Point>();
            var points = new List<Point>();
            var top = new Point(point.X, point.Y - distance);
            points.Add(top);
            var right = new Point(point.X + distance, point.Y);
            points.Add(right);
            var bottom = new Point(point.X, point.Y + distance);
            points.Add(bottom);
            var left = new Point(point.X - distance, point.Y);
            points.Add(left);
            if (needToCheckVisited)
                foreach (var p in points)
                {
                    if (p.X > 0 && p.X < width && p.Y > 0 && p.Y < height)
                        if (Map[p.X, p.Y] != State.Wall && Map[p.X, p.Y] != State.Visited)
                            neigh.Add(p);
                }
            else
                foreach (var p in points)
                {
                    if (p.X > 0 && p.X < width && p.Y > 0 && p.Y < height)
                        if (Map[p.X, p.Y] != State.Wall)
                            neigh.Add(p);
                }
            return neigh.ToArray();
        }

        private void Remove(Point point1, Point point2)
        {
            var xDiff = point2.X - point1.X;
            var yDiff = point2.Y - point1.Y;
            int addX, addY;
            var point = new Point();

            if (xDiff != 0)
                addX = xDiff / Math.Abs(xDiff);
            else
                addX = 0;
            if (yDiff != 0)
                addY = yDiff / Math.Abs(yDiff);
            else
                addY = 0;

            point.X = point1.X + addX;
            point.Y = point2.Y + addY;

            Map[point.X, point.Y] = State.Visited;
        }

        public void CreateLab()
        {
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    if (Map[i, j] == State.Visited)
                    {
                        Map[i, j] = State.Cell;
                    }
                }
            }
        }
    }
}
