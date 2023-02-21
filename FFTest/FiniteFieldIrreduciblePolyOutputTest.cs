using FF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FFTest
{
    public class FiniteFieldIrreduciblePolyOutputTest
    {
        [Test]
        public void PolyDegreeMoreOne()
        {
            FiniteField field = new FiniteField(2,new int[] {2,1,1},2);
            var irreduciblePoly = field.GetIrreduciblePoly();
            Assert.That(irreduciblePoly,Is.EqualTo("2x^2+x+1"));
        }

        [Test]
        public void PolyDegreeOne()
        {
            FiniteField field = new FiniteField(3, new int[] {5,0}, 2);
            var irreduciblePoly = field.GetIrreduciblePoly();
            Assert.That(irreduciblePoly, Is.EqualTo("5x"));
        }
        [Test]
        public void PolyDegreeZeroOne()
        {
            FiniteField field = new FiniteField(3, new int[] {1}, 2);
            var irreduciblePoly = field.GetIrreduciblePoly();
            Assert.That(irreduciblePoly, Is.EqualTo("1"));
        }
        [Test]
        public void PolyDegreeZeroMoreOne()
        {
            FiniteField field = new FiniteField(3, new int[] { 4 }, 2);
            var irreduciblePoly = field.GetIrreduciblePoly();
            Assert.That(irreduciblePoly, Is.EqualTo("4"));
        }

    }
}
