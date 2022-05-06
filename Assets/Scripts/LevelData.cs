using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level Editor/Level")]
public class LevelData : ScriptableObject
{
    public string levelID;
    public LevelElement[] staticElements;
    public LevelElement[] interactableElements;
    public List<LevelElement> enemyElements;
}
