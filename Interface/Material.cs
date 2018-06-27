namespace RayTracer {
    public struct Material {
        public Color Ambient, Diffuse, Specular, ReflectiveColor, RefractiveColor;
        public double PhongPower, Reflectance, Refractivity, Lambert, Phong, BlinnPhong, RefractivePower;

        public Material(
            Color ambient,
            Color diffuse,
            Color specular,
            Color reflectiveColor,
            Color refractiveColor,
            double lambert, 
            double phong,
            double blinnPhong,
            double phongPower = 1.0,
            double reflectance = 0.0,
            double refractivity = 0.0,
            double refractivePower = 1.0
        ) {
            Ambient = ambient;
            Diffuse = diffuse;
            Specular = specular;
            ReflectiveColor = reflectiveColor;
            RefractiveColor = refractiveColor;
            PhongPower = phongPower;
            Reflectance = reflectance;
            Refractivity = refractivity;
            Lambert = lambert;
            Phong = phong;
            BlinnPhong = blinnPhong;
            RefractivePower = refractivePower;
        }
    }
}