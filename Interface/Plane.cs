namespace RayTracer.Geometry {
    public class Plane: IShape {
        private const double Epsilon = 0.0001;
        public Vector Normal, Point;

        public Plane(Vector normal, Vector point) {
            Normal = normal;
            Point = point;
        }
        
        public Intersection? Intersect(Ray ray) {
            var temp = ray.Direction * Normal;
            double t;
            if (temp != 0.0) {
                t = (Point - ray.Start) * Normal / temp;
            }
            else {
                t = 0.0;
            }
            if (t > Epsilon) {
                var hit = new Intersection();
                hit.Distance = t;
                hit.Point = ray.Start + (ray.Direction * t);
                hit.Normal = Normal;
                hit.Ray = ray;
                return hit;
            }
            return null;
        }
    }
}