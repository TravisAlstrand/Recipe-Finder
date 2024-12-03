using SojaExiles;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string incorrectText;
    [SerializeField] private string correctText;
    [SerializeField] private int associatedRiddle = 0;
    [SerializeField] private bool isKey = false;
    [SerializeField] private opencloseDoor lockedDoor;
    [SerializeField] private bool isRecipe = false;
    
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    public void Interact()
    {
        if (_gameManager.newRiddleText.gameObject.activeInHierarchy ||
            _gameManager.itemInspectionText.gameObject.activeInHierarchy)
        {
            return;
        }
        int currentRiddle = _gameManager.GetCurrentRiddle();
        if (associatedRiddle.Equals(0) || !associatedRiddle.Equals(currentRiddle))
        {
            _gameManager.ShowItemInspectionText(incorrectText, false);
        }
        else
        {
            _gameManager.ShowItemInspectionText(correctText, true);
            if (isKey)
            {
                lockedDoor.locked = false;
            }

            if (isKey || isRecipe)
            {
                Destroy(gameObject);
            }
        }
    }
}
