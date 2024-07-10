﻿/*
        MIT License
       
       Copyright (c) 2024 Alastair Lundy
       
       Permission is hereby granted, free of charge, to any person obtaining a copy
       of this software and associated documentation files (the "Software"), to deal
       in the Software without restriction, including without limitation the rights
       to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
       copies of the Software, and to permit persons to whom the Software is
       furnished to do so, subject to the following conditions:
       
       The above copyright notice and this permission notice shall be included in all
       copies or substantial portions of the Software.
       
       THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
       IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
       FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
       AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
       LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
       OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
       SOFTWARE.
   */

namespace AlastairLundy.Extensions.Collections;

public static class RemoveExtensions
{
    /// <summary>
    /// Removes an item from an IEnumerable (by creating a new IEnumerable without the removed item).
    /// </summary>
    /// <param name="enumerable">The IEnumerable to have an item removed from it.</param>
    /// <param name="itemToBeRemoved">The item to be removed.</param>
    /// <typeparam name="T">The type of object stored in the IEnumerable.</typeparam>
    /// <returns>the new IEnumerable with the removed item.</returns>
    public static IEnumerable<T> Remove<T>(this IEnumerable<T> enumerable, T itemToBeRemoved)
    {
        return Remove(enumerable, [itemToBeRemoved]);
    }
    
    /// <summary>
    /// Removes items from an IEnumerable (by creating a new IEnumerable without the removed items).
    /// </summary>
    /// <param name="enumerable">The IEnumerable to have items removed from.</param>
    /// <param name="itemsToBeRemoved">The items to be removed.</param>
    /// <typeparam name="T">The type of object stored in the IEnumerable.</typeparam>
    /// <returns>the new IEnumerable with the removed items.</returns>
    public static IEnumerable<T> Remove<T>(this IEnumerable<T> enumerable, IEnumerable<T> itemsToBeRemoved)
    {
        T[] itemsToBeRemovedArr = itemsToBeRemoved as T[] ?? itemsToBeRemoved.ToArray();
        T[] oldItems = enumerable as T[] ?? enumerable.ToArray();

        List<T> newItems = new List<T>();

        foreach (T item in oldItems)
        {
            if (!itemsToBeRemovedArr.Contains(item))
            {
                newItems.Add(item);
            }
        }
        
        return newItems.ToArray();
    }
}