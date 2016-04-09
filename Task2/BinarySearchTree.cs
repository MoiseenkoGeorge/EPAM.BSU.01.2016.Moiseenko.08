using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class BinarySearchTree<T> 
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
                    if (comparer.Compare(value,current.Value) < 0) current = current.Left;
                    else current = current.Right;
                }
                if (comparer.Compare(value, parent.Value) < 0) parent.Left = node;
                else parent.Right = node;
            }
        }
        
        public T Search(T key, IComparer<T> comparer = null)
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
        public IEnumerable<T> Inorder(Node<T> root = null)
        {
            if (root == null)
                if (this.root == null)
                    yield break;
                else root = this.root;
            if (root.Left != null)
                foreach (var item in Inorder(root.Left))
                    yield return item;
            yield return root.Value;
            if (root.Right == null) yield break;
            foreach (var item in Inorder(root.Right))
                    yield return item;
        }
        public IEnumerable<T> Preorder(Node<T> root = null)
        {
            if (root == null)
                if (this.root == null)
                    yield break;
                else root = this.root;
            yield return root.Value;
            if (root.Left != null)
                foreach (var item in Preorder(root.Left))
                    yield return item;
            if (root.Right == null) yield break;
            foreach (var item in Preorder(root.Right))
                yield return item;
        }
        public IEnumerable<T> Postorder(Node<T> root = null)
        {
            if (root == null)
                if (this.root == null)
                    yield break;
                else root = this.root;
            if (root.Left != null)
                foreach (var item in Postorder(root.Left))
                    yield return item;
            if (root.Right == null) yield break;
            foreach (var item in Postorder(root.Right))
                yield return item;
            yield return root.Value;
        }
        public void Clear()
        {
            root = null;
        }
        public bool IsEmpty() => root == null;
    }
}
