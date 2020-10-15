using System.Collections.Generic;
using Xunit;

namespace GenericCollections.Tests
{
    public class HashSetTests
    {
        [Fact]
        public void Intersect_Sets()
        {
            var set1 = new HashSet<int>() { 1, 2, 3};
            var set2 = new HashSet<int>() { 2, 3, 4};

            set1.IntersectWith(set2);

            Assert.True(set1.SetEquals(new[] { 2, 3} ));
        }

        [Fact]
        public void Union_Sets()
        {
            var set1 = new HashSet<int>() { 1, 2, 3 };
            var set2 = new HashSet<int>() { 2, 3, 4 };

            set1.UnionWith(set2);

            Assert.True(set1.SetEquals(new[] { 1, 2, 3, 4 }));
        }

        [Fact]
        public void SymmetricExceptWith_Sets()
        {
            var set1 = new HashSet<int>() {1, 2, 3};
            var set2 = new HashSet<int>() {2, 3, 4};

            set1.SymmetricExceptWith(set2);    // Symmetric difference of set1 and set2

            Assert.True(set1.SetEquals(new[] {1, 4}));
        }

        [Fact]
        public void HashSet_AddingDuplicate_Rejection()
        {
            // Given
            var set1 = new HashSet<int>();
            
            // When
            // Then
            Assert.True(set1.Add(1));
            Assert.False(set1.Add(1));
        }
    }
}