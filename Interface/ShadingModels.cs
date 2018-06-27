namespace RayTracer {
    public class ShadingModels {
        public static Color LambertModel(Intersection intersection, Vector lightDirection) {
            double mult = (-lightDirection) * intersection.Normal;
            Color lambertColor = new Color();
            if (mult >= 0)
                lambertColor = intersection.Material.Diffuse * mult;
            return lambertColor;
        }

        public static Color PhongModel(Intersection intersection, Vector lightDirection) {
			Vector medium = -(intersection.Ray.Direction + lightDirection).Normalized();
			Vector reflected = Vector.Reflect(lightDirection, intersection.Normal);
            double mult = reflected * (-intersection.Ray.Direction);
			Color phongColor = new Color();
            if (mult > 0) {
				phongColor = intersection.Material.Specular *
								  System.Math.Pow(mult, intersection.Material.PhongPower);


			}
            return phongColor;
        }

        public static Color BlinnPhongModel(Intersection intersection, Vector lightDirection) {
            Vector medium = -(intersection.Ray.Direction + lightDirection).Normalized();
            double mult = medium * intersection.Normal;
            Color blinnPhongColor = new Color();
            if (mult > 0) {
                blinnPhongColor = intersection.Material.Specular *
                                  System.Math.Pow(mult, intersection.Material.PhongPower);
            }
            return blinnPhongColor;
        }
    }
}