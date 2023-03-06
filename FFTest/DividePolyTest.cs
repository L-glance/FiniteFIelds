using FF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFTest
{
    public class DividePolyTest
    {
        [Test]
        public void DivideWithMod()
        {
            var GF4 = new FiniteField(2, 2, new int[] { 1, 1, 1 });
            var element1 = new FiniteFieldElement(new int[] { 1, 2, 3, 4 }, GF4);
            var element2 = new FiniteFieldElement(new int[] { 1, -1 }, GF4);
            var mylt = element1 % element2;
            Assert.That(mylt.Poly, Is.EqualTo(new int[] {10}));
        }
        [Test]
        public void DoNotDivide()
        {
            var GF4 = new FiniteField(2, 2, new int[] { 1, 1, 1 });
            var element1 = new FiniteFieldElement(new int[] { 1, -1 }, GF4);
            var element2 = new FiniteFieldElement(new int[] { 1, 2, 3, 4 }, GF4);
            var mylt = element1 % element2;
            Assert.That(mylt.Poly, Is.EqualTo(new int[] { 1, -1 }));
        }
        [Test]
        public void DivideWithoutMod()
        {
            var GF4 = new FiniteField(2, 2, new int[] { 1, 1, 1 });
            var element1 = new FiniteFieldElement(new int[] { 1,2, 1 }, GF4);
            var element2 = new FiniteFieldElement(new int[] { 1,1}, GF4);
            var mylt = element1 % element2;
            Assert.That(mylt.Poly, Is.EqualTo(new int[] {0}));
        }
    }
}
