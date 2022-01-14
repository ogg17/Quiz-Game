using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class CellGridGenerator : MonoBehaviour {
    [Tooltip("Levels")]
    [SerializeField] private Level[] levels;
    public Level[] Levels => levels;

    [Tooltip("Cell Prefab")] 
    [SerializeField] private GameObject cellObject;

    [SerializeField] private float rowDistance;
    [SerializeField] private float columnDistance;

    private RectTransform _selfTransform;
    private readonly List<GameObject> _cellObjects = new List<GameObject>();
    
    public int CurrentLevel { get; set; }
    public List<CellScript> CellScripts { get; } = new List<CellScript>();
    public List<CellAnimation> CellAnimations { get; } = new List<CellAnimation>();

    public void OnStart() {
        CurrentLevel = 0;
        _selfTransform = GetComponent<RectTransform>();
    }

    public void GenerateGrid() {
        var selfPosition = _selfTransform.anchoredPosition;
        for (int i = 0; i < levels[CurrentLevel].ColumnsLevel; i++)
            for (int j = 0; j < levels[CurrentLevel].RowsLevel; j++) {
                selfPosition.x = i * rowDistance - (levels[CurrentLevel].ColumnsLevel - 1) * rowDistance / 2;  //By midpoint formula
                selfPosition.y = j * columnDistance - (levels[CurrentLevel].RowsLevel - 1) * columnDistance / 2;
                _cellObjects.Add(Instantiate(cellObject, _selfTransform.position, _selfTransform.localRotation, _selfTransform));
                _cellObjects.Last().GetComponent<RectTransform>().anchoredPosition += selfPosition;
                CellScripts.Add(_cellObjects.Last().GetComponent<CellScript>());
                CellAnimations.Add(_cellObjects.Last().GetComponent<CellAnimation>());
            }
    }

    public void NextLevel() {
        CurrentLevel++;

        foreach (var cellScript in CellScripts) {
            cellScript.CellAnimation.KillAnimation();
        }
        foreach (var cellGameObject in _cellObjects) {
            Destroy(cellGameObject);
        }
        _cellObjects.Clear();
        CellScripts.Clear();
        CellAnimations.Clear();
        if(CurrentLevel < levels.Length) GenerateGrid();
    }
}
