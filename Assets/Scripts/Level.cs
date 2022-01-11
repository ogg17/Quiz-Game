using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Levels/Default Level", fileName = "New Level")]
public class Level : ScriptableObject {
    [Tooltip("Rows per level")]
    [SerializeField] private int levelRows;
    [Tooltip("Columns per level")]
    [SerializeField] private int levelColumns;

    public int LevelRows => levelRows;
    public int LevelColumns => levelColumns;
}
