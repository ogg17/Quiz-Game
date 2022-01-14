using UnityEngine;

[CreateAssetMenu(menuName = "Levels/Default Level", fileName = "New Level")]
public class Level : ScriptableObject {
    [Tooltip("Rows in level")]
    [SerializeField] private int rowsLevel;
    [Tooltip("Columns in level")]
    [SerializeField] private int columnsLevel;

    public int RowsLevel => rowsLevel;
    public int ColumnsLevel => columnsLevel;
}
