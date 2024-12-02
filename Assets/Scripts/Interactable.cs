using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string incorrectText;
    [SerializeField] private string correctText;
    [SerializeField] private int associatedRiddle = 0;
    
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
        }
    }
}
