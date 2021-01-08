using System.Collections.Generic;
using Xunit;

namespace GenericCollections.Tests
{
    public class SortedListTests
    {
        [Fact]
        public void SortedList_IntKeysAddedDescending_IntKeysAreSortedAscending()
        {
            // Given
            SortedList<int, string> stringsSortedByInts = new SortedList<int, string>();

            // When
            stringsSortedByInts.Add(1, "one");
            stringsSortedByInts.Add(0, "zero");
            stringsSortedByInts.Add(-1, "minusOne");

            // Then
            Assert.Equal(0, stringsSortedByInts.IndexOfKey(-1));
            Assert.Equal(1, stringsSortedByInts.IndexOfKey(0));
            Assert.Equal(2, stringsSortedByInts.IndexOfKey(1));
        }
    }
}