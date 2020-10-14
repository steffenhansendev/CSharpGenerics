using Xunit;

namespace Generics.Tests
{
    public class CircularBufferTests
    {
        [Fact]
        public void New_Buffer_Is_Empty()
        {
            var buffer = new CircularBuffer<double>();
            Assert.True(buffer.IsEmpty);
        }

        [Fact]
        public void Three_Element_Buffer_Is_Full_After_Three_Writes()
        {
            var buffer = new CircularBuffer<double>(capacity: 3);
            buffer.Write(1);
            buffer.Write(1);
            buffer.Write(1);
            Assert.True(buffer.IsFull);
        }

        [Fact]
        public void First_In_First_Out_When_Not_Full()
        {
            var buffer = new CircularBuffer<string>(capacity: 3);
            var value1 = "1.1";
            var value2 = "2.0";

            buffer.Write(value1);
            buffer.Write(value2);

            Assert.Equal(value1, buffer.Read());
            Assert.Equal(value2, buffer.Read());
            Assert.True(buffer.IsEmpty);
        }

        [Fact]
        public void Overwrites_When_More_Than_Capacity()
        {
            var buffer = new CircularBuffer<double>(capacity: 3);
            var values = new[] { 1.0, 2.0, 3.0, 4.0, 5.0 };

            foreach (var value in values)
            {
                buffer.Write(value);
            }

            Assert.True(buffer.IsFull);
            Assert.Equal(values[2], buffer.Read());
            Assert.Equal(values[3], buffer.Read());
            Assert.Equal(values[4], buffer.Read());
            Assert.True(buffer.IsEmpty);
        }
    }
}