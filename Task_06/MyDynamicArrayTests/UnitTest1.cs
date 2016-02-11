using System;
using Task3;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyDynamicArrayTests
{
    [TestClass]
    public class MyDynamicArrayTest
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            MyDynamicArray<int> a = new MyDynamicArray<int>();
            Assert.AreEqual(8, a.Capacity);
            Assert.AreEqual(0, a.Length);
        }

        [TestMethod]
        public void ConstructorWithParametersTest()
        {
            MyDynamicArray<int> a = new MyDynamicArray<int>(15);
            MyDynamicArray<string> b = new MyDynamicArray<string>(30);
            Assert.AreEqual(15, a.Capacity);
            Assert.AreEqual(0, a.Length);
            Assert.AreEqual(30, b.Capacity);
            Assert.AreEqual(0, b.Length);
        }

        [TestMethod]
        public void ConstructorWithCollectionTest()
        {
            List<int> col = new List<int>();
            col.Add(2);
            col.Add(4);
            col.Add(6);
            col.Add(8);
            MyDynamicArray<int> arr = new MyDynamicArray<int>(col);
            Assert.AreEqual(4, arr.Capacity);
            Assert.AreEqual(4, arr.Length);
            Assert.AreEqual(arr.Length, arr.Capacity);
            Assert.AreEqual(2, arr[0]);
            Assert.AreEqual(4, arr[1]);
            Assert.AreEqual(6, arr[2]);
            Assert.AreEqual(8, arr[3]);
        }

    }
}
