using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    up = 0,
    right=1,
    down=2,
    left=3
}

public class PathGenerationController : MonoBehaviour
{
    public static List<Vector2Int> visited = new List<Vector2Int>();
    private static readonly Dictionary<Direction, Vector2Int> map = new Dictionary<Direction, Vector2Int>
    {
        {Direction.up, Vector2Int.up},
        {Direction.right, Vector2Int.right},
        {Direction.down, Vector2Int.down},
        {Direction.left, Vector2Int.left}
    };

    public static List<Vector2Int> GeneratePaths(GeneratorObject generatorInfo)
    {
        Random.InitState(System.DateTime.Now.TimeOfDay.Milliseconds);
        List<PathGeneration> pathGenerators = new List<PathGeneration>();

        for (int i = 0; i < generatorInfo.numGenerators + (int)(PlayerController.instance.currentLevel/3); i++)
        {
            pathGenerators.Add(new PathGeneration(Vector2Int.zero));
        }

        int iterations = Random.Range(generatorInfo.min + (int)(PlayerController.instance.currentLevel/2), 
                                      generatorInfo.max+ (int)(PlayerController.instance.currentLevel/2));

        for (int i = 0; i < iterations; i++)
        {
            foreach(PathGeneration pathGeneration in pathGenerators)
            {
                Vector2Int newPosition = pathGeneration.Move(map);
                visited.Add(newPosition);
            }
        }

        return visited;
    }

    void awake() 
    {
        if(visited.Count != 0)
        {
            visited.Clear();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
