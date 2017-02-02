using System;
using System.Collections.Generic;
using UnityEngine;
using Util.DataTypes;

namespace NodeSystem
{
    class Tile : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        public Sprite defaultSprite;
        public GameObject[] highlights;
        GameObject activeHighlight;
        Node node;
        Map map;

        public void AssignNode(Node newNode)
        {
            node = newNode;
        }

        public void AssignNodeAndMap(Node newNode, Map newMap)
        {
            node = newNode;
            map = newMap;
            node.SubscribeToTypeChange(NewVisual);
            node.SubscribeToHighlightChange(ApplyHighlight);
            NewVisual(node.GetNodeType());
        }

        public void NewVisual(NodeTypes type)
        {
            spriteRenderer.sprite = map.GetSprite(type);
        }   

        public void ApplyHighlight(HighlightState highlight)
        {
            if(activeHighlight != null)
            {
                Destroy(activeHighlight);
            }
            switch (highlight)
            {
                case HighlightState.NoHighlight:
                    break;
                case HighlightState.Simple:
                    activeHighlight = Instantiate(highlights[0], transform.position, Quaternion.identity, transform) as GameObject;
                    break;
                case HighlightState.Specific:
                    activeHighlight = Instantiate(highlights[1], transform.position, Quaternion.identity, transform) as GameObject;
                    break;
                case HighlightState.Uninteractable:
                    activeHighlight = Instantiate(highlights[2], transform.position, Quaternion.identity, transform) as GameObject;
                    break;
                default:
                    break;
            }
        }

        private void OnMouseDown()
        {
            node.ChangeHighlight(HighlightState.Specific);
        }

        private void OnMouseEnter()
        {
            node.ChangeHighlight(HighlightState.Simple);
        }

        private void OnMouseExit()
        {
            node.ChangeHighlight(HighlightState.NoHighlight);
        }

        private void OnDestroy()
        {
            node.UnsubscrbeFromTypeChange(NewVisual);
            node.UnsubscrbeFromHighlightChange(ApplyHighlight);
        }

    }
}
