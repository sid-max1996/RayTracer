using System;
using System.Collections.Generic;

namespace RayTracer {
    public class Tracer {
        public Scene Scene;

        public Tracer(Scene scene) {
            Scene = scene;
        }

        public Color trace(Ray ray, int depth) {
            if (depth < 1) 
                return new Color(Scene.Background.R, Scene.Background.G, Scene.Background.B);
            Intersection? possibleIntersection = Scene.Intersect(ray);
            if (!possibleIntersection.HasValue)
                return new Color(Scene.Background.R, Scene.Background.G, Scene.Background.B);
            Intersection intersection = possibleIntersection.Value;
            intersection.Tracer = this;
            if (depth == 4) {
                return new Color(Scene.Background.R, Scene.Background.G, Scene.Background.B);
            }
            Color result = intersection.Material.Ambient * Scene.Ambient;
            foreach (var light in Scene.Lights) {
                Vector lightDir = light.GetDirAt(intersection.Point);
				double lightPower = 1.0;
                Color lightColor = light.shade(intersection);
                
                Color current = new Color();
                current += ShadingModels.LambertModel(intersection, lightDir) * intersection.Material.Lambert;
                current += ShadingModels.PhongModel(intersection, lightDir) * intersection.Material.Phong;
                //current += ShadingModels.BlinnPhongModel(intersection, lightDir) * intersection.Material.BlinnPhong;

                current *= (lightColor * lightPower);

                result += current;
            }

            if (intersection.Material.Reflectance > 0) {
                result += intersection.Material.ReflectiveColor * intersection.Material.Reflectance *
                          trace(new Ray(
                                  intersection.Point,
                                  Vector.Reflect(
                                      intersection.Ray.Direction, 
                                      intersection.Normal)
                              ) , depth - 1);
            }

            if (intersection.Material.Refractivity > 0) {
                Vector? direction = Vector.Refract(
                    intersection.Ray.Direction,
                    intersection.Normal,
                    intersection.Material.RefractivePower
                );
                if (direction.HasValue)
                    result += intersection.Material.RefractiveColor * intersection.Material.Refractivity *
                              trace(new Ray(intersection.Point, direction.Value) , depth - 1);
            }
            
            return result;
        }
    }
}