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
        public void Divide1()
        {
            var GF4 = new FiniteField(2, 2, new int[] { 1, 1, 1 });
            var element1 = new FiniteFieldElement(new int[] { 1, 1 }, GF4);
            var element2 = new FiniteFieldElement(new int[] { 1, 0 }, GF4);
            var div = element1 / element2;
            Assert.That(div.Poly, Is.EqualTo(new int[] { 1, 0 }));
        }
    }
}
