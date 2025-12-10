using Clipper2Lib;

namespace Code;

public class DayNine
{
    public Int64 PartOne(string input)
    {
        List<(int x, int y)> coordinates = input
            .Split('\n')
            .Select(line => line.Trim().Trim('"'))
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(x =>
            {
                string[] parts = x.Split(',');
                return (int.Parse(parts[0]), int.Parse(parts[1]));
            })
            .ToList();

        Int64 maxArea = 0;
    
        for (int i = 0; i < coordinates.Count; i++)
        {
            for (int j = i + 1; j < coordinates.Count; j++)
            {
                var p1 = coordinates[i];
                var p2 = coordinates[j];

                int height = Math.Abs(p2.y - p1.y) + 1;
                int width = Math.Abs(p2.x - p1.x) + 1;

                Int64 area = (Int64)width * height;
            
                if (area > maxArea)
                {
                    maxArea = area;
                }
            }
        }

        return maxArea;
    }
    
    public long PartTwo(string input)
    {
        List<(int x, int y)> coordinates = input
            .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Trim().Trim('"'))
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line =>
            {
                string[] parts = line.Split(',');
                return (int.Parse(parts[0]), int.Parse(parts[1]));
            })
            .ToList();

        var mainPolygon = CreatePolygon(coordinates);

        long maxArea = 0;

        for (int i = 0; i < coordinates.Count; i++)
        {
            for (int j = i + 1; j < coordinates.Count; j++)
            {
                var p1 = coordinates[i];
                var p2 = coordinates[j];

                int minX = Math.Min(p1.x, p2.x);
                int maxX = Math.Max(p1.x, p2.x);
                int minY = Math.Min(p1.y, p2.y);
                int maxY = Math.Max(p1.y, p2.y);

                List<(int x, int y)> rectangleCoordinates = new List<(int x, int y)>
                {
                    (minX, minY),
                    (maxX, minY),
                    (maxX, maxY),
                    (minX, maxY)
                };

                var rectangle = CreatePolygon(rectangleCoordinates);
                
                double rectArea = Math.Abs(Clipper.Area(rectangle));
                
                var subject = new PathsD { mainPolygon };
                var clip    = new PathsD { rectangle };

                PathsD intersection = Clipper.Intersect(subject, clip, FillRule.NonZero);
                
                double interArea = 0;
                foreach (var path in intersection)
                {
                    interArea += Math.Abs(Clipper.Area(path));
                }
                
                const double EPS = 1e-9;
                
                bool isContained = rectArea > 0 && Math.Abs(interArea - rectArea) < EPS;

                if (!isContained)
                    continue;

                long width  = (long)(maxX - minX + 1);
                long height = (long)(maxY - minY + 1);
                long area   = width * height;

                if (area > maxArea)
                    maxArea = area;
            }
        }

        return maxArea;
    }

    public PathD CreatePolygon(IEnumerable<(int x, int y)> coordinates)
    {
        var polygon = new PathD();

        foreach (var (x, y) in coordinates)
        {
            polygon.Add(new PointD(x, y));
        }

        return polygon;
    }

}