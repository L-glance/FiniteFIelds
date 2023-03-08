using FF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFTest
{
    public class GetInverseElementTest
    {
        [Test]
        public void GetInversePrimeField1()
        {
            var GF7 = new FiniteField(7);
            var element1 = new FiniteFieldElement(5, GF7);
            var inverse = element1.GetInverse();
            Assert.That(inverse.element,Is.EqualTo(3));
        }
        [Test]
        public void GetInversePrimeField2()
        {
            var GF7 = new FiniteField(7);
            var element1 = new FiniteFieldElement(1, GF7);
            var inverse = element1.GetInverse();
            Assert.That(inverse.element, Is.EqualTo(1));
        }
        [Test]
        public void GetInverseNoPrimeField1()
        {
            var GF4 = new FiniteField(2,2,new int[] {1,1,1});
            var element1 = new FiniteFieldElement(new int[] {1,1}, GF4);
            var inverse = element1.GetInverse();
            Assert.That(inverse.Poly, Is.EqualTo(new int[] {1,0}));
        }
    }
}
