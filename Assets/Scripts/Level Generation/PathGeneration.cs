using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class PathGeneration : MonoBehaviour
{
    public Vector2Int Position {get; set;}
    public PathGeneration(Vector2Int startPos)
    {
        Position = startPos;
    }

    public Vector2Int Move(Dictionary<Direction, Vector2Int> map)
    {
        Direction move = (Direction)Random.Range(0, map.Count);
        Position += map[move];
        return Position;
    }
} */

public class PathGeneration
{
    public Vector2Int Position {get; set;}
    public PathGeneration(Vector2Int startPos)
    {
        Position = startPos;
    }
    public Vector2Int Move(Dictionary<Direction, Vector2Int> map)
    {
        Direction move = (Direction)Random.Range(0, map.Count);
        Position += map[move];
        return Position;
    }
}
    