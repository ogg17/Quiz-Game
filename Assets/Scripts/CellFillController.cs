using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellFillController : MonoBehaviour {
    [Tooltip("CellGridGenerator")]
    [SerializeField] private CellGridGenerator cellGenerator;
    
    [Tooltip("Set of sells")]
    [SerializeField] private Cell[] cellsSet;

    private int _currentLevel;

    public void CellFill() {
        _currentLevel = Random.Range(0, cellsSet.Length);
        var randomNumbers = Enumerable.Range(1, cellsSet[_currentLevel].CellParameters.Length).ToArray();
        Shuffle(randomNumbers);

        var cells = cellGenerator.CellObjects;
        var cellScripts = cellGenerator.CellScripts;
        for (var i = 0; i < cells.Count; i++) {
            if (i < cellsSet[_currentLevel].CellParameters.Length) {
                cellScripts[i].SetImage(cellsSet[_currentLevel].CellImages[i]);
                cellScripts[i].SetTransform(cellsSet[_currentLevel].CellParameters[i]);
            }
            else i = 0;
        }
    }
    
    private void Shuffle(int[] list)  
    {  
        int n = list.Length;  
        while (n > 1) {  
            n--;  
            var k = Random.Range(0, n + 1);  
            (list[k], list[n]) = (list[n], list[k]);
        }  
    }
}
