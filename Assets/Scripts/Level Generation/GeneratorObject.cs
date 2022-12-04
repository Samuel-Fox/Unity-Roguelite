using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GeneratorObject.asset", menuName = "GeneratorObject/Generator")]
public class GeneratorObject : ScriptableObject
{
    public int numGenerators;
    public int min;
    public int max;
}
