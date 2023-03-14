namespace FF
{
    public class FiniteFieldElement
    {
        public int[] Poly { get; set; }
        public readonly FiniteField field;
        public int element;
        public FiniteFieldElement(int element,FiniteField field)
        {
            Poly = Array.Empty<int>();
            this.field = field;
            this.element = element;
        }
        public FiniteFieldElement(int[] Poly,FiniteField field)
        {
            this.field = field;
            this.Poly = Poly;
            this.element = GetElementFromPoly();
        }
        private int GetElementFromPoly()
        {
            var degree = 0;
            var element = 0;
            for (var i = Poly.Length - 1; i >= 0; i--)
                element += Poly[i] * (int)Math.Pow(field.characteristic, degree++);
            return element;
        }
        public static FiniteFieldElement operator +(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            // return if elements from different fields.
            if (!el1.field.Equals(el2.field))
                throw new InvalidOperationException();
            
            var field = el1.field;
            if (field.isPrimeField)
                return AddingPrimeFieldElements(el1, el2);
            else
                return AddingNoPrimeFieldElements(el1, el2);
        }
        private static FiniteFieldElement AddingPrimeFieldElements(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            el1.element = mod(el1.element + el2.element,el1.field.characteristic);
            return el1;
        }   
        private static FiniteFieldElement AddingNoPrimeFieldElements(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            var field = el1.field;
            var maxDegreeElement = el1.Poly.Length > el2.Poly.Length ? el1 : el2;
            var minDegreeElement = el1.Equals(maxDegreeElement) ? el2 : el1;
            var sum = maxDegreeElement;
            for (var i = minDegreeElement.Poly.Length - 1; i >= 0; i--)
            {
                var maxElementDegree = i + maxDegreeElement.Poly.Length - minDegreeElement.Poly.Length;
                sum.Poly[maxElementDegree] = mod(maxDegreeElement.Poly[maxElementDegree] + minDegreeElement.Poly[i], field.characteristic);
            }
            return new FiniteFieldElement(CutFirstZeros(sum.Poly), field);
        }
        public static FiniteFieldElement operator -(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            if (!el1.field.Equals(el2.field))
                throw new InvalidOperationException();
            var field = el1.field;
            if (field.isPrimeField)
                return SubstractionPrimeFieldElements(el1, el2);
            else
                return SubstractionNoPrimeFieldElements(el1, el2);
        }
        private static FiniteFieldElement SubstractionPrimeFieldElements(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            el1.element = mod(el1.element - el2.element,el1.field.characteristic);
            return el1;
        }
        private static FiniteFieldElement SubstractionNoPrimeFieldElements(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            var field = el1.field;
            var substract = el1;
            if (el1.Poly.Length < el2.Poly.Length)
            {
                var difference = el2.Poly.Length - el1.Poly.Length;
                var newPoly = new int[el2.Poly.Length];
                for(var i = difference; i < el2.Poly.Length;i++)
                    newPoly[i] = el1.Poly[i - difference];
                el1.Poly = newPoly;
            }
            for (var i = 0; i < el2.Poly.Length; i++)
                substract.Poly[i] = mod(el1.Poly[i] - el2.Poly[i], field.characteristic);
            return new FiniteFieldElement(substract.Poly, field);
        }
        public static FiniteFieldElement operator *(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            if (!el1.field.Equals(el2.field))
                throw new InvalidOperationException();
            var field = el1.field;
            if (field.isPrimeField)
                return MultiplicationPrimeFieldElements(el1, el2);
            else
                return MultiplicationNoPrimeFieldElements(el1, el2);
        }
        private static FiniteFieldElement MultiplicationNoPrimeFieldElements(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            var field = el1.field;
            var multPoly = new int[el1.Poly.Length + el2.Poly.Length - 1];
            for (var i = el1.Poly.Length - 1; i >= 0; i--)
                for (var j = el2.Poly.Length - 1; j >= 0; j--)
                    multPoly[i + j] += el1.Poly[i] * el2.Poly[j];
            multPoly = DividePolynomials(multPoly, field.irreduciblePoly);
            for(var i = 0; i< multPoly.Length;i++)
                multPoly[i] = mod(multPoly[i],field.characteristic);
            multPoly = CutFirstZeros(multPoly);
            return new FiniteFieldElement(multPoly,field);
        }
        static int[] DividePolynomials(int[] dividend, int[] divisor)
        {
            if (dividend.Length < divisor.Length) return dividend;
            var quotient = new int[dividend.Length - divisor.Length + 1];
            var remainder = dividend;

            for (var i = 0; i < quotient.Length; i++)
            {
                var coef = remainder[i] / divisor[0];
                quotient[i] = coef;
                for (var j = 0; j < divisor.Length; j++)
                    remainder[i + j] = remainder[i + j] - coef * divisor[j];
            }
            return remainder;
        }
        private static FiniteFieldElement MultiplicationPrimeFieldElements(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            var element = mod(el1.element * el2.element,el1.field.characteristic);
            return new FiniteFieldElement(element,el1.field);
        }
        public static FiniteFieldElement operator /(FiniteFieldElement el1, FiniteFieldElement el2)
        {
            if (!el1.field.Equals(el2.field))
                throw new InvalidOperationException();
            if (el2.element.Equals(el2.field.GetZero()))
                throw new DivideByZeroException();
            return el1 * el2.GetInverse();
        }
        public FiniteFieldElement Pow(int degree)
        {
            FiniteFieldElement el = this;
            if (element == 0) return field.GetZero();
            if (degree == 0) return field.GetOne();
            if (degree % 2 == 0)
                return Pow(degree / 2) * Pow(degree / 2);
            else
                return el * Pow(degree - 1);
        }
        public FiniteFieldElement GetInverse()
        {
            if (field.isPrimeField)
                return GetInversePrimeFieldElement();
            else
                return GetInverseNoPrimeFieldElement();
        }
        private FiniteFieldElement GetInverseNoPrimeFieldElement() => Pow(field.order - 2);
        private FiniteFieldElement GetInversePrimeFieldElement()
        {
            var element = (int)Math.Pow(this.element,field.characteristic - 2) % field.characteristic;
            return new FiniteFieldElement(element,field);
        }
        public FiniteFieldElement GetOpposite() => this.field.GetZero() - this;
        public byte[] ConvertToByte()
        {
            if (!field.isPolyCharacteristicEqualTwo) throw new InvalidOperationException("Попытка конвертации поля характеристики не 2");
            return BitConverter.GetBytes(element);
        }
        public override bool Equals(object? obj)
        {
            if (obj is not FiniteFieldElement el) return false;
            if(el.element != element) return false;
            if (!el.field.Equals(this.field)) return false;
            return true;
        }
        public override int GetHashCode() => field.GetHashCode() + element.GetHashCode();
        private static int mod(int k, int n) => ((k %= n) < 0) ? k + n : k;
        private static int[] CutFirstZeros(int[] poly)
        {
            if (poly.Length == 0 || poly[0] != 0) return poly;
            var list = new List<int>();
            bool isAllZero = true;
            for(var i = 0;i < poly.Length;i++)
            {
                if (poly[i] != 0)
                {
                    for(var j = i;j < poly.Length;j++)
                        list.Add(poly[j]);
                    isAllZero = false;
                    break;
                }
            }
            if (isAllZero) list.Add(0);
            return list.ToArray();
        }
    }
}
