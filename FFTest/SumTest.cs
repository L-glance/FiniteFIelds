using FF;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFTest
{
    public class SumTest
    {
        [Test]
        public void Sum1()
        {
            var GF4 = new FiniteField(2, 2, new int[] { 1, 1, 1 });
            var element1 = new FiniteFieldElement(new int[] { 1, 1 }, GF4);
            var element2 = new FiniteFieldElement(new int[] { 0, 1 }, GF4);
            var sum = element1 + element2;
            Assert.That(sum.Poly, Is.EqualTo(new int[] {1,0}));
        }
        [Test]
        public void Sum2()
        {
            var GF9 = new FiniteField(3, 2, new int[] {1, 1, 2 });
            var element1 = new FiniteFieldElement(new int[] { 1, 2 }, GF9);
            var element2 = new FiniteFieldElement(new int[] { 1, 1 }, GF9);
            var sum = element1 + element2;
            Assert.That(sum.Poly, Is.EqualTo(new int[] { 2, 0 }));
        }
    }
}
