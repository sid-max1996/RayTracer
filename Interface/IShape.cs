namespace RayTracer {
    
    public interface IShape {
        Intersection? Intersect(Ray ray);
    }
}