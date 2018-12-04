using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace RayTracer
{
    class Ray
    {
        public Ray(Point3D anOrigin, Vector3D aDirection)
        {
            Origin = anOrigin;
            Direction = aDirection.Normalized();
        }

        public Point3D Origin { get; }
        public Vector3D Direction { get; }
    }
}
