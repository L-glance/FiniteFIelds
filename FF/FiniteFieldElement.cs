using System.Xml.Linq;

namespace FF
{
    public class FiniteFieldElement
    {
        public int[] Poly { get; set; }
        public readonly FiniteField field;
        public FiniteFieldElement(FiniteField field)
        {
            this.field = field;
        }
        public FiniteFieldElement(int[] Poly,FiniteField field)
        {
            this.field = field;
            this.Poly = Poly;
        }
        public static FiniteFieldElement operator +(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            if (!el1.field.Equals(el2.field))
                throw new InvalidOperationException();
            var field = el1.field;

            var sum = new FiniteFieldElement(new int[field.degree], el1.field);

            for (var i = 0; i < field.degree; i++)
                sum.Poly[i] = mod(el1.Poly[i] + el2.Poly[i], field.characteristic);
            return sum;
        }
        public static FiniteFieldElement operator -(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            if (!el1.field.Equals(el2.field))
                throw new InvalidOperationException();
            var field = el1.field;

            var substract = new FiniteFieldElement(new int[field.degree], el1.field);

            for (var i = 0; i < field.degree; i++)
                substract.Poly[i] = mod(el1.Poly[i] - el2.Poly[i], field.characteristic);
            return substract;
        }
        public static FiniteFieldElement operator /(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            if (!el1.field.Equals(el2.field))
                throw new InvalidOperationException();
            return null;
        }
        public static FiniteFieldElement operator *(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            if (!el1.field.Equals(el2.field))
                throw new InvalidOperationException();
            var field = el1.field;
            var multPoly = new int[el1.Poly.Length + el2.Poly.Length - 1];
            for(var i = el1.Poly.Length - 1; i >=0 ;i--)
            {
                for(var j = el2.Poly.Length -1;j >= 0;j--)
                {
                    multPoly[i + j] += el1.Poly[i] * el2.Poly[j];
                }
            }
            return new FiniteFieldElement(multPoly, field);
        }
        public static FiniteFieldElement operator %(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            if (!el1.field.Equals(el2.field))
                throw new InvalidOperationException();

            var field = el1.field;
            var dividend = el1.Poly;
            var divisor = el2.Poly;

            int dividendDegree = dividend.Length - 1;
            int divisorDegree = divisor.Length - 1;

            if (dividendDegree < divisorDegree)
            {
                return el1;
            }

            int[] quotient = new int[dividendDegree - divisorDegree + 1];
            int[] remainder = new int[dividendDegree + 1];
            Array.Copy(dividend, remainder, dividendDegree + 1);

            for (int i = dividendDegree - divisorDegree; i >= 0; i--)
            {
                quotient[i] = remainder[i + divisorDegree] / divisor[divisorDegree];

                for (int j = i + divisorDegree; j >= i; j--)
                {
                    remainder[j] -= quotient[i] * divisor[j - i];
                }
            }

            Array.Resize(ref remainder, divisorDegree);
            return new FiniteFieldElement(remainder, field);
        }
        private static int mod(int k, int n) => ((k %= n) < 0) ? k + n : k;

    }
}
