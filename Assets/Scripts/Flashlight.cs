using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject Light;
    [SerializeField] private AudioSource _audioSource;


    public void ToggleLight()
    {
        if (Light != null)
        {
            _audioSource.Play();
            Light.SetActive(!Light.activeSelf);
        }
    }
}
