using FF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFTest
{
    public class PowTest
    {
        [Test]
        public void Pow1()
        {
            var GF4 = new FiniteField(2, 2, new int[] { 1, 1, 1 });
            var el1 = new FiniteFieldElement(new int[] { 1, 1 }, GF4);
            var el2 = new FiniteFieldElement(new int[] { 1, 0 }, GF4);
            var pow = el1.Pow(2);
            Assert.That(new int[] {1,0}, Is.EqualTo(pow.Poly));
        }
        [Test]
        public void Pow2()
        {
            var GF9 = new FiniteField(3, 2, new int[] { 1, 2, 2 });
            var el1 = new FiniteFieldElement(new int[] { 2, 1 }, GF9);
            var pow = el1.Pow(2);
            Assert.That(new int[] { 2, 2 }, Is.EqualTo(pow.Poly));
        }
        [Test]
        public void Pow3()
        {
            var GF9 = new FiniteField(3, 2, new int[] { 1, 2, 2 });
            var el1 = new FiniteFieldElement(new int[] { 2, 1 }, GF9);
            var pow = el1.Pow(9);
            Assert.That(el1.Poly,Is.EqualTo(pow.Poly));
        }
    }
}
