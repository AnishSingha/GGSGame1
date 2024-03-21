using PlayerHealth;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public string chestName; // The name of this chest
    public int unlockTimeInMinutes; // The time it takes to unlock this chest

    private Button button; // The Button component attached to this chest

    private void Start()
    {
        // Get the Button component
        button = GetComponent<Button>();

        // Add a listener for the button click event
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        // Call the UnlockChest function when the button is clicked
       // PlayerLives.instance.UnlockChest(chestName, unlockTimeInMinutes);

        // Disable the button so it can't be clicked again
        button.interactable = false;
    }
}
