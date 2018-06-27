namespace RayTracer.Lights {
    public class DirectedLight {
        public Vector Direction;
		public Color Color;

		public DirectedLight(Vector direction, Color color) {
            Direction = direction;
			Color = color;
        }
        
        public Vector GetDirAt(Vector pos) {
            return Direction;
        }

        

        public Color shade(Intersection intersection) {
            var ray = new Ray(intersection.Point, -Direction);
            var intersections = intersection.Tracer.Scene.Intersections(ray);
            var result = new Color() + Color;
            foreach (var hit in intersections) {
                result = result * (hit.Material.RefractiveColor * hit.Material.Refractivity);
            }
            return result;
        }
    }
}