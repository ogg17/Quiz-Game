using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Cell/Standard Cell", fileName = "New Cell")]
public class Cell : ScriptableObject {
    [Tooltip("Cell Images")] 
    [SerializeField] private Sprite[] cellImages;

    [Tooltip("Cell Parameters")] 
    [SerializeField] private CellOptions[] cellParameters;

    public Sprite[] CellImages => cellImages;
    public CellOptions[] CellParameters => cellParameters;
}
    
[Serializable]
public struct CellOptions {
    [Tooltip("Cell Name")]
    [SerializeField] private String cellName;
    
    [Tooltip("Cell Local Position")]
    [SerializeField] private Vector2 cellLocalPosition;
    
    [Tooltip("Cell Local Rotation")]
    [SerializeField] private Vector3 cellLocalRotation;
    
    [Tooltip("Cell Local Scale")]
    [SerializeField] private Vector2 cellLocalScale;

    public String CellName => cellName;
    public Vector2 CellLocalPosition => cellLocalPosition;
    public Vector3 CellLocalRotation => cellLocalRotation;
    public Vector2 CellLocalScale => cellLocalScale == Vector2.zero ? Vector2.one : cellLocalScale;
}