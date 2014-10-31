﻿/*
The MIT License (MIT)

Copyright (c) 2013 Maksim Volkau

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;

namespace DryIoc.CommonServiceLocator
{
    /// <summary>
    /// Implementation of CommonServiceLocator for DryIoc container, 
    /// see rationale at https://commonservicelocator.codeplex.com/
    /// </summary>
    public class DryIocServiceLocator : ServiceLocatorImplBase
    {
        /// <summary>Exposes underlying Container for direct operation.</summary>
        public readonly Container Container;

        /// <summary>Creates new locator as adapter for provided container.</summary>
        /// <param name="container">Container to use/adapt.</param>
        public DryIocServiceLocator(Container container)
        {
            if (container == null) throw new ArgumentNullException("container");
            Container = container;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (serviceType == null) throw new ArgumentNullException("serviceType");
            return Container.Resolve(serviceType, key);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            if (serviceType == null) throw new ArgumentNullException("serviceType");
            return Container.ResolveMany<object>(serviceType);
        }
    }
}