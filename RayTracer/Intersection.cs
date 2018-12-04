using RayTracer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace RayTracer
{
    class Intersection
    {
        public Intersection(Point3D aPosition, Vector3D aNormal, double aDistance, Sphere anEntity)
        {
            Position = aPosition;
            Normal = aNormal.Normalized();
            Entity = anEntity;
            Distance = aDistance;
        }

        public Point3D Position { get; }
        public Vector3D Normal { get; }
        public Sphere Entity { get; }
        public double Distance { get; }
    }
}
