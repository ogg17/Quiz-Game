using UnityEngine;

public class CellFillController : MonoBehaviour {
    [Tooltip("CellGridGenerator")]
    [SerializeField] private CellGridGenerator cellGenerator;

    [Tooltip("CellDataGenerator")]
    [SerializeField] private CellsDataGenerator cellsDataGenerator;
    
    public int WinCellId { get; private set; }

    public void FillCells() {
        if (cellGenerator.CurrentLevel < cellGenerator.Levels.Length) {
            var cellsData = cellsDataGenerator.GenerateSessionData(
                cellGenerator.Levels[cellGenerator.CurrentLevel], out var winCellId);
            for (var i = 0; i < cellsData.Count; i++) {
                cellGenerator.CellScripts[i].SetImage(
                    cellsDataGenerator.SetCells[cellsDataGenerator.RandomSetCellIndex].CellImages[cellsData[i]]);
                cellGenerator.CellScripts[i].SetParameter(
                    cellsDataGenerator.SetCells[cellsDataGenerator.RandomSetCellIndex].CellParameters[cellsData[i]]);
                cellGenerator.CellScripts[i].CellAnimation.SequenceInit();
            }
            WinCellId = winCellId;
        }
    }
}
