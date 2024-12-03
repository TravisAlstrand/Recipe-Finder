using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI newRiddleText;
    [SerializeField] private TextMeshProUGUI currentRiddleText;
    public TextMeshProUGUI itemInspectionText;
    [SerializeField] private float riddleTimeToWait = 10.0f;
    [SerializeField] private float itemTimeToWait = 5.0f;
    [SerializeField] private string[] riddles;

    private int _currentRiddle = 9;

    private FirstPersonController _playerController;

    private void Awake()
    {
        _playerController = FindFirstObjectByType<FirstPersonController>();
    }

    private void Start()
    {
        SetNewRiddle(riddles[_currentRiddle]);
    }

    private void SetNewRiddle(string newRiddle)
    {
        newRiddleText.text = $"Riddle {_currentRiddle}:\n\"{newRiddle}\"";
        currentRiddleText.text = $"\"{newRiddle}\"";
        _playerController.ToggleCrosshair();
        newRiddleText.gameObject.SetActive(true);
        StartCoroutine(WaitToSwitchRiddleTexts());
    }

    public void ShowItemInspectionText(string textToShow, bool wasCorrectItem)
    {
        itemInspectionText.text = textToShow;
        if (wasCorrectItem)
        {
            itemInspectionText.color = Color.green;
            currentRiddleText.gameObject.SetActive(false);
        }
        else
        {
            itemInspectionText.color = Color.red;
        }
        _playerController.ToggleCrosshair();
        itemInspectionText.gameObject.SetActive(true);
        StartCoroutine(WaitToRemoveItemText(wasCorrectItem));
    }

    public int GetCurrentRiddle()
    {
        return _currentRiddle;
    }

    private IEnumerator WaitToSwitchRiddleTexts()
    {
        yield return new WaitForSeconds(riddleTimeToWait);
        newRiddleText.gameObject.SetActive(false);
        currentRiddleText.gameObject.SetActive(true);
        _playerController.ToggleCrosshair();
    }

    private IEnumerator WaitToRemoveItemText(bool wasCorrect)
    {
        yield return new WaitForSeconds(itemTimeToWait);
        itemInspectionText.gameObject.SetActive(false);
        _playerController.ToggleCrosshair();
        if (wasCorrect && _currentRiddle < riddles.Length - 1)
        {
            _currentRiddle++;
            SetNewRiddle(riddles[_currentRiddle]);
        }
    }
}
