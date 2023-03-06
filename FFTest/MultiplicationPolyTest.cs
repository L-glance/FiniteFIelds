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
        public void Multiplication()
        {
            var GF4 = new FiniteField(2,2, new int[] { 1, 1, 1 } );
            var element1 = new FiniteFieldElement(new int[] { 1, 0, 1 }, GF4);
            var element2 = new FiniteFieldElement(new int[] { 1, 3 }, GF4);
            var mult = element1 * element2;
            Assert.That(mult.Poly, Is.EqualTo(new int[] { 1, 3,1,3 }));
        }
    }
}
