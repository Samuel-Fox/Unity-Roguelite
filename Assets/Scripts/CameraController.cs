using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static CameraController instance;
    public Rigidbody2D player;
    public float cameraSpeed;
    private int x = 0;
    private int y = 0;
    // Start is called before the first frame update

    void Awake() 
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveCamera(string tag)
    {
        switch(tag)
        {
            case "North":
                y+=1;
                break;
            case "South":
                y-=1;
                break;
            case "East":
                x+=1;
                break;
            case "West":
                x-=1;
                break;
            default:
                Debug.Log("Tag Issue");
                break;
        }
//        Debug.Log(x);
//        Debug.Log(y);
        StartCoroutine(cameraMoving());
    }

    IEnumerator cameraMoving()
    {
         while(this.transform.position !=  new Vector3(x*43*10, y*20*10, 0))
        {
            this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(x*43*10, y*20*10, transform.position.z), Time.deltaTime * cameraSpeed);
            yield return null;
        }
        yield return null;
    }

}
