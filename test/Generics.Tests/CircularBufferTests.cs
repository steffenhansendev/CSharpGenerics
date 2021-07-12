using Xunit;

namespace Generics.Tests
{
    public class CircularBufferTests
    {
        [Fact]
        public void New_Buffer_Is_Empty()
        {
            var buffer = new CircularBufferByArray<double>();
            Assert.True(buffer.IsEmpty);
        }

        [Fact]
        public void Three_Element_Buffer_Is_Full_After_Three_Writes()
        {
            var buffer = new CircularBufferByArray<double>(capacity: 3);
            buffer.Write(1);
            buffer.Write(1);
            buffer.Write(1);
            Assert.True(buffer.IsFull);
        }

        [Fact]
        public void First_In_First_Out_When_Not_Full()
        {
            var buffer = new CircularBufferByArray<string>(capacity: 3);
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
            var buffer = new CircularBufferByArray<double>(capacity: 4);
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

        // => The compiler will check how the CircularBuffer has been parameterized when it is passed around
        [Fact]
        public void GenericCircularBuffer_Comparisons_Truthful()
        {
            // Given
            CircularBufferByArray<long> circularLongBuffer1 = new CircularBufferByArray<long>();
            CircularBufferByArray<long> circularLongBuffer2 = new CircularBufferByArray<long>();
            CircularBufferByArray<object> circularObjectBuffer = new CircularBufferByArray<object>();    // Will cause boxing
            CircularBufferByArray<string> circularStringBuffer = new CircularBufferByArray<string>();
            CircularStringBuffer nonGenericCircularStringBuffer = new CircularStringBuffer();
            
            // When
            // Then
            Assert.False(circularLongBuffer1.Equals(circularLongBuffer2));
            Assert.True(circularLongBuffer1.GetType() == circularLongBuffer2.GetType());
            Assert.False(circularLongBuffer1.GetType() == circularObjectBuffer.GetType());
            Assert.False(circularLongBuffer1.GetType() == circularStringBuffer.GetType());
            Assert.False(circularStringBuffer.GetType() == nonGenericCircularStringBuffer.GetType());
        }
    }
}