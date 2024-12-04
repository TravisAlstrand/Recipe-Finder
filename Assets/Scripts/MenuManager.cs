using System;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private CursorManager _cursorManager;

    private void Awake()
    {
        _cursorManager = FindFirstObjectByType<CursorManager>();
    }

    private void Start()
    {
        _cursorManager.UnlockCursor();
    }
}
