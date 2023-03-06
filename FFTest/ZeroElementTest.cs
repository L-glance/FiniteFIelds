using FF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFTest
{
    public class ZeroElementTest
    {
        [Test]
        public void Adding()
        {
            var GF4 = new FiniteField(2, new int[] { 1, 1, 1 }, 2);
            var element1 = new FiniteFieldElement(new int[] { 1, 1 }, GF4);
            var zero = GF4.GetZero();
            var element2 = element1 + zero;
            Assert.That(element1.field.characteristic, Is.EqualTo(element2.field.characteristic));
        }
    }
}
