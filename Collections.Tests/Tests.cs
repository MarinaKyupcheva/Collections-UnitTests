using NUnit.Framework;
using System;
using System.Linq;

namespace Collections.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            var nums = new Collection<int>();

            Assert.That(nums.ToString, Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_WithSingleItem()
        {
            var nums = new Collection<int>(1);

            Assert.That(nums.ToString(), Is.EqualTo("[1]"));
        }

        [Test]
        public void Test_Collection_WithMultipleitems()
        {
            var nums = new Collection<int>(1, 2, 3);

            Assert.That(nums.ToString(), Is.EqualTo("[1, 2, 3]"));
        }

        [Test]
        public void Test_Collection_Add()
        {
            var nums = new Collection<int>();

            nums.Add(1);
            nums.Add(15);

            Assert.That(nums.ToString(), Is.EqualTo("[1, 15]"));
        }

        [Test]
        public void Test_Collection_AddCount()
        {
            var nums = new Collection<int>();

            nums.Add(1);
            nums.Add(15);

            Assert.That(nums.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();

            nums.AddRange(newNums);

            string expectedNums = "[" + string.Join(", ", newNums) + "]";

            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
        }

        [Test]
        public void Test_Collection_AddRangeCount()
        {
            var nums = new Collection<int>();

            nums.AddRange(1, 5);

            Assert.That(nums.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_Collection_AddWithGrow()
        {
            var nums = new Collection<int>();

            nums.Add(1);
            string expectedNums = "[" + string.Join(", ", "1") + "]";

            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            
        }

        [Test]
        public void Test_Collection_Clear()
        {
            var nums = new Collection<int>();

            nums.Add(1);
            nums.Clear();
            string expectedNums = "[]";
            
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));

        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            var names = new Collection<string>("Ivan", "Georgi");

            string firstName = names[0];
      
            Assert.That(firstName, Is.EqualTo("Ivan"));

        }

        [Test]
        public void Test_Collection_ByInvalidIndex()
        {
            var names = new Collection<string>("Ivan", "Georgi");

           Assert.That(() => { string name = names[2]; }, Throws.Exception);
           Assert.That(() => names[-2], Throws.Exception);
          
        }

        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            var names = new Collection<string>("Ivan", "Georgi");
            var dates = new Collection<DateTime>();
            var numbers = new Collection<int>(1, 2);

            var nestedArr = new Collection<object>(names, dates, numbers);
            string nestedToString = nestedArr.ToString();

            Assert.That(nestedToString, Is.EqualTo("[[Ivan, Georgi], [], [1, 2]]"));

        }

        [Test]
        public void Test_Collection_ExchangeFirstAndLast()
        {
            var numbers = new Collection<int>(1, 2, 3);

            var firstNumber = numbers[0];
            var lastNumber = numbers[2];

            numbers.Exchange(firstNumber, lastNumber);
            string expectedNums = "[3, 2, 1]";

            Assert.That(numbers.ToString(), Is.EqualTo(expectedNums));
          
        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            var numbers = new Collection<int>(1, 2, 3);

            numbers.InsertAt(3, 4);

            Assert.That(numbers.ToString(), Is.EqualTo("[1, 2, 3, 4]"));

        }

        [Test]
        public void Test_Collection_InsertInvalidIndex()
        {
            var numbers = new Collection<int>(1, 2, 3);

            Assert.Throws<ArgumentOutOfRangeException>(() =>{numbers.InsertAt(-2, 4);});

        }

        [Test]
        public void Test_Collection_InsertAtMiddle()
        {
            var numbers = new Collection<int>(1, 2, 3);

            numbers.InsertAt(1, 100);
            Assert.That(numbers.ToString(), Is.EqualTo("[1, 100, 2, 3]"));

        }

        [Test]
        public void Test_Collection_InsertAtStart()
        {
            var numbers = new Collection<int>(1, 2, 3);

            numbers.InsertAt(0, 100);
            Assert.That(numbers.ToString(), Is.EqualTo("[100, 1, 2, 3]"));

        }

        [Test]
        public void Test_Collection_Remove_AtEnd()
        {
            var numbers = new Collection<int>(1, 2, 3);

            numbers.RemoveAt(2);
            Assert.That(numbers.ToString(), Is.EqualTo("[1, 2]"));

        }

        [Test]
        public void Test_Collection_Remove_AtInvalidIndex()
        {
            var numbers = new Collection<int>(1, 2, 3);

            Assert.Throws<ArgumentOutOfRangeException>(() => numbers.RemoveAt(-2));

        }

        
    }
}