using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomData
{
    public float X;
    public float Y;
    public int Enemies;
    public RoomData(float x, float y, int enemies)
    {
        X = x;
        Y = y;
        Enemies = enemies;
    }
}
public class RoomController : MonoBehaviour
{
    public static RoomController instance = null;
    RoomData currentRoom;
    Queue<RoomData> roomQueue = new Queue<RoomData>();
    public List<RoomData> loaded = new List<RoomData>();
    [SerializeField] private GameObject startRoom;
    [SerializeField] private GameObject loadedRoom;
    [SerializeField] private GameObject itemRoom;
    [SerializeField] private GameObject bossRoom;
    
    bool loading = false;


    void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        UpdateRoomQueue();
    }

    void UpdateRoomQueue()
    {
        if(loading)
        {
            return;
        }
        if(roomQueue.Count == 0)
        {
            return;
        }

        currentRoom = roomQueue.Dequeue();
        loading = true;
    }
    public void LoadStart()
    {
        RoomData newRoomData = new RoomData(0,0,0);
        roomQueue.Enqueue(newRoomData);
        loaded.Add(newRoomData);
        Instantiate(startRoom, new Vector3(0, 0, 0), transform.rotation);
        LevelGenerator.instance.SpawnDoors(0,0);
    }
    public void LoadRoom(float x, float y, int roomType)
    {
        if(!DoesRoomExist(x, y))
        {
            RoomData newRoomData = new RoomData(x,y,0);
            roomQueue.Enqueue(newRoomData);
            loaded.Add(newRoomData);
            switch(roomType)
            {
                case 0:
                    Instantiate(loadedRoom, new Vector3(x*43*10, y*20*10, 0), transform.rotation);
                    SetEnemiesInRoom(x, y, 1);
                    break;
                case 1:
                    Instantiate(itemRoom, new Vector3(x*43*10, y*20*10, 0), transform.rotation);
                    SetEnemiesInRoom(x, y, 0);
                    break;
                case 2:
                    Instantiate(bossRoom, new Vector3(x*43*10, y*20*10, 0), transform.rotation);
                    SetEnemiesInRoom(x, y, 1);
                    break;
                default:
                    Instantiate(loadedRoom, new Vector3(x*43*10, y*20*10, 0), transform.rotation);
                    SetEnemiesInRoom(x, y, 1);
                    break;
            }
        }
    }

    public bool DoesRoomExist(float x, float y) 
    {
        return loaded.Exists( item => item.X == x && item.Y == y);

    }

    public int RoomNumberInList(float x, float y)
    {
        if(DoesRoomExist(x, y))
        {
            return loaded.FindIndex(item => item.X == x && item.Y == y);
        }
        return -1;
    }

    public RoomData RoomDataInList(int index)
    {
        return loaded[index];
    }

    public void SetEnemiesInRoom(float x, float y, int enemies)
    {
        int index = RoomNumberInList(x, y);
        if(index < 0)
        {
            return;
        }
        RoomData roomToModify = RoomDataInList(index);
        roomToModify.Enemies = enemies;
    }

    public int GetEnemyCount(float x, float y)
    {
        int index = RoomNumberInList(x, y);
        if(index < 0)
        {
            return 0;
        }
        RoomData roomToCheck = RoomDataInList(index);
        return roomToCheck.Enemies;
    }

    public void ReduceEnemyCount(float x, float y)
    {
        int index = RoomNumberInList(x, y);
        if(index < 0)
        {
            return;
        }
        RoomData roomToCheck = RoomDataInList(index);
        roomToCheck.Enemies -=1;
    }
}
