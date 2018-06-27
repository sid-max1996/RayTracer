namespace RayTracer {
    public class Object {
        public IShape Shape;
        public Material Material;

        public Object(IShape shape, Material material) {
            Shape = shape;
            Material = material;
        }

        public Intersection? Intersect(Ray ray) {
            var hitFigure = Shape.Intersect(ray);
            
            if (hitFigure == null) return null;
            
            var intersection = hitFigure.Value;
            intersection.Material = Material;
            
            return intersection;
        }
    }
}