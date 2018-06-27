namespace RayTracer {
    public struct Color {
        public double R, G, B;

        public Color(double r = 0, double g = 0, double b = 0) {
            R = r;
            G = g;
            B = b;
        }

        public Color Clip() {
            double r, g, b;

            r = System.Math.Max(System.Math.Min(1.0, R), 0);
            g = System.Math.Max(System.Math.Min(1.0, G), 0);
            b = System.Math.Max(System.Math.Min(1.0, B), 0);

            return new Color(r, g, b);
        }
        
        public bool IsBlack() {
            return R == 0.0 && G == 0.0 && B == 0.0;
        }

        public static Color operator +(Color left, Color right) {
            var r = left.R + right.R;
            var g = left.G + right.G;
            var b = left.B + right.B;

            return new Color(r, g, b);
        }

        public static Color operator -(Color left, Color right) {
            var r = left.R - right.R;
            var g = left.G - right.G;
            var b = left.B - right.B;

            return new Color(r, g, b);
        }

        public static Color operator *(Color left, Color right) {
            var r = left.R * right.R;
            var g = left.G * right.G;
            var b = left.B * right.B;

            return new Color(r, g, b);
        }

        public static Color operator /(Color left, Color right) {
            var r = left.R / right.R;
            var g = left.G / right.G;
            var b = left.B / right.B;

            return new Color(r, g, b);
        }

        public static Color operator *(Color color, double val) {
            var r = color.R * val;
            var g = color.G * val;
            var b = color.B * val;
            
            return new Color(r, g, b);
        }
        
        public static Color operator /(Color color, double val) {
            var r = color.R / val;
            var g = color.G / val;
            var b = color.B / val;
            
            return new Color(r, g, b);
        }
    }
}