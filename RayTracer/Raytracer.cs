using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Media3D;
using RayTracer.Entities;

namespace RayTracer
{
    class Raytracer
    {
        public Bitmap Raytrace(int aWidth, int aHeight, Scene aScene)
        {
            var bitmap = new Bitmap(aWidth, aHeight);
            for (var x = 0; x < aWidth; x++)
                for (var y = 0; y < aHeight; y++)
                    bitmap.SetPixel(x, y, GetColor(x, aHeight - y, aWidth, aHeight, aScene));
            
            return bitmap;
        }

        private Color GetColor(int x, int y, int aWidth, int aHeight, Scene aScene)
        {
            var ray = CreateRay(x, y, aWidth, aHeight, aScene.Camera);
            var intersection = FindIntersection(ray, aScene.Entities);
            return intersection == null ? Color.Transparent : DistanceToColor((intersection.Position - aScene.Camera.Position).Length, aScene.Camera.FocalLength, 6);            
        }

        private Color DistanceToColor(double aDistance, double aNearPlane, double aFarPlane)
        {
            var value = (int)(255d * (1 + (aNearPlane - aDistance) / (aFarPlane - aNearPlane)));
            value = value < 0 ? 0 : value;
            return Color.FromArgb(value, value, value);
        }

        private Intersection FindIntersection(Ray aRay, IReadOnlyList<Sphere> anEntities)
        {
            return anEntities
                .Select(e => e.Intersect(aRay))
                .Where(i => i != null)
                .OrderBy(i => i.Distance)
                .FirstOrDefault();
        }

        private Ray CreateRay(int x, int y, int aWidth, int aHeight, Camera aCamera)
        {
            var cameraRightVector = Vector3D.CrossProduct(aCamera.Direction, aCamera.UpVector);
            var frameLowerLeft = aCamera.Position
                + aCamera.Direction * aCamera.FocalLength
                - aCamera.UpVector * aCamera.FrameHeight / 2
                - cameraRightVector * aCamera.FrameWidth / 2;
            var frameUpperRight = aCamera.Position
                + aCamera.Direction * aCamera.FocalLength
                + aCamera.UpVector * aCamera.FrameHeight / 2
                + cameraRightVector * aCamera.FrameWidth / 2;
            var frameLowerRight = frameLowerLeft + cameraRightVector * aCamera.FrameWidth;
            var xOnBottom = frameLowerLeft + cameraRightVector * aCamera.FrameWidth * (x / (float)aWidth);
            var vectorEndPoint = xOnBottom + aCamera.UpVector * aCamera.FrameHeight * (y / (float)aHeight);
            return new Ray(aCamera.Position, new Vector3D(vectorEndPoint.X, vectorEndPoint.Y, vectorEndPoint.Z));
        }
    }
}
