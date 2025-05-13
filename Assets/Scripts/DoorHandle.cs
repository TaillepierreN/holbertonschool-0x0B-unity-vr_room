using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    public Animator doorAnimator;
    private string boolParameterName = "character_nearby";
    public void ToggleDoor()
    {
        if (doorAnimator == null) return;

        bool currentValue = doorAnimator.GetBool(boolParameterName);
        doorAnimator.SetBool(boolParameterName, !currentValue);
    }
}
