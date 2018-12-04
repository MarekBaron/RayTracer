using RayTracer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    class Scene
    {
        public Scene(Camera aCamera, IReadOnlyList<Sphere> anEntities)
        {
            Camera = aCamera;
            Entities = anEntities;
        }

        public Camera Camera { get; }
        public IReadOnlyList<Sphere> Entities { get; }
    }
}
