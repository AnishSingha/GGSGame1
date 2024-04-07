using UnityEngine;

public class PopupUI : MonoBehaviour
{
    public GameObject popupPrefab;

    void OnEnable()
    {
        // Subscribe Show to the OnPlayerDeath event
        PlayerUIDisplayEvent.OnPlayerDeathorWin += Show;
    }

    void OnDisable()
    {
        // Unsubscribe Show from the OnPlayerDeath event
        PlayerUIDisplayEvent.OnPlayerDeathorWin -= Show;
    }

    void Show()
    {
        popupPrefab.SetActive(true);
        Debug.Log("SHowing uI");
    }

    public void Hide()
    {
        popupPrefab.SetActive(false);
    }
}