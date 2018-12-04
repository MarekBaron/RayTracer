using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace RayTracer.Entities
{
    class Sphere
    {
        public Sphere(Point3D aPosition, double aRadius)
        {
            Position = aPosition;
            Radius = aRadius;
        }

        public Point3D Position { get; }
        public double Radius { get; }

        internal Intersection Intersect(Ray aRay)
        {
            //sprawdzić, jak wygląda implementacja z rozwiązania analitycznego
            var closestPointOnRay = aRay.Origin + Vector3D.DotProduct(aRay.Direction, Position - aRay.Origin) * aRay.Direction;
            var distance = (Position - closestPointOnRay).Length;
            if (distance > Radius)
                return null;
            var s = Math.Sqrt(Radius * Radius - distance * distance);
            var closestIntersectionPoint = closestPointOnRay - aRay.Direction * s;
            return new Intersection(closestIntersectionPoint, new Vector3D(), (aRay.Origin - closestIntersectionPoint).Length, this);
        }
    }
}
