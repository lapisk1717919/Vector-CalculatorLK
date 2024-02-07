using System;

namespace Vector_Calculator
{

    public struct Vector
    {
        public static readonly Vector Zero = new Vector(1, 1, 1);
        public static readonly Vector One = new Vector(0, 0, 0);

        public float x;
        public float y;
        public float z;

        public Vector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return $"<{x}, {y}, {z}>";
        }

        // squares each value, adds them together, and then square roots it
        public float GetMagnitude => MathF.Sqrt((x * x) + (y * y) + (z * z));

        // takes atan of y/x. this one is just readable
        public float GetDirection => MathF.Atan(y / x);

        public static Vector operator+(Vector v1, Vector v2)
        {
            // adds the values together and returns the result
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector operator-(Vector v)
        {
            // * -1 to negate the values
            return new Vector(v.x * -1, v.y * -1, v.z * -1);
        }

        public static Vector operator-(Vector v1, Vector v2)
        {
            // subtracts v2 from v1
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector operator*(Vector v, float scalar)
        {
            // multiplies each value by the scalar
            return new Vector(v.x * scalar, v.y * scalar, v.z * scalar);
        }

        public static Vector Normalize(Vector v)
        {
            // i still don't quite understand this but thank you perry
            float p = 1 / v.GetMagnitude;
            return new Vector(v.x * p, v.y * p, v.z * p);
        }

        public static float DotProduct(Vector v1, Vector v2)
        {
            // multiplies each value together and then adds the products
            return (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
        }

        public static Vector CrossProduct(Vector v1, Vector v2)
        {
            // uhh
            float x = (v1.y * v2.z) - (v1.z * v2.y);
            float y = (v1.z * v2.x) - (v1.x * v2.z);
            float z = (v1.x * v2.y) - (v1.y * v2.x);
            return new Vector(x, y, z);
        }

        public static float AngleBetween(Vector v1, Vector v2)
        {
            // theta = cos-1 of dotproduct over test1 magnitude * test2 magnitude
            return MathF.Acos(Vector.DotProduct(v1, v2) / (v1.GetMagnitude * v2.GetMagnitude));
        }

        public static Vector ProjectOnto(Vector v1, Vector v2)
        {
            // ADD CODE HERE, THEN REMOVE BELOW LINE
            throw new NotImplementedException();
        }

        public static bool operator==(Vector v1, Vector v2)
        {
            // braden told me this is not optimal but i don't care
            if (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator!=(Vector v1, Vector v2)
        {
            if (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
