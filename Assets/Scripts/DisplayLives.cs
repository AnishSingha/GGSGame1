using UnityEngine;
using TMPro;

public class DisplayLives : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        int totalLives = PlayerPrefs.GetInt("totalLives");
        text.text = totalLives.ToString();
    }
}