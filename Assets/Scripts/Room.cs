using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public float X;
    public float Y;
    public int width = 43;
    public int height = 20;
    public int enemies;
    // Start is called before the first frame update
    void Start()
    {
        if(RoomController.instance == null)
        {
            return;
        }
        
    }

    public Vector3 RoomCenter()
    {
        return new Vector3(X * width, Y * height);
    }
}
