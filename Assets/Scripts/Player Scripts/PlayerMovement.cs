using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;
    private Vector2 movement;

    public Vector2 playerPos = new Vector2(0, 0);

    public static PlayerMovement instance = null;

    void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY).normalized;
        player.velocity = new Vector2(movement.x * PlayerController.instance.moveSpeed, movement.y * PlayerController.instance.moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 savedPos = playerPos;
        if(RoomController.instance.GetEnemyCount(playerPos.x, playerPos.y) > 0)
        {
            return;
        }
        if(other.tag == "Ladder")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            ResetStatic.ResetData();
            PlayerController.instance.transform.position = new Vector3(0, 0 ,0);
            playerPos.x = 0;
            playerPos.y = 0;
            PlayerController.instance.currentLevel += 1;
            return;
        }
        switch(other.tag)
        {
            case "North":
                if(RoomController.instance.DoesRoomExist(playerPos.x, playerPos.y+1))
                {
                    player.transform.position = new Vector3(player.transform.position.x, (playerPos.y+1)*200-8, player.transform.position.z);
                    playerPos.y+=1;
                }
                break;
            case "South":
                if(RoomController.instance.DoesRoomExist(playerPos.x, playerPos.y-1))
                {
                    player.transform.position = new Vector3(player.transform.position.x, (playerPos.y-1)*200+8, player.transform.position.z);
                    playerPos.y-=1;
                }
                break;
            case "East":
                if(RoomController.instance.DoesRoomExist(playerPos.x+1, playerPos.y))
                {
                    player.transform.position = new Vector3((playerPos.x+1)*430-17, player.transform.position.y, player.transform.position.z);
                    playerPos.x+=1;
                }
                break;
            case "West":
                if(RoomController.instance.DoesRoomExist(playerPos.x-1, playerPos.y))
                {
                    player.transform.position = new Vector3((playerPos.x-1)*430+17, player.transform.position.y, player.transform.position.z);
                    playerPos.x-=1;
                }
                break;
            default:
                break;
        }
    }

}

