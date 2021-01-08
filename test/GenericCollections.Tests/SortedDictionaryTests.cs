using System;
using System.Collections.Generic;
using Xunit;

namespace GenericCollections.Tests
{
    public class SortedDictionaryTests
    {
        [Fact]
        public void SortedDictionary_IntKeysAddedDescending_IntKeysAreSortedAscending()
        {
            // Given
            SortedDictionary<int, string> stringsSortedByInts = new SortedDictionary<int, string>();

            // When
            stringsSortedByInts.Add(1, "one");
            stringsSortedByInts.Add(0, "zero");
            stringsSortedByInts.Add(-1, "minusOne");
            int previousKey = Int32.MinValue;

            // Then
            foreach (KeyValuePair<int, string> stringSortedByInt in stringsSortedByInts)
            {
                Assert.True(previousKey < stringSortedByInt.Key);
                previousKey = stringSortedByInt.Key;
            }
        }
    }
}