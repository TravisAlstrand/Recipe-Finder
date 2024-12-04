using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor for gameplay
        Cursor.visible = false;       
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
