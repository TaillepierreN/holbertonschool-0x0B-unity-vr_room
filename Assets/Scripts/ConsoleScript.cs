using TMPro;
using UnityEngine;


public class ConsoleScript : MonoBehaviour
{
    private bool _online = false;
    public GameObject ConsoleTextPanel;
    public UnityEngine.UI.Image PanelImage;
    public Color PanelColor;
    public TMP_Text PanelText;
    public DoorHandle DoorHandleScript;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;


    public void ToggleConsole()
    {
        if (_online == false)
        {
            _audioSource.PlayOneShot(_audioClips[0]);
            _online = true;
            if (ConsoleTextPanel != null)
            {
                ConsoleTextPanel.SetActive(true);
            }
        }
    }

    public void InteractConsole()
    {
        if (_online == true && PanelImage != null)
        {
            _audioSource.PlayOneShot(_audioClips[1]);

            PanelImage.color = PanelColor;
            if (PanelText != null)
            {
                PanelText.text = "Unlocked";
            }
            if (DoorHandleScript != null)
            {
                DoorHandleScript.UnlockDoor();
            }
        }
    }
}
