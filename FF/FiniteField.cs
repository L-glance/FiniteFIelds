using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace FF
{
    public class FiniteField
    {
        private int[] _irreduciblePoly { get; set; }
        public readonly int degree;
        public readonly int characteristic;
        public readonly int order;

        public FiniteField(int characteristic, int[] irreduciblePoly, int degree)
        {
            _irreduciblePoly = irreduciblePoly;
            this.characteristic = characteristic;
            this.degree = degree;
            order = (int)Math.Pow(characteristic, degree);
        }
        public override string ToString()
        {
            return $"name: GF({characteristic}^{degree})\\" +
                $"characteristic: {characteristic}\\" +
                $"degree: {degree}\\" +
                $"order {(int)Math.Pow(characteristic, degree)}\\" +
                $"irreducible_poly: {GetIrreduciblePoly()}";
        }
        public string GetIrreduciblePoly()
        {
            string polynomialString = "";
            for (int i = 0; i < _irreduciblePoly.Length; i++)
            {

                // Skip zero coefficients
                if (_irreduciblePoly[i] == 0)
                    continue;

                // Adding sign if degre isn't the degree of the polynomial
                if (i != 0)
                {
                    string sign = "";
                    if (_irreduciblePoly[i] < 0)
                        sign = "-";
                    else
                        sign = "+";
                    polynomialString += sign;
                }
                // Adding coefficient if it's not 1 or it is constant term
                if (Math.Abs(_irreduciblePoly[i]) != 1 || i == _irreduciblePoly.Length - 1)
                    polynomialString += Math.Abs(_irreduciblePoly[i]);

                // Adding the exponent 
                if (i < _irreduciblePoly.Length - 2)
                    polynomialString += "x^" + $"{_irreduciblePoly.Length - 1 - i}";
                // Not adding the exponent when it equals 1
                else if (i == _irreduciblePoly.Length - 2)
                    polynomialString += "x";
            }

            return polynomialString;
        }
        public override bool Equals(object? obj)
        {
            var field = obj as FiniteField;
            
            if(field == null) return false;
            
            if(field.characteristic == this.characteristic && field.degree == this.degree) return true;

            return false;
        }
    }
}
