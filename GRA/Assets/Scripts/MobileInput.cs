using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static bool leftHeld = false;
    public static bool rightHeld = false;
    public static bool pausePressed = false;

    public void PressLeft() => leftHeld = true;
    public void ReleaseLeft() => leftHeld = false;

    public void PressRight() => rightHeld = true;
    public void ReleaseRight() => rightHeld = false;

    public void TogglePause() => pausePressed = true;
}
