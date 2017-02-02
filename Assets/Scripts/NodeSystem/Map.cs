using System;
using System.Collections.Generic;
using UnityEngine;
using Util.DataTypes;

namespace NodeSystem
{
    class Map : MonoBehaviour
    {

        public Sprite Ground;
        public Sprite Wall;

        public Tile tileprefab;

        Dictionary<Vec2i, Node> mapData = new Dictionary<Vec2i, Node>();

        private void Start()
        {
            CreateMap(5, 5);
        }

        public void CreateMap(int xSize, int ySize)
        {
            Node[,] nodes = new Node[xSize, ySize];
            Vec2i pos;
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    pos = new Vec2i(x, y);
                    if(UnityEngine.Random.Range(0, 5) == 0)
                    {
                        nodes[x, y] = new Node(NodeTypes.Ground, NodeClassification.Walkable, pos);
                    }
                    else
                    {
                        nodes[x, y] = new Node(NodeTypes.Wall, NodeClassification.Unwalkable, pos);
                    }
                    mapData.Add(pos, nodes[x, y]);
                    var t = Instantiate(tileprefab, new Vector3(x, y, 0), Quaternion.identity, transform) as Tile;
                    t.AssignNodeAndMap(nodes[x, y], this);
                }
            }

            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    if(x != 0)
                    {
                        nodes[x, y].AssignNeighbour(Directions.West, nodes[x - 1, y]);
                    }
                    if(y != 0)
                    {
                        nodes[x, y].AssignNeighbour(Directions.South, nodes[x, y - 1]);
                    }
                    if(x != xSize - 1)
                    {
                        nodes[x, y].AssignNeighbour(Directions.East, nodes[x + 1, y]);
                    }
                    if(y!= ySize - 1)
                    {
                        nodes[x, y].AssignNeighbour(Directions.North, nodes[x, y + 1]);
                    }
                }
            }
        }

        public Sprite GetSprite(NodeTypes type)
        {
            switch (type)
            {
                case NodeTypes.Ground:
                    return Ground;
                case NodeTypes.Wall:
                    return Wall;
                default:
                    new NotImplementedException();
                    return null;
            }
        }

        public Node GetNodeFromPos(Vec2i pos)
        {
            return mapData[pos];
        }
    }
}
