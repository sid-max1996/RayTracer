namespace RayTracer {
    public struct Ray {
        public Vector Start;

        public Vector Direction;

        public Ray(Vector start, Vector dir) {
            Start = start;
            Direction = dir;
        }
    }
}