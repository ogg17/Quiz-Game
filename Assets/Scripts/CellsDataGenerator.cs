using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class CellsDataGenerator : MonoBehaviour
{
    [Tooltip("Set of sells")]
    [SerializeField] private Cell[] setCells;

    private readonly List<int[]> _winCellIndices = new List<int[]>();
    private readonly List<int> _lastWinCellIndices = new List<int>();
    
    public int RandomSetCellIndex { get; private set; }
    public Cell[] SetCells => setCells;


    public void OnStart() {
        GenerateWinCells();
    }

    private void GenerateWinCells() {
        foreach (var cell in setCells) {
            _lastWinCellIndices.Add(0);
            _winCellIndices.Add(Enumerable.Range(0, cell.CellParameters.Length).ToArray());
            Shuffle.ShuffleArray(_winCellIndices.Last());
        }
    }

    private void GenerateWinCells(int setIndex) {
        _lastWinCellIndices[setIndex] = 0;
        _winCellIndices[setIndex] = Enumerable.Range(0, setCells[setIndex].CellParameters.Length).ToArray();
        Shuffle.ShuffleArray(_winCellIndices[setIndex]);
    }

    public List<int> GenerateSessionData(Level currentLevel, out int winCellIndex) {
        var cellCount = currentLevel.ColumnsLevel * currentLevel.RowsLevel;
        if (cellCount <= 0) {
            Debug.LogError("Wrong number of rows or columns");
            winCellIndex = 0;
            return new List<int>();
        }
        
        RandomSetCellIndex = Random.Range(0, setCells.Length);
        var randomCellIndices = Enumerable.Range(0, setCells[RandomSetCellIndex].CellParameters.Length).ToArray();
        Shuffle.ShuffleArray(randomCellIndices);
        if (cellCount > randomCellIndices.Length) {
            Debug.LogError("Need more cells in the set than now!");
        }

        if (_lastWinCellIndices[RandomSetCellIndex] >= _winCellIndices[RandomSetCellIndex].Length)
                GenerateWinCells(RandomSetCellIndex);

        var cellsSession = new List<int>();
        var winCell = _winCellIndices[RandomSetCellIndex][_lastWinCellIndices[RandomSetCellIndex]];
        _lastWinCellIndices[RandomSetCellIndex]++;
        var isWinCell = false;
        winCellIndex = 0;
        for (var i = 0; i < cellCount; i++) {
            cellsSession.Add(randomCellIndices[i]);
            if (cellsSession[i] == winCell) {
                winCellIndex = i;
                isWinCell = true;
            }
        }
        if (isWinCell) 
            return cellsSession;

        var randomCellIndex = Random.Range(0, cellCount);
        cellsSession[randomCellIndex] = winCell;
        winCellIndex = randomCellIndex;
        return cellsSession;
    }
}
