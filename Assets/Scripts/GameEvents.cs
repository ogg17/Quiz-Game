using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour {
    [SerializeField] private UnityEvent startGame;
    [SerializeField] private UnityEvent levelUp;
    [SerializeField] private UnityEvent reloadGame;

    public UnityEvent LevelUp => levelUp;
    private void Start() {
        startGame.Invoke();
    }
}
