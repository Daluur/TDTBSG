namespace Util.DataTypes
{
    public enum Directions
    {
        North,
        East,
        South,
        West
    }

    public enum NodeTypes
    {
        Ground,
        Wall,
    }

    public enum NodeClassification
    {
        Walkable,
        Unwalkable,
    }

    public enum HighlightState
    {
        NoHighlight,
        Simple, 
        Specific,
        Uninteractable,
    }
}