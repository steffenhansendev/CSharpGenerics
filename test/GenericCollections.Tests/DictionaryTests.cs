using System;
using System.Collections.Generic;
using Xunit;

namespace GenericCollections.Tests
{
    public class DictionaryTests
    {
        [Fact]
        public void Can_Use_Dictionary_As_Map()
        {
            var map = new Dictionary<int, string>();
            map.Add(1, "one");
            map.Add(2, "two");
            
            Assert.Equal("one", map[1]);
        }

        [Fact]
        public void Can_Search_Key_With_ContainsKey()
        {
            var map = new Dictionary<int, string>();
            map.Add(1, "one");
            map.Add(2, "two");

            Assert.True(map.ContainsKey(2));
        }

        [Fact]
        public void Can_Remove_By_Key()
        {
            var map = new Dictionary<int, string>();
            map.Add(1, "one");
            map.Add(2, "two");

            map.Remove(1);

            Assert.Single(map);
        }

        [Fact]
        public void Dictionary_AddingDuplicateKey_ThrowsException()
        {
            // Given
            Dictionary<int, string> stringsByInt = new Dictionary<int, string>();
            stringsByInt.Add(1, "one");
            
            // When
            // Then
            Assert.Throws<ArgumentException>(() => stringsByInt.Add(1, "Does not matter"));
        }
    }
}