namespace RayTracer.Geometry {
    public class Sphere: IShape {
        private const double Epsilon = 0.001;
        public Vector Center;
        public double Radius;

        public Sphere(Vector center, double radius) {
            Center = center;
            Radius = radius;
        }
        
        public Intersection? Intersect(Ray ray) {
            var temp = ray.Start - Center;
            var a = ray.Direction * ray.Direction;
            var b = temp * 2.0 * ray.Direction;
            var c = temp * temp - Radius * Radius;
            var d = b * b - 4.0 * a * c;
            
            if (d < 0)
            return null;

            var e = System.Math.Sqrt(d);
            var t = (-b - e) / (2.0 * a);

            if (t > Epsilon) {
                var hit = new Intersection();
                
                hit.Distance = t;
                hit.Point = ray.Start + ray.Direction * t;
                hit.Normal = (hit.Point - Center).Normalized();
                hit.Ray = ray;
                return hit;
            }
            return null;
        }
    }
}