using System.Collections;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    public Animator DoorAnimator;
    public GameObject DoorTextPanel;
    private bool Unlocked = false;
    private string boolParameterName = "character_nearby";
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;
    public void ToggleDoor()
    {
        if (DoorAnimator == null) return;
        if (Unlocked)
        {
            bool currentValue = DoorAnimator.GetBool(boolParameterName);
            if (currentValue)
            {
                _audioSource.PlayOneShot(_audioClips[1]);
            }
            else
            {
                _audioSource.PlayOneShot(_audioClips[2]);
            }
            DoorAnimator.SetBool(boolParameterName, !currentValue);
        }
        else
        {
            _audioSource.PlayOneShot(_audioClips[0]);
            StartCoroutine(ShowDoorTextPanel());
        }
    }

    public void UnlockDoor()
    {
        Unlocked = true;
    }

    private IEnumerator ShowDoorTextPanel()
    {
        if (DoorTextPanel != null)
        {
            DoorTextPanel.SetActive(true);
            yield return new WaitForSeconds(5f);
            DoorTextPanel.SetActive(false);
        }
        else
        {
            yield return null;
        }
    }

}
