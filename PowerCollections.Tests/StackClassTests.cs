//******************************
// Written by Peter Golde
// Copyright (c) 2004-2007, Wintellect
//
// Use and restribution of this code is subject to the license agreement 
// contained in the file "License.txt" accompanying this file.
//******************************

using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerCollections;
using System.Linq;

namespace Wintellect.PowerCollections.Tests
{
    [TestClass]
    public class StackClassTests
    {
        [TestMethod]
        public void Capacity_should_return_correct_length()
        {
            int length = 10;
            StackClass<int> stack = new StackClass<int>(length);

            Assert.AreEqual(length, stack.Capacity);
        }

        [TestMethod]
        public void Push_should_check_correct_count_and_last_inserted_element()
        {
            int length = 10;
            StackClass<int> stack = new StackClass<int>(length);

            stack.Push(3);
            stack.Push(6);
            stack.Push(9);

            Assert.AreEqual(3, stack.Count); // Проверка ко размеру
            Assert.AreEqual(9, stack.Pop()); // Проверка, что элемент вставился вверх
        }
        [TestMethod]
        public void Pop_should_check_two_last_elements_and_correct_count()
        {
            int length = 10;
            StackClass<int> stack = new StackClass<int>(length);

            stack.Push(3);
            stack.Push(6);
            stack.Push(9);

            Assert.AreEqual(9,stack.Pop());
            Assert.AreEqual(6,stack.Pop());
            Assert.AreEqual(1,stack.Count);
        }
        [TestMethod]
        public void Top_should_check_last_inserted_element_and_correct_count()
        {
            int length = 10;
            StackClass<int> stack = new StackClass<int>(length);

            stack.Push(3);
            stack.Push(6);
            stack.Push(9);

            Assert.AreEqual(9, stack.Top());
            Assert.AreEqual(3, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(StackFullException))]
        public void Push_should_throw_StackFullException_if_stack_is_full()
        {
            int length = 3;
            StackClass<int> stack = new StackClass<int>(length);

            do
            {
                stack.Push(10);
            } while (stack.Capacity != stack.Count);

            stack.Push(10);
        }

        [TestMethod]
        [ExpectedException(typeof(StackEmptyException))]
        public void Pop_should_throw_StackEmptyException_if_stack_is_empty()
        {
            int length = 3;
            StackClass<int> stack = new StackClass<int>(length);

            stack.Pop();
        }
        [TestMethod]
        [ExpectedException(typeof(StackEmptyException))]
        public void Top_should_throw_StackEmptyException_if_stack_is_empty()
        {
            int length = 3;
            StackClass<int> stack = new StackClass<int>(length);

            stack.Top();
        }
        [TestMethod]
        public void IEnumerable_should_iterate_elements_in_stack_by_foreach()
        {
            int[] arr = new int[] { 3, 6, 9 };
            StackClass<int> stack = new StackClass<int>(arr.Length);
            foreach (int num in arr) stack.Push(num);
            var result = stack.ToArray();
            CollectionAssert.AreEqual(arr.Reverse().ToArray(), result);
        }
    }
}

