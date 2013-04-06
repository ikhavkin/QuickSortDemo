using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace QuickSortDemo
{
    [TestFixture(typeof (SystemSorter<int>))]
    public class SorterTest<TSorter>
        where TSorter : ISorter<int>, new()
    {
        TSorter sorter;

        [SetUp]
        public void SetUp()
        {
            sorter = new TSorter();
        }

        [Test]
        public void When_sorting_empty_list_it_should_not_throw()
        {
            // Arrange.
            var emptyCollection = new List<int>();

            // Act.
            sorter.Sort(emptyCollection);

            // Assert.
            emptyCollection.Should().BeEmpty();
        }

        [Test]
        public void When_sorting_1_element_list_it_should_stay_intact()
        {
            // Arrange.
            var oneElementList = new List<int> { 123 };

            // Act.
            sorter.Sort(oneElementList);

            // Assert.
            oneElementList.Should().Equal(123);
        }

        [Test]
        public void When_sorting_2_element_sorted_list_it_should_stay_intact()
        {
            // Arrange.
            var oneElementList = new List<int> { 1, 2 };

            // Act.
            sorter.Sort(oneElementList);

            // Assert.
            oneElementList.Should().Equal(1, 2);
        }

        [Test]
        public void When_sorting_list_with_2_same_values_it_should_stay_intact()
        {
            // Arrange.
            var oneElementList = new List<int> { 1, 1 };

            // Act.
            sorter.Sort(oneElementList);

            // Assert.
            oneElementList.Should().Equal(1, 1);
        }

        [Test]
        public void When_sorting_2_element_reversely_sorted_list_it_should_swap_elements()
        {
            // Arrange.
            var oneElementList = new List<int> { 2, 1 };

            // Act.
            sorter.Sort(oneElementList);

            // Assert.
            oneElementList.Should().Equal(1, 2);
        }

        [TestCase(new[] {1, 2, 3})]
        [TestCase(new[] {3, 2, 1})]
        [TestCase(new[] {2, 1, 3})]
        [TestCase(new[] {1, 1, 1})]
        [TestCase(new[] {int.MaxValue, int.MaxValue, int.MaxValue})]
        [TestCase(new[] {int.MinValue, int.MinValue, int.MinValue})]
        [TestCase(new[] {int.MaxValue, int.MinValue, int.MinValue})]
        public void Data_driven_test(int[] values)
        {
            // Arrange.
            var sorted = values.OrderBy(_ => _).ToList();

            // Act.
            sorter.Sort(values);

            // Assert.
            values.Should().Equal(sorted);
        }

        [Test]
        public void Combinatorics_test(
            [Values(int.MinValue, int.MaxValue, -10, 10)] int value1,
            [Values(int.MinValue, int.MaxValue, -10, 10)] int value2,
            [Values(int.MinValue, int.MaxValue, -10, 10)] int value3,
            [Values(int.MinValue, int.MaxValue, -10, 10)] int value4)
        {
            // Arrange.
            var values = new[] { value1, value2, value3, value4 };
            var sorted = values.OrderBy(_ => _).ToList();

            // Act.
            sorter.Sort(values);

            // Assert.
            values.Should().Equal(sorted);
        }
    }
}
