using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUIDisplayEvent : MonoBehaviour
{
    public static Action OnPlayerDeathorWin;

    private void OnEnable()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene current)
    {
        OnPlayerDeathorWin = null;
    }

    public void Die()
    {
        OnPlayerDeathorWin?.Invoke();

    }
}
