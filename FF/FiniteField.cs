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
        private int[] IrreduciblePoly { get; set; }
        public readonly int degree;
        public readonly int characteristic;
        public readonly int order;
        public readonly bool isPrimeField;
        public readonly bool isPolyCharacteristicEqualTwo;
        public FiniteField(int characteristic, int degree, int[] irreduciblePoly)
        {
            IrreduciblePoly = irreduciblePoly;
            this.characteristic = characteristic;
            this.degree = degree;
            order = (int)Math.Pow(characteristic, degree);
            isPrimeField = false;
            isPolyCharacteristicEqualTwo = characteristic == 2 ? true : false;
        }
        public FiniteField(int order)
        {
            this.characteristic = order;
            this.order = order;
            isPrimeField = true;
            IrreduciblePoly = Array.Empty<int>();
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
            if (IrreduciblePoly == null)
                return "Poly not exist";
            string polynomialString = "";
            for (int i = 0; i < IrreduciblePoly.Length; i++)
            {

                // Skip zero coefficients
                if (IrreduciblePoly[i] == 0)
                    continue;

                // Adding sign if degre isn't the degree of the polynomial
                if (i != 0)
                {
                    string sign = "";
                    if (IrreduciblePoly[i] < 0)
                        sign = "-";
                    else
                        sign = "+";
                    polynomialString += sign;
                }
                // Adding coefficient if it's not 1 or it is constant term
                if (Math.Abs(IrreduciblePoly[i]) != 1 || i == IrreduciblePoly.Length - 1)
                    polynomialString += Math.Abs(IrreduciblePoly[i]);

                // Adding the exponent 
                if (i < IrreduciblePoly.Length - 2)
                    polynomialString += "x^" + $"{IrreduciblePoly.Length - 1 - i}";
                // Not adding the exponent when it equals 1
                else if (i == IrreduciblePoly.Length - 2)
                    polynomialString += "x";
            }

            return polynomialString;
        }
        public override bool Equals(object? obj)
        {
            if (obj is not FiniteField field) return false;
            if (field.characteristic == this.characteristic && field.degree == this.degree) return true;
            return false;
        }
        public override int GetHashCode()
        {
            return IrreduciblePoly.GetHashCode() + characteristic.GetHashCode() + isPrimeField.GetHashCode() + 666;
        }
        public FiniteFieldElement GetZero()
        {
            return new FiniteFieldElement(new int[] { 0 }, this);
        }
        public FiniteFieldElement GetOne()
        {
            return new FiniteFieldElement(new int[] { 1 }, this);  
        }
    }
}
