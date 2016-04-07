using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        Node<T> root;
        public void Insert(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            var node = new Node<T>(value);
            if (root == null)
                this.root = node;
            else
            {
                Node<T> current = root, parent = null;
                while (current != null)
                {
                    parent = current;
                    if (value.CompareTo(current.Value) < 0) current = current.Left;
                    else current = current.Right;
                }
                if (value.CompareTo(parent.Value) < 0) parent.Left = node;
                else parent.Right = node;
            }
        }
        public void Insert(T value, IComparer<T> comparer)
        {
            if (value == null)
                throw new ArgumentNullException();
            if (comparer == null)
                comparer = Comparer<T>.Default;
            var node = new Node<T>(value);
            if (root == null)
                this.root = node;
            else {
                Node<T> current = root, parent = null;
                while (current != null)
                {
                    parent = current;
                    if (comparer.Compare(value,current.Value) < 0) current = current.Left;
                    else current = current.Right;
                }
                if (comparer.Compare(value, parent.Value) < 0) parent.Left = node;
                else parent.Right = node;
            }
        }
        public T Search(T key)
        {
            if (key == null)
                throw new ArgumentNullException();
            if (key.CompareTo(root.Value) == 0)
                return this.root.Value;
            else
            {
                var current = root;
                while (current != null)
                {
                    var result = key.CompareTo(current.Value);
                    if (result == 0) return current.Value;
                    if (result < 0) current = current.Left;
                    else current = current.Right;
                }
                return default(T);
            }
        }
        public T Search(T key, IComparer<T> comparer)
        {
            if (key == null)
                throw new ArgumentNullException();
            if (comparer == null)
                comparer = Comparer<T>.Default; 
            if (comparer.Compare(key,root.Value) == 0)
                return this.root.Value;
            else
            {
                var current = root;
                while (current != null)
                {
                    var result = comparer.Compare(key,root.Value);
                    if (result == 0) return current.Value;
                    if (result < 0) current = current.Left;
                    else current = current.Right;
                }
                return default(T);
            }
        }
        public IEnumerable<T> Inorder()
        {
            if (root == null)
                yield break;
            var stack = new Stack<Node<T>>();
            Node<T> node = root;
            while(node != null || stack.Count>0)
            {
                if(node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
            }
        }
        public IEnumerable<T> Preorder()
        {
            if (root == null) yield break;

            var stack = new Stack<Node<T>>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.Value;
                if (node.Right != null) stack.Push(node.Right);
                if (node.Left != null) stack.Push(node.Left);
            }
        }
        public IEnumerable<T> Postorder()
        {
            if (root == null) yield break;

            var stack = new Stack<Node<T>>();
            var node = root;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    if (stack.Count > 0 && node.Right == stack.Peek())
                    {
                        stack.Pop();
                        stack.Push(node);
                        node = node.Right;
                    }
                    else { yield return node.Value; node = null; }
                }
                else {
                    if (node.Right != null) stack.Push(node.Right);
                    stack.Push(node);
                    node = node.Left;
                }
            }
        }
        public void Clear()
        {
            root = null;
        }
        public bool IsEmpty() => root == null;
    }
}
