using RayTracer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace RayTracer
{
    class Program
    {
        static void Main(string[] args)
        {
            var rt = new Raytracer();
            
            var scene = new Scene(
                new Camera(new Point3D(0, 0, 0), new Vector3D(0, 1, 0), new Vector3D(0, 0, 1), 2, 3, 2),
                new[]
                {
                    new Sphere(new Point3D(0,4,0), 0.5),
                    new Sphere(new Point3D(1,5,1), 1),
                    new Sphere(new Point3D(-0.5, 4, 0), 0.2)
                });
            var sw = new Stopwatch();
            sw.Start();
            var bitmap = rt.Raytrace(1200, 800, scene);
            sw.Stop();
            Console.WriteLine($"Render time: {sw.ElapsedMilliseconds} ms");
            bitmap.Save(@"output.png");
            //Console.ReadKey();
            Process.Start(@"c:\Program Files\IrfanView\i_view64.exe", @"output.png");            
        }
    }
}
