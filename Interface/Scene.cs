using System;
using System.Collections.Generic;
using RayTracer.Lights;

namespace RayTracer {
    public class Scene {
        public List<Object> Objects;
        public List<DirectedLight> Lights;
        public Color Ambient;
        public Color Background;
        
        public Scene(
                List<Object> objects, 
                List<DirectedLight> lights, 
                Color ambient = new Color(),
                Color background = new Color()) {
            Objects = objects;
            Lights = lights;
            Ambient = ambient;
            Background = background;
        }
        
        public Intersection? Intersect(Ray ray) {
            Intersection? result = Objects[0].Intersect(ray);
            for (int i = 0; i < Objects.Count; i++) {
                Intersection? current = Objects[i].Intersect(ray);
                if (current.HasValue) {
                    if (!result.HasValue || result.Value.Distance > current.Value.Distance) {
                        result = current;
                    }
                }
            }
            return result;
        }

        public List<Intersection> Intersections(Ray ray) {
            var result = new List<Intersection>();
            Intersection? intersection = Intersect(ray);

            while (intersection.HasValue) {
                result.Add(intersection.Value);
                intersection = Intersect(new Ray(intersection.Value.Point + ray.Direction * 0.001, ray.Direction));
            }
                
            return result;
        }
    }
}