using System;
using System.Collections.Generic;
using Util.DataTypes;

namespace NodeSystem
{
    interface INode
    {
        Node GetNeighbour(Directions dir);
        void AssignNeighbour(Directions dir, Node node);
        void InteractedWith();
        void ChangeType(NodeTypes newType);
        NodeTypes GetNodeType();
        void Entered();

    }
}
