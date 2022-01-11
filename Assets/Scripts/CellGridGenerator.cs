using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class CellGridGenerator : MonoBehaviour {
    [Tooltip("Levels")]
    [SerializeField] private Level[] levels;

    [Tooltip("Set Cells")] 
    [SerializeField] private Cell[] cellsSet;

    [Tooltip("Cell Prefab")] 
    [SerializeField] private GameObject cell;

    [SerializeField] private float xScale;
    [SerializeField] private float yScale;
    
    private int _currentLevel;
    private RectTransform _selfTransform;
    public List<GameObject> CellObjects { get; } = new List<GameObject>();
    public List<CellScript> CellScripts { get; } = new List<CellScript>();
    
    public void OnStart() {
        _currentLevel = 0;
        _selfTransform = GetComponent<RectTransform>();
    }

    public void GenerateGrid() {
        var position = _selfTransform.anchoredPosition;
        for (int i = 0; i < levels[_currentLevel].LevelColumns; i++)
            for (int j = 0; j < levels[_currentLevel].LevelRows; j++) {
                position.x = i * xScale - (levels[_currentLevel].LevelColumns - 1) * xScale / 2;  //По формуле середины отрезка
                position.y = j * yScale;
                CellObjects.Add(Instantiate(cell, _selfTransform.position, _selfTransform.localRotation, _selfTransform));
                CellObjects[CellObjects.Count - 1].GetComponent<RectTransform>().anchoredPosition += position;
                CellScripts.Add(CellObjects[CellObjects.Count - 1].GetComponent<CellScript>());
            }
    }

    public void NextLevel() {
        _currentLevel = _currentLevel < levels.Length ? _currentLevel + 1 : 0;
        foreach (var cellGameObject in CellObjects) {
            Destroy(cellGameObject);
        }
        CellObjects.Clear();
        GenerateGrid();
    }

    public int GetCellsCount() {
        return 0;
    }

}
