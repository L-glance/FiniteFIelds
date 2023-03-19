namespace FF
{
    public class FiniteField
    {
        public readonly int[] irreduciblePoly;
        public readonly int degree;
        public readonly int characteristic;
        public readonly int order;
        public readonly bool isPrimeField;
        public readonly bool isPolyCharacteristicEqualTwo;
        public FiniteField(int characteristic, int degree, int[] irreduciblePoly)
        {
            this.irreduciblePoly = irreduciblePoly;
            this.characteristic = characteristic;
            this.degree = degree;
            order = (int)Math.Pow(characteristic, degree);
            isPrimeField = degree == 1 ? true : false;
            isPolyCharacteristicEqualTwo = characteristic == 2 ? true : false;
        }
        public FiniteField(int order)
        {
            this.characteristic = order;
            this.order = order;
            isPrimeField = true;
            irreduciblePoly = new int[] { order };
            isPolyCharacteristicEqualTwo = characteristic == 2 ? true : false;
        }
        public FiniteFieldElement GetZero()
        {
            if (isPrimeField)
                return new FiniteFieldElement(0, this);
            else
                return new FiniteFieldElement(new int[] { 0 }, this);
        }
        public FiniteFieldElement GetOne()
        {
            if (isPrimeField)
                return new FiniteFieldElement(1, this);
            else
                return new FiniteFieldElement(new int[] { 1 }, this);
        }
        public override string ToString()
        {
            return $"name: GF({characteristic}^{degree})\\" +
                $"characteristic: {characteristic}\\" +
                $"degree: {degree}\\" +
                $"order {(int)Math.Pow(characteristic, degree)}\\" +
                $"irreducible_poly: {GetIrreduciblePoly()}";
        }
        public FiniteFieldElement GetFiniteFieldElement(byte[] byteArray)
        {
            if (!isPolyCharacteristicEqualTwo) throw new InvalidOperationException("Невозможно преобразовать массив байтов в элемент поля");
            var element = BitConverter.ToInt32(byteArray, 0);
            if (element > order - 1) throw new InvalidOperationException("Выход за пределы поля");
            if (order <= 2)
                return new FiniteFieldElement(element, this);
            else
                return new FiniteFieldElement(GetArrayBinaryRepresentation(element),this);
        }
        // char subtraction is an integer
        private int[] GetArrayBinaryRepresentation(int element) => Convert.ToString(element,2).Select(c => c - '0').ToArray();
        public string GetIrreduciblePoly()
        {
            if (irreduciblePoly == null)
                return "Poly not exist";
            string polynomialString = "";
            for (int i = 0; i < irreduciblePoly.Length; i++)
            {
                // Skip zero coefficients
                if (irreduciblePoly[i] == 0)
                    continue;
                // Adding sign if degre isn't the degree of the polynomial
                if (i != 0)
                {
                    string sign = "";
                    if (irreduciblePoly[i] < 0)
                        sign = "-";
                    else
                        sign = "+";
                    polynomialString += sign;
                }
                // Adding coefficient if it's not 1 or it is constant term
                if (Math.Abs(irreduciblePoly[i]) != 1 || i == irreduciblePoly.Length - 1)
                    polynomialString += Math.Abs(irreduciblePoly[i]);

                // Adding the exponent 
                if (i < irreduciblePoly.Length - 2)
                    polynomialString += "x^" + $"{irreduciblePoly.Length - 1 - i}";
                // Not adding the exponent when it equals 1
                else if (i == irreduciblePoly.Length - 2)
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
            return irreduciblePoly.GetHashCode() + characteristic.GetHashCode() + isPrimeField.GetHashCode();
        }
    }
}
