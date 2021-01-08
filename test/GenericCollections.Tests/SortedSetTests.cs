using System.Collections.Generic;
using Xunit;

namespace GenericCollections.Tests
{
    public class SortedSetTests
    {
        [Fact]
        public void SortedSet_IntElementsAddedDescending_IntElementsEnumeratedAscending()
        {
            // Given
            SortedSet<int> sortedSetOfInts = new SortedSet<int>();
            
            // When
            sortedSetOfInts.Add(1);
            sortedSetOfInts.Add(0);
            sortedSetOfInts.Add(-1);

            // Then
            SortedSet<int>.Enumerator enumerator = sortedSetOfInts.GetEnumerator();
            enumerator.MoveNext();
            Assert.Equal(-1, enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(0, enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(1, enumerator.Current);
        }
    }
}