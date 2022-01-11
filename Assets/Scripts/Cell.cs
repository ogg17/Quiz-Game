using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal;

[CreateAssetMenu(menuName = "Cell/Standard Cell", fileName = "New Cell")]
public class Cell : ScriptableObject {
    [Tooltip("Cell images")] 
    [SerializeField] private Sprite[] cellImages;

    [Tooltip("Cell Parameters")] 
    [SerializeField] private CellParameters[] cellParameters;

    public Sprite[] CellImages => cellImages;
    public CellParameters[] CellParameters => cellParameters;
}
    
[Serializable]
public struct CellParameters {
    [Tooltip("Cell name")]
    [SerializeField] private String cellName;
    
    [Tooltip("Cell local position")]
    [SerializeField] private Vector2 cellLocalPosition;
    
    [Tooltip("Cell local rotation")]
    [SerializeField] private Vector3 cellLocalRotation;
    
    [Tooltip("Cell local scale")]
    [SerializeField] private Vector2 cellLocalScale;

    public String CellName => cellName;
    public Vector2 CellLocalPosition => cellLocalPosition;
    public Vector3 CellLocalRotation => cellLocalRotation;
    public Vector2 CellLocalScale => cellLocalScale;
}