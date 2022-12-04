using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{

    public Room room;

    [System.Serializable]
    public struct Grid
    {
        public int columns, rows;
        public float verticalOffset, horizontalOffset;
    }

    public Grid grid;
    public GameObject gridTile;
    public List<Vector2> available = new List<Vector2>();

    void Awake() 
    {
        room = GetComponentInParent<Room>();
        grid.columns = 41;
        grid.rows = 18;
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        
    }
}
