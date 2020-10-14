using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GenericCollections.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void A_List_Can_Insert_In_Order()
        {
            List<int> integers = new List<int> { 1, 2, 3 };
            integers.Insert(1, 6);
            
            Assert.Equal(6, integers[1]);
        }

        [Fact]
        public void A_List_Can_Remove_The_First_Occurence()
        {
            List<int> integers = new List<int> { 1, 2, 2, 3 };
            integers.Remove(2);

            Assert.True(integers.SequenceEqual(new [] { 1, 2, 3 }));
        }

        [Fact]
        public void A_List_Can_Find_The_First_Occurence()
        {
            List<int> integers = new List<int> { 1, 2, 3, 4, 3 };

            Assert.Equal(2, integers.IndexOf(3));
        }
    }
}
