using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RayTracer;
using RayTracer.Geometry;
using RayTracer.Lights;
using Color = RayTracer.Color;
using Object = RayTracer.Object;

namespace Interface
{
    public partial class Form1 : Form
    {
		
        public Form1()
        {
            InitializeComponent();
			
			render();
        }

        private void render()
        {

			var objects = new List<RayTracer.Object>();

            
            Material sphereMaterial = new Material(
                    new Color(0.1, 0.1, 0.1),
                    new Color(0.0, 1.0, 0.0), 
                    new Color(0.0, 0.5, 0.0),
                    new Color(0.0, 0.5, 0.0),
                    new Color(0.0, 0.5, 0.0),
                    0.4, 0.2, 0.2, 5.0, 0.2
                );

            Material sphere2Material = new Material(
                new Color(0.1, 0.1, 0.1),
                new Color(1.0, 0.0, 0.0), 
                new Color(1.0, 0.0, 0.0),
                new Color(1.0, 0.0, 0.0),
                new Color(1.0, 0.0, 0.0),
                0.4, 0.2, 0.2, 5.0, 0.2
            );

            Material sphere3Material = new Material(
               new Color(0.1, 0.1, 0.1),
               new Color(0.0, 0.0, 0.7),
               new Color(0.0, 0.0, 0.7),
               new Color(0.0, 0.0, 0.7),
               new Color(0.0, 0.0, 0.7),
               0.4, 0.2, 0.2, 5.0, 0.2
           );

            Material planeMaterial = new Material(
                new Color(0.2, 0.2, 0.2),
                new Color(0.2, 0.3, 0.3), 
                new Color(0.2, 0.3, 0.3),
                new Color(0.2, 0.3, 0.3),
                new Color(0.2, 0.3, 0.3),
                0.8, 0.0, 0.0, 5.0, 1
            );

            Material planeMaterial1 = new Material(
                new Color(0.2, 0.2, 0.2),
                new Color(0.7, 0.8, 0.9), 
                new Color(0.7, 0.8, 0.9),
                new Color(0.7, 0.8, 0.9),
                new Color(0.7, 0.8, 0.9),
                0.8, 0.0, 0.0, 5.0, 0
            );

            var sphere = new Sphere(new Vector(1, 0.5, -1), 1.5);
            var sphere2 = new Sphere(new Vector(5.5, 1, 1.5), 2.0);
            var sphere3 = new Sphere(new Vector(15, 2, 5), 3);
            var plane = new Plane(new Vector(0, 1, 0), new Vector(0, -1, 0));
            var plane1 = new Plane(new Vector(0.1, 0, 1), new Vector(2, -1, -3));
           

            var lights = new List<DirectedLight>();
            lights.Add(new DirectedLight(new Vector(1.0, -1.2, -0.5), new Color(1, 1, 1)));

            objects.Add(new Object(sphere, sphereMaterial));
            objects.Add(new Object(sphere2, sphere2Material));
            objects.Add(new Object(sphere3, sphere3Material));
            objects.Add(new Object(plane, planeMaterial));
            objects.Add(new Object(plane1, planeMaterial1));
            
            var scene = new Scene(objects, lights, new Color(0.2, 0.2, 0.2), background: new Color(0.7, 0.8, 0.9));

            var tracer = new Tracer(scene);

            var viewplane = new ViewPlane();

            viewplane.Height = 512; viewplane.Width = 512; // размер изображения

            viewplane.Ratio = 1; // Width / Height

            viewplane.Distance = 1.8; // расстояние до объектов

            Vector cameraPos = new Vector(-17, 0, 0), cameraTarget = new Vector(0, 0, 0);
            Vector cameraUp = new Vector(0, 1, 0);

            var camera = new Camera(
                tracer,
                viewplane,
                cameraPos, cameraTarget, cameraUp,
                maxDepth: 5
            );

            var result = camera.Render();

            var bitmap = new Bitmap(camera.ViewPlane.Width, camera.ViewPlane.Height);


            for (int i = 0; i < viewplane.Width; i++)
            {
                for (int j = 0; j < viewplane.Height; j++)
                {
                    var c = result[i, j].Clip();
                    var col = System.Drawing.Color.FromArgb(
                        (byte)(c.R * 255),
                        (byte)(c.G * 255),
                        (byte)(c.B * 255)
                        );
                    bitmap.SetPixel(i, j, col);
                }
            }
            pictureBox1.Image = bitmap;

			
        }

   
	}
}
