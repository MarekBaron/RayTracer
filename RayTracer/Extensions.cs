using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace RayTracer
{
    static class Extensions
    {
        public static Vector3D Normalized(this Vector3D aVector)
        {
            var newVector = new Vector3D(aVector.X, aVector.Y, aVector.Z);
            newVector.Normalize();
            return newVector;
        }
    }
}
