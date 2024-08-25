/*
 * MIT License
 * 
 * Copyright (c) 2024 plexdata.de
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace Plexdata.Utilities.Exceptions.Tests.Extensions.Helpers
{
    public class CustomData : IComparable<CustomData>, IEquatable<CustomData>
    {
        private Boolean value;

        public CustomData(Boolean value)
        {
            this.value = value;
        }

        public Boolean Value { get { return this.value; } }

        public Int32 CompareTo(CustomData other)
        {
            if (other == null)
            {
                return 1;
            }

            if (this.value && other.value)
            {
                return 0;
            }

            if (this.value)
            {
                return 1;
            }

            return -1;
        }

        public Boolean Equals(CustomData other)
        {
            if (other == null)
            {
                return false;
            }

            return this.value == other.value;
        }
    }
}
