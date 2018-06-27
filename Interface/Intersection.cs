namespace RayTracer {
    public struct Intersection {
        public Tracer Tracer;
        public Ray Ray;
        public Vector Normal, Point;
        public Material Material;
        public double Distance;
    }
}