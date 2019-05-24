using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonLib.Tools
{
    public class D3DVector
    {
        private float X;
        private float Y;
        private float Z;
        public byte padding;

        public D3DVector()
        {
            X = 0.0f;
            Y = 0.0f;
            Z = 0.0f;
            padding = 1;
        }

        public D3DVector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
            padding = 1;
        }

        public float GetX()
        {
            return this.X;
        }

        public float GetY()
        {
            return this.Y;
        }

        public float GetZ()
        {
            return this.Z;
        }
    }
}
