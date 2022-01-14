using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour {
    [SerializeField] private UnityEvent startGame;
    [SerializeField] private UnityEvent levelUp;
    [SerializeField] private UnityEvent endGame;
    [SerializeField] private UnityEvent reloadGame;

    public UnityEvent LevelUp => levelUp;
    public UnityEvent EndGame => endGame;
    public UnityEvent ReloadGame => reloadGame;

    private void Start() { // Entry point
        startGame.Invoke();
    }
}
