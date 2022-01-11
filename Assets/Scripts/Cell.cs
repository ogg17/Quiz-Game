using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cell/Standard Cell", fileName = "New Cell")]
public class Cell : ScriptableObject {
    [Tooltip("Cell images")] 
    public List<Sprite> cellImages;
    [Tooltip("Cell Parameters")] [SerializeField]
    private List<CellParameters> cellParameters;
}
    
[Serializable]
public struct CellParameters {
    [Tooltip("Cell name")]
    public String cellName;
    [Tooltip("Cell local position")]
    public Vector2 cellLocalPosition;
    [Tooltip("Cell local rotation")]
    public Vector3 cellLocalRotation;
    [Tooltip("Cell local scale")]
    public Vector2 cellLocalScale;
}