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
            var field = el1.field;
            return null;
        }
        public static FiniteFieldElement operator *(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            if (!el1.field.Equals(el2.field))
                throw new InvalidOperationException();
            var field = el1.field;
            return null;
        }
        private static int mod(int k, int n) => ((k %= n) < 0) ? k + n : k;

    }
}
