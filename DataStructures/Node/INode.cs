using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Node
{
    internal interface INode<T>
    {
        T? GetNextNode();
        void SetNextNode(T? node);
        T? GetPrevNode();
        void SetPrevNode(T? node);
    }

}
