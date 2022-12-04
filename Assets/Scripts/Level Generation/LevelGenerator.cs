using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    private List<Vector2Int> levelRooms;
    public GeneratorObject generatorObject;
    public List<GameObject> doors = new List<GameObject>();
    public static LevelGenerator instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        levelRooms = PathGenerationController.GeneratePaths(generatorObject);
        CreateRooms(levelRooms);
    }

    private void CreateRooms(IEnumerable<Vector2Int> rooms)
    {
        Random.InitState(System.DateTime.Now.TimeOfDay.Milliseconds);
        int itemRoomLocation = Random.Range(1, levelRooms.Count - 1);
        int furthestRoom = FindFurthest(rooms);
        while(itemRoomLocation == furthestRoom)
        {
            itemRoomLocation = Random.Range(1, levelRooms.Count - 2);
        }

        RoomController.instance.LoadStart();
        foreach(Vector2Int location in rooms)
        {
            if(location == levelRooms[furthestRoom]) 
            {
                RoomController.instance.LoadRoom(location.x, location.y, 2);
            }
            else if (location == levelRooms[itemRoomLocation])
            {
                RoomController.instance.LoadRoom(location.x, location.y, 1);
            }
            else 
            {
                RoomController.instance.LoadRoom(location.x, location.y, 0);
            }
            SpawnDoors(location.x, location.y);
        }

    }

    public int FindFurthest(IEnumerable<Vector2Int> rooms)
    {
        int maxDistance = 0;
        int currentDistance = 0;
        int currentIndex = 0;
        int maxIndex = 0;
        foreach(Vector2Int location in rooms)
        {
            currentDistance = Mathf.Abs(location.x) + Mathf.Abs(location.y);
            if(currentDistance > maxDistance)
            {
                maxDistance = currentDistance;
                maxIndex = currentIndex;
            }
            currentIndex += 1;
        }
        return maxIndex;
    }

    public void SpawnDoors(int x, int y)
    {
        List<int> doorSpawns = new List<int>();
        if(levelRooms.Exists(item => item.x == x && item.y == y+1) || (x == 0 && y+1 == 0))
        {
            doorSpawns.Add(0);
        }
        if(levelRooms.Exists(item => item.x == x && item.y == y-1)|| (x == 0 && y-1 == 0))
        {
            doorSpawns.Add(1);
        }
        if(levelRooms.Exists(item => item.x == x+1 && item.y == y)|| (x+1 == 0 && y == 0))
        {
            doorSpawns.Add(2);
        }
        if(levelRooms.Exists(item => item.x == x-1 && item.y == y)|| (x-1 == 0 && y == 0))
        {
             doorSpawns.Add(3);
        }
        foreach(int door in doorSpawns)
        {
            switch (door)
            {
                case 0:
                    Instantiate(doors[0], new Vector3(x*43*10, (float)(y*20*10+9.5), 0), transform.rotation);
                    break;
                case 1:
                    Instantiate(doors[1], new Vector3(x*43*10, (float)(y*20*10-9.5), 0), transform.rotation);
                    break;
                case 2:
                    Instantiate(doors[2], new Vector3(x*43*10+21, y*20*10, 0), transform.rotation);
                    break;
                case 3:
                    Instantiate(doors[3], new Vector3(x*43*10-21, y*20*10, 0), transform.rotation);
                    break;
            }
        }
    }
}
