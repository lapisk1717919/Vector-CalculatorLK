using System;

namespace Vector_Calculator
{

    public struct Vector
    {
        public static readonly Vector Zero = new Vector(1, 1, 1);
        public static readonly Vector One = new Vector(0, 0, 0);

        public float[] components;

        public float X => components[0];
        public float Y => components[1];
        public float Z => components[2];

        public Vector(params float[] components)
        {
            this.components = components;
        }

        public Vector(int size)
        {
            this.components = new float[size];
        }

        public override string ToString()
        {
            string output = string.Empty;
            for (int i = 0; i < components.Length; i++)
            {
                output += components[i] + ", ";
            }
                return $"<{output}>";
        }

        // squares each value, adds them together, and then square roots it
        public float GetMagnitude => MathF.Sqrt((X * X) + (Y * Y) + (Z * Z));

        // takes atan of y/x. this one is just readable
        public float GetDirection => MathF.Atan(Y / X); 

        public static Vector operator+(Vector v1, Vector v2)
        {
            Vector output = new Vector(v1.components.Length);

            // adds the values together and returns the result
            for (int i = 0; i < v1.components.Length; i++)
            {
                float newcomponent = v1.components[i] + v2.components[i];
                output.components[i] = newcomponent;
            }

            return output;
        }

        public static Vector operator-(Vector v)
        {
            // * -1 to negate the values
            Vector output = new Vector(v.components.Length);
            for (int i = 0; i < v.components.Length; i++)
            {
                float newcomponent = v.components[i] * -1;
                output.components[i] = newcomponent;
            }

            return output;
        }

        public static Vector operator-(Vector v1, Vector v2)
        {
            // subtracts v2 from v1
            Vector output = new Vector(v1.components.Length);
            for (int i = 0; i < v1.components.Length; i++)
            {
                float newcomponent = v1.components[i] - v2.components[i];
                output.components[i] = newcomponent;
            }

            return output;
        }

        public static Vector operator*(Vector v, float scalar)
        {
            // multiplies each value by the scalar
            Vector output = new Vector(v.components.Length);
            for (int i = 0; i < v.components.Length; i++)
            {
                float newcomponent = v.components[i] * scalar;
                output.components[i] = newcomponent;
            }

            return output;
        }

        public static Vector Normalize(Vector v)
        {
            // i still don't quite understand this but thank you perry
            float p = 1 / v.GetMagnitude;
            Vector output = new Vector(v.components.Length);
            for (int i = 0; i < v.components.Length; i++)
            {
                float newcomponent = v.components[i] * p;
                output.components[i] = newcomponent;
            }

            return output;
        }

        public static float DotProduct(Vector v1, Vector v2)
        {
            // multiplies each value together and then adds the products
            float output = 0;
            for (int i = 0; i < v1.components.Length; i++)
            {
                float newcomponent = v1.components[i] * v2.components[i];
                output += newcomponent;
            }
            return output;
            //this is stupid. it works though, which means it isn't stupid
        }

        public static Vector CrossProduct(Vector v1, Vector v2)
        {
            //if vector longer than 3 return 0, 0, 0
            if (v1.components.Length == 3)
            {
                //hard to explain just read the code
                float x = (v1.Y * v2.Z) - (v1.Z * v2.Y);
                float y = (v1.Z * v2.X) - (v1.X * v2.Z);
                float z = (v1.X * v2.Y) - (v1.Y * v2.X);
                return new Vector(x, y, z);
            }
            else
            {
                return new Vector(0, 0, 0);
            }
        }

        public static float AngleBetween(Vector v1, Vector v2)
        {
            // theta = cos-1 of dotproduct over test1 magnitude * test2 magnitude
            return MathF.Acos(DotProduct(v1, v2) / (v1.GetMagnitude * v2.GetMagnitude));
        }

        public static Vector ProjectOnto(Vector v1, Vector v2)
        {
            //if vector longer than 3 return 0, 0, 0
            if (v1.components.Length == 3)
            {
                //again just look at the code
                float x = DotProduct(v1, v2) / (v2.GetMagnitude * v2.GetMagnitude) * v2.X;
                float y = DotProduct(v1, v2) / (v2.GetMagnitude * v2.GetMagnitude) * v2.Y;
                float z = DotProduct(v1, v2) / (v2.GetMagnitude * v2.GetMagnitude) * v2.Z;
                return new Vector(x, y, z);
            }
            else
            {
                return new Vector(0, 0, 0);
            }
        }

        public static bool operator==(Vector v1, Vector v2)
        {
            // this is DEFINITELY not optimal but I don't have time
            float equalcheck = 0;
            for (int i = 0; i < v1.components.Length; i++)
            {
                if (v1.components[i] == v2.components[i])
                {
                    //"Assignment made to same variable; did you mean to assign something else?" nope! i just could not figure out how to make it exit the check without doing this
                    equalcheck = equalcheck;
                }
                else
                {
                    equalcheck++;
                }
            }
            if (equalcheck == 0)
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
            return !(v1 == v2);
        }
    }
}
