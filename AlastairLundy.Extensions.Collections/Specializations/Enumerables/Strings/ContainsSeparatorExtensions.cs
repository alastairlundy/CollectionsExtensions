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

using System.Collections.Generic;
using System.Linq;

namespace AlastairLundy.Extensions.Collections.Specializations.Strings;

public static class ContainsSeparatorExtensions
{
    /// <summary>
    /// Check to see if an IEnumerable contains a separator character.
    /// </summary>
    /// <param name="args">The IEnumerable to be searched.</param>
    /// <param name="separator">The separator to look for.</param>
    /// <returns>true if the separator character is found in the IEnumerable; returns false otherwise.</returns>
    public static bool ContainsSeparator(IEnumerable<string> args, char separator)
    {
        return ContainsSeparator(args, separator.ToString());
    }
    
    /// <summary>
    /// Check to see if an IEnumerable contains a separator character string.
    /// </summary>
    /// <param name="args">The IEnumerable to be searched.</param>
    /// <param name="separator">The separator to look for.</param>
    /// <returns>true if the separator character string is found in the IEnumerable; returns false otherwise.</returns>
    public static bool ContainsSeparator(this IEnumerable<string> args, string separator)
    {
        bool output = false;

        string[] enumerable = args as string[] ?? args.ToArray();
        
        output = enumerable.Any(arg => arg.Contains(separator));

        if (enumerable.Any(arg => arg.Split(' ').Length > 0))
        {
            foreach (string arg in enumerable.Where(arg => arg.Split(' ').Length > 0))
            {
                if (arg.Split(' ').Length > 0)
                {
                    foreach (string s in arg.Split(' '))
                    {
                        if (s.Equals(separator))
                        {
                            output = true;
                        }
                    }
                }
            }
        }
        
        return output;
    }
}