using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level Element", menuName = "Level Editor/Level Element")]
public class LevelElement : ScriptableObject
{
    //https://stackoverflow.com/questions/56618617/how-to-use-a-scriptableobject-for-a-levels-prefab-transforms
    public string elementID;
    public string elementName;
    public string elementType; // make this a Scriptable Object too.

    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

}

