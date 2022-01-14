using DG.Tweening;
using UnityEngine;

public class CellGameController : MonoBehaviour
{
    [Tooltip("CellGridGenerator")]
    [SerializeField] private CellGridGenerator cellGenerator;

    [Tooltip("CellFillController")] 
    [SerializeField] private CellFillController cellFillController;
    
    [Tooltip("GameEvents")]
    [SerializeField] private GameEvents events;

    [Tooltip("FindTextScript")] 
    [SerializeField] private TextScript findText;
    
    [Tooltip("Find Text Animation")]
    [SerializeField] private TextAnimation findTextAnimation;

    [Tooltip("End Background Animation")] 
    [SerializeField] private BackgroundAnimations backgroundAnimations;
    
    [Tooltip("Load Screen Animation")] 
    [SerializeField] private BackgroundAnimations loadScreenAnimations;

    [Tooltip("Restart Button")] 
    [SerializeField] private GameObject restartButton;
    
    [Tooltip("Text in TextFind")] 
    [SerializeField] private string findString;

    public void StartGame() {
        findText.Init();
        backgroundAnimations.Init();
        loadScreenAnimations.Init();
        findTextAnimation.Init();
        findTextAnimation.ResetAnimation();
        CellsAnimationStart();
        findTextAnimation.ShowAnimation();
        SetWinCell();
    }

    public void GameWin() {
        cellGenerator.CellAnimations[cellFillController.WinCellId].WinBounceAnimation(
                cellGenerator.CellScripts[cellFillController.WinCellId].CellOption.CellLocalScale)
            .OnComplete(() => events.LevelUp.Invoke());
    }

    public void OnLevelUp() {
        if (cellGenerator.CurrentLevel < cellGenerator.Levels.Length) {
            SetWinCell();
        }
        else {
            cellGenerator.CurrentLevel = 0;
            backgroundAnimations.gameObject.SetActive(true);
            backgroundAnimations.ShowAnimation()
                .OnComplete(() => {
                    events.EndGame.Invoke();
                    findTextAnimation.ResetAnimation();
                });
        }
    }

    private void SetWinCell() {
        var cellScripts = cellGenerator.CellScripts;
        cellScripts[cellFillController.WinCellId].GameController = this;
        cellScripts[cellFillController.WinCellId].IsWinCell = true;
        findText.SetText(findString + cellScripts[cellFillController.WinCellId].CellOption.CellName);
    }

    public void OnReloadGame() {
        restartButton.SetActive(false);
        loadScreenAnimations.gameObject.SetActive(true);

        backgroundAnimations.HideAnimation().OnComplete(() => {
            events.ReloadGame.Invoke();
            backgroundAnimations.gameObject.SetActive(false);
            foreach (var cellAnimation in cellGenerator.CellAnimations) {
                cellAnimation.ResetAnimation();
            }
            findTextAnimation.ResetAnimation();
        });
        
        loadScreenAnimations.DelayHideAnimation()
            .OnComplete(() => {
                loadScreenAnimations.gameObject.SetActive(false);
                CellsAnimationStart();
                findTextAnimation.ShowAnimation();
            });
    }

    private void CellsAnimationStart() {
        for (var i = 0; i < cellGenerator.CellAnimations.Count; i++) {
            cellGenerator.CellAnimations[i].BounceAnimationStart(
                cellGenerator.CellScripts[i].CellOption.CellLocalScale);
        }
    }
}
