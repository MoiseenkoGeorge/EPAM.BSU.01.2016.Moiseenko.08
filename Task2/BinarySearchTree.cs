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

        public void Insert(T value, IComparer<T> comparer = null)
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
                    if (value.CompareTo(current.Value) < 0) current = current.Left;
                    else current = current.Right;
                }
                if (value.CompareTo(parent.Value) < 0) parent.Left = node;
                else parent.Right = node;
            }
        }
        public T Search(T key)
        {
            if (key.CompareTo(root.Value) == 0)
                return this.root.Value;
            else
            {
                if (key.CompareTo(root.Value) > 0)
                    if (root.Right != null)
                        return root.Right.Search(key);
                    else
                        throw new ArgumentException("Node wasn't find");
                else
                {
                    if (root.Left != null)
                        return root.Left.Search(key);
                    else
                        throw new ArgumentException("Node wasn't find");
                }
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
        public bool IsEmpty()
        {
            if (root == null)
                return true;
            return false;
        }
    }
}
