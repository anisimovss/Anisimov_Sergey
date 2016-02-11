using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;
using System.Collections.Generic;

namespace MyDynamicArrayTests
{
    [TestClass]
    public class MyDynamicArrayMethodTest
    {
        [TestMethod]
        public void AddTest()
        {
            MyDynamicArray<int> a = new MyDynamicArray<int>();
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Add(4);
            a.Add(5);
            a.Add(6);
            a.Add(7);
            a.Add(8);
            int i = 1;
            foreach (int elem in a)
            {
                Assert.AreEqual(i, elem);
                i++;
            }
            Assert.AreEqual(8, a.Capacity);
            Assert.AreEqual(a.Length, a.Capacity);
            a.Add(9);
            a.Add(10);
            Assert.AreEqual(9, a[8]);
            Assert.AreEqual(10, a[9]);
            Assert.AreNotEqual(8, a.Capacity);
            Assert.AreNotEqual(a.Length, a.Capacity);
        }

        [TestMethod]
        public void AddRangeTest()
        {
            MyDynamicArray<int> a = new MyDynamicArray<int>();
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Add(4);
            a.Add(5);
            a.Add(6);
            a.Add(7);
            a.Add(8);
            a.Add(9);
            a.Add(10);
            List<int> b = new List<int>();
            b.Add(11);
            b.Add(12);
            b.Add(13);
            b.Add(14);
            b.Add(15);
            b.Add(16);
            a.AddRange(b);
            int i = 1;
            foreach (int elem in a)
            {
                Assert.AreEqual(i, elem);
                i++;
            }
        }

        [TestMethod]
        public void RemoveTest()
        {
            MyDynamicArray<int> a = new MyDynamicArray<int>();
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Add(4);
            a.Add(5);
            a.Add(6);
            a.Add(7);
            a.Add(8);
            a.Add(9);
            a.Add(10);
            int start = a.Length;
            Assert.AreEqual(true, a.Remove(7));
            Assert.AreNotEqual(start, a.Length);
            Assert.AreEqual(6, a[5]);
            Assert.AreEqual(8, a[6]);
            Assert.AreEqual(9, a[7]);
            Assert.AreEqual(10, a[8]);
            Assert.AreEqual(default(int), a[9]);
            Assert.AreEqual(false, a.Remove(7));
        }

        [TestMethod]
        public void InsertTest()
        {
            MyDynamicArray<int> a = new MyDynamicArray<int>();
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Add(4);
            a.Add(5);
            a.Add(6);
            a.Add(7);
            int startCapacity = a.Capacity;
            int startLength = a.Length;
            a.Insert(11, 4);
            int i = 1;
            Assert.AreEqual(1, a[0]);
            Assert.AreEqual(2, a[1]);
            Assert.AreEqual(3, a[2]);
            Assert.AreEqual(4, a[3]);
            Assert.AreEqual(11, a[4]);
            Assert.AreEqual(5, a[5]);
            Assert.AreEqual(6, a[6]);
            Assert.AreEqual(7, a[7]);
            a.Insert(15, 1);
            Assert.AreEqual(15, a[1]);
            Assert.AreNotEqual(startCapacity, a.Capacity);
            Assert.AreNotEqual(startLength, a.Length);
        }
    }
}
