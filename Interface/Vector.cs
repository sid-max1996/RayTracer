namespace RayTracer {
    public struct Vector {
        public double X, Y, Z;

        public Vector(double x, double y, double z) {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector Normalized() {
            return this / Len();
        }

        public double Len() {
            return System.Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public static Vector Reflect(Vector direction, Vector normal) {
            double mult = -(direction * normal);
            return direction + normal * 2 * mult;
        }

        public static Vector? Refract(Vector direction, Vector normal, double refration_power) {
            double nv = normal * direction;
            double a = 1.0 / refration_power;
            if (nv > 0)
                return Refract(direction, -normal, refration_power);
            double d = 1.0 - (a * a) * (1.0 - nv * nv);
            if (d < 0)
                return null;
            double b = nv * a + System.Math.Sqrt(d);
            return direction * a - normal * b;
        }
        
        public static Vector operator +(Vector a, Vector b) {
            double x = a.X + b.X;
            double y = a.Y + b.Y;
            double z = a.Z + b.Z;
            return new Vector(x, y, z);
        }

        public static Vector operator -(Vector a, Vector b) {
            double x = a.X - b.X;
            double y = a.Y - b.Y;
            double z = a.Z - b.Z;
            return new Vector(x, y, z);
        }

        public static Vector operator -(Vector vec) {
            double x, y, z;
            x = -vec.X;
            y = -vec.Y;
            z = -vec.Z;
            return new Vector(x, y, z);
        }

        public static Vector operator *(Vector v, double mul) {
            return new Vector(v.X * mul, v.Y * mul, v.Z * mul);
        }
        
        public static Vector operator /(Vector v, double mul) {
            return new Vector(v.X / mul, v.Y / mul, v.Z / mul);
        }

        public static double operator *(Vector a, Vector b) {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
        
        public static Vector operator ^(Vector a, Vector b) {
            double x, y, z;

            x = a.Y * b.Z - a.Z * b.Y;
            y = a.X * b.Z - a.Z * b.X;
            z = a.X * b.Y - a.Y * b.X;

            return new Vector(x, y, z);
        }

    }
}