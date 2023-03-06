using FF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFTest
{
    public class MultiplicationPolyTest
    {
        [Test]
        public void Multiplication1()
        {
            var GF4 = new FiniteField(2,2, new int[] { 1, 1, 1 } );
            var element1 = new FiniteFieldElement(new int[] { 1, 0, 1 }, GF4);
            var element2 = new FiniteFieldElement(new int[] { 1, 3 }, GF4);
            var mult = element1 * element2;
            Assert.That(mult.Poly, Is.EqualTo(new int[] { 1, 3,1,3 }));
        }
        [Test]
        public void Multiplication2()
        {
            var GF7 = new FiniteField(7);
            var element1 = new FiniteFieldElement(6,GF7);
            var element2 = new FiniteFieldElement(4,GF7);
            var mult = element1 * element2;
            Assert.That(mult.element, Is.EqualTo(3));
        }
        [Test]
        public void MultiplicationPrimeFieldZero()
        {
            var GF7 = new FiniteField(7);
            var element1 = new FiniteFieldElement(6, GF7);
            var element2 = GF7.GetZero();
            var mult = element1 * element2;
            Assert.That(mult.element, Is.EqualTo(0));
        }
        [Test]
        public void MultiplicationNoPrimeFieldZero()
        {
            var GF4 = new FiniteField(2, 2, new int[] { 1, 1, 1 });
            var element1 = new FiniteFieldElement(new int[] { 1, 0, 1 }, GF4);
            var element2 = GF4.GetZero();
            var mult = element1 * element2;
            mult = mult + element1;
            Assert.That(mult.element, Is.EqualTo(element1.element));
        }
    }
}
