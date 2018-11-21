using UnityEngine;
//Used to handle the direction the player is facing, using cardinal directions
public enum Direction
{
    N,
    NE,
    E,
    SE,
    S,
    SW,
    W,
    NW
}


public static class DirectionExtention
{
    //Returns the unit vector corresponding to the cardinal direction
    //Example use: Direction.N.UnitVector() -> (1,0)
    public static Vector3 UnitVector(this Direction self)
    {
        
        switch (self)
        {
            case Direction.N:
                return Vector3.up;
            case Direction.NE:
                return (Vector3.up + Vector3.right).normalized;
            case Direction.E:
                return Vector3.right;
            case Direction.SE:
                return (Vector3.down + Vector3.right).normalized;
            case Direction.S:
                return Vector3.down;
            case Direction.SW:
                return (Vector3.down + Vector3.left).normalized;
            case Direction.W:
                return Vector3.left;
            case Direction.NW:
                return (Vector3.left + Vector3.up).normalized;
            default:
                return Vector3.zero;
        }
    }
}