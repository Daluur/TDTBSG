using System;
using System.Collections.Generic;
using Util.DataTypes;

namespace NodeSystem
{
    class Node : INode
    {
        Vec2i pos;
        Dictionary<Directions, Node> neighbours = new Dictionary<Directions, Node>();
        NodeTypes type;
        NodeClassification classification;
        HighlightState highlight = HighlightState.NoHighlight;
        Action<NodeTypes> typeUpdated;
        Action<HighlightState> highlightChanged;

        public Node(NodeTypes type, NodeClassification classification, Vec2i pos)
        {
            this.type = type;
            this.pos = pos;
            this.classification = classification;
        }

        public void AssignNeighbour(Directions dir, Node node)
        {
            if (neighbours.ContainsKey(dir))
            {
                throw new NotSupportedException();
            }
            neighbours.Add(dir, node);
        }

        public Node GetNeighbour(Directions dir)
        {
            return neighbours[dir];
        }

        public void Entered()
        {
            ChangeType(type == NodeTypes.Ground ? NodeTypes.Wall : NodeTypes.Ground);
        }

        public void InteractedWith()
        {
            Entered();
        }

        public void ChangeType(NodeTypes newType)
        {
            type = newType;
            if(typeUpdated != null)
            {
                typeUpdated(newType);
            }
        }

        public void ChangeHighlight(HighlightState newState)
        {
            if(highlight != newState)
            {
                highlight = newState;
                if(highlightChanged != null)
                {
                    highlightChanged(highlight);
                }
            }
        }

        public void SubscribeToTypeChange(Action<NodeTypes> cb)
        {
            typeUpdated += cb;
        }

        public void UnsubscrbeFromTypeChange(Action<NodeTypes> cb)
        {
            typeUpdated -= cb;
        }

        public void SubscribeToHighlightChange(Action<HighlightState> cb)
        {
            highlightChanged += cb;
        }

        public void UnsubscrbeFromHighlightChange(Action<HighlightState> cb)
        {
            highlightChanged -= cb;
        }

        public NodeTypes GetNodeType()
        {
            return type;
        }
    }
}
