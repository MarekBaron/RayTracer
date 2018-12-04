using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace RayTracer
{
    class Camera
    {
        public Camera(Point3D aPosition, Vector3D aDirection, Vector3D anUpVector, double aFocalLength, double aFrameWidth, double aFrameHeight)
        {
            Position = aPosition;
            Direction = aDirection.Normalized();
            UpVector = anUpVector.Normalized();
            FocalLength = aFocalLength;
            FrameWidth = aFrameWidth;
            FrameHeight = aFrameHeight;
        }

        public Point3D Position { get; }
        public Vector3D Direction { get; }
        public Vector3D UpVector { get; }
        public double FocalLength { get; }
        public double FrameWidth { get; }
        public double FrameHeight { get; }
    }
}
