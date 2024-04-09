using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportbeltRender;

namespace TransportbeltRender.Tests
{
    [TestFixture]
    public class RenderTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        [TestCase(1,1)]
        [TestCase(100,100)]
        [TestCase(1000,1000)]
        public void ConstructorSuccessTests(int width, int height)
        {
            TransportImage ti = null;

            Assert.DoesNotThrow(() => ti = new TransportImage(width, height));
            Assert.DoesNotThrow(() => _ = new TransportImage(width, height, new()));
            Assert.DoesNotThrow(() => _ = new TransportImage(width, height, new(), new()));

            Assert.That(ti, Is.Not.Null);
            Assert.That(ti.ImageWidth, Is.EqualTo(width));
            Assert.That(ti.ImageHeight, Is.EqualTo(height));
            Assert.That(ti.renderResult, Is.Null);
            Assert.That(ti.Properties, Is.Not.Null);
            Assert.That(ti.Elements, Is.Not.Null);

            Assert.DoesNotThrow(() => ti.Dispose());
        }

        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(0, -5)]
        [TestCase(-5, 1)]
        public void ConstructorFailureTests(int width, int height)
        {
            Assert.Throws<ArgumentException>(() => _ = new TransportImage(width, height));
            Assert.Throws<ArgumentException>(() => _ = new TransportImage(width, height, new()));
            Assert.Throws<ArgumentException>(() => _ = new TransportImage(width, height, new(), new()));
        }

        [Test]
        [TestCase(50, 50)]
        [TestCase(50, 1000)]
        [TestCase(1000, 49)]
        public void RenderSuccessTests(int width, int height)
        {
            using (TransportImage ti = new(width, height))
            {
                Assert.DoesNotThrowAsync(ti.Render);

                Assert.That(ti.renderResult, Is.Not.Null);
                Assert.That(ti.renderResult.Width, Is.EqualTo(width));
                Assert.That(ti.renderResult.Height, Is.EqualTo(height));

                using (MemoryStream ms = new())
                {
                    Assert.DoesNotThrowAsync(async () => await ti.SaveToStream(ms));
                    Assert.That(ms.Length, Is.Not.Default);

                    byte[] bytes = ms.ToArray();
                    string encoded = Encoding.ASCII.GetString(bytes);

                    Assert.That(encoded.ToLower().Contains("png"), Is.True);
                }
            }
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
