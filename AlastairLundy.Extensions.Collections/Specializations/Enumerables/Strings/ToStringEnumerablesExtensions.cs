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

using System;
using System.Collections.Generic;

namespace AlastairLundy.Extensions.Collections.Specializations.Strings;

    public static class ToStringEnumerablesExtensions
    {
        /// <summary>
        /// Converts an IEnumerable of objects to an IEnumerable of strings. 
        /// </summary>
        /// <param name="source">The IEnumerable to be converted.</param>
        /// <typeparam name="T">The type of objects stored.</typeparam>
        /// <returns>The IEnumerable of strings.</returns>
        /// <exception cref="ArgumentException">Thrown if the object of type T doesn't implement a ToString method.</exception>
        public static IEnumerable<string> ToStringEnumerable<T>(this IEnumerable<T> source)
        {
            if (typeof(T).GetMethod("ToString")?.DeclaringType != typeof(object) && typeof(T) != typeof(object))
            {
                List<string> list = new List<string>();
                
                foreach (T item in source)
                {
                    if (item?.GetType() != typeof(object))
                    {
                        list.Add(item?.ToString()!);
                    }
                }

                return list.ToArray();
            }
            // ReSharper disable once RedundantIfElseBlock
            else
            {
                throw new ArgumentException();
            }
        }
    }