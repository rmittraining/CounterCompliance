/*
Copyright (c) 2014, RMIT Training
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this
  list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

* Neither the name of CounterCompliance nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;

#endregion

namespace Sushi.Client
{
    /// <summary>
    ///     Provides a composable version of the <see cref="TreeNode" /> class.
    /// </summary>
    /// <remarks>
    ///     This class is intended to improve the way TreeNode instances are built.
    ///     Like the <see cref="System.Xml.Linq.XElement" /> class, multiple hierarchical instances
    ///     of the <see cref="XTreeNode" /> class can be created in one constructor call.
    /// </remarks>
    /// <example>
    ///     The following example demonstrates how <see cref="XTreeNode" /> can be used to easily create
    ///     a new <see cref="TreeNode" /> instance.
    ///     <code>
    /// TreeNode node = new XTreeNode("Root Node", 
    ///    new XTreeNode("Sub Node"), 
    ///    new XTreeNode("Sub Node 2", 
    ///       new XTreeNode("Sub Node 2a")));
    /// 
    /// _treeView.Nodes.Add(node);
    /// </code>
    /// </example>
    public class XTreeNode
    {
        private readonly string _name;
        private readonly XTreeNode[] _children;

        /// <summary>
        ///     Initializes a new instance of the <see cref="XTreeNode" /> class.
        /// </summary>
        /// <param name="name">The name of the new <see cref="XTreeNode" /> instance.</param>
        public XTreeNode(string name)
        {
            _name = name;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="XTreeNode" /> class.
        /// </summary>
        /// <param name="name">The name of the new <see cref="XTreeNode" /> instance.</param>
        /// <param name="children">The child nodes of the new <see cref="XTreeNode" /> element.</param>
        public XTreeNode(string name, params XTreeNode[] children)
        {
            _name = name;
            _children = children;
        }

        /// <summary>
        ///     Builds a new <see cref="XTreeNode" /> instance by combining separate collections of child nodes.
        /// </summary>
        /// <param name="name">The name of the new <see cref="XTreeNode" /> instance.</param>
        /// <param name="children">The child nodes of the new <see cref="XTreeNode" /> element.</param>
        /// <returns>A new <see cref="XTreeNode" /> instance with the provided contents.</returns>
        public static XTreeNode BuildTreeNode(string name, params IEnumerable<XTreeNode>[] children)
        {
            var list = new List<XTreeNode>();

            if (children != null && children.Length > 0)
                Array.ForEach(children, list.AddRange);

            return new XTreeNode(name, list.ToArray());
        }

        /// <summary>
        ///     Implicitly converts an instance of the <see cref="XTreeNode" /> class into an
        ///     instance of the <see cref="TreeNode" /> class. Allows for seamless usage of
        ///     the <see cref="XTreeNode" /> class in <see cref="TreeNode" /> initialization.
        /// </summary>
        /// <param name="node">The <see cref="XTreeNode" /> to convert.</param>
        /// <returns>A new <see cref="TreeNode" /> instance with the same contents as the provided <see cref="XTreeNode" />.</returns>
        public static implicit operator TreeNode(XTreeNode node)
        {
            var treeNode = new TreeNode(node._name);

            if (node._children != null && node._children.Length > 0)
            {
                foreach (var child in node._children)
                {
                    treeNode.Nodes.Add(child);
                }
            }

            return treeNode;
        }
    }
}