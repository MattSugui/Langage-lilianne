using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fonder.Lilian.New
{
    public static class Datatypes
    {
        public struct IntegralType : IComparable
        {
            public IntegralType(byte size)
            {
                PlaneSize = size;
                Value = new bool[size];
                for (int i = 0; i < size; i++) Value[i] = false;
            }

            public IntegralType(byte size, int input)
            {
                PlaneSize = size;
                Value = new bool[size];
                for (int i = 0; i < size; i++) Value[i] = false;

                List<bool> thing = TurnToLilianManagedBinary(input);
                if (thing.Count > PlaneSize) throw new Interpreter.Lamentation("bruh!!!", 21);
                for (int i = 0; i < thing.Count; i++) Value[i] = thing[^i];
            }

            internal List<bool> TurnToLilianManagedBinary(double input)
            {
                double controlVar = input;
                List<bool> ListOfBools = new();

                do
                {
                    if (controlVar % 2 == 0) ListOfBools.Add(false); else if (controlVar % 2 == 1) ListOfBools.Add(true);
                    controlVar /= 2;
                }
                while (controlVar > 1);
                if (controlVar == 1) ListOfBools.Add(true); else if (controlVar == 0) ListOfBools.Add(false);
                return ListOfBools;
            }

            public byte PlaneSize { get; }
            public bool[] Value { get; }
            public int CompareTo(object obj)
            {
                throw new NotImplementedException();
            }
        }
    }
}
