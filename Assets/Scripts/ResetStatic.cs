using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResetStatic
{
    public static void ResetData()
    {
        RoomController.instance = null;
        PathGenerationController.visited.Clear();
        LevelGenerator.instance = null;
        PlayerController.instance.currentHealth = 3;
    }
}
