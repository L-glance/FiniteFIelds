using FF;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFTest
{
    public class SubtractionTest
    {
        [Test]
        public void Subtraction()
        {
            var GF4 = new FiniteField(2,2, new int[] { 1, 1, 1 });
            var element1 = new FiniteFieldElement(new int[] { 1, 1 }, GF4);
            var element2 = new FiniteFieldElement(new int[] { 0, 1 }, GF4);
            var subtract = element1 + element2;
            Assert.That(subtract.Poly, Is.EqualTo(new int[] { 1, 0 }));
        }
        [Test]
        public void Subtraction2()
        {
            var GF9 = new FiniteField(3, 2, new int[] { 1, 1, 2 });
            var element1 = new FiniteFieldElement(new int[] {1,2}, GF9);
            var element2 = new FiniteFieldElement(new int[] {2,0}, GF9);
            var subtract = element1 - element2;
            Assert.That(subtract.Poly, Is.EqualTo(new int[] {2,2}));
        }
        [Test]
        public void SubtractionOverPrimeField1()
        {
            var GF3 = new FiniteField(3);
            var element1 = new FiniteFieldElement(2, GF3);
            var element2 = new FiniteFieldElement(1, GF3);
            var subtract = element1 - element2;
            Assert.That(subtract.element,Is.EqualTo(1));
        }
        [Test]
        public void SubtractionOverPrimeField2()
        {
            var GF3 = new FiniteField(3);
            var element1 = new FiniteFieldElement(1, GF3);
            var element2 = new FiniteFieldElement(2, GF3);
            var subtract = element1 - element2;
            Assert.That(subtract.element, Is.EqualTo(2));
        }
    }
}
