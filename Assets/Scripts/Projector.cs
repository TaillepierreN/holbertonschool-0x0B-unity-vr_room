using UnityEngine;

public class Projector : MonoBehaviour
{
    public GameObject ProjectorLight;
    public ParticleSystem ParticleSystem;
    private bool _isOn;
    private int _piecesCount = 0;
    [SerializeField] private AudioSource _audioSource;

    public void PieceAdded()
    {
        _piecesCount++;
        if (_piecesCount >= 4)
        {
            _audioSource.Play();
            _isOn = true;
        }
    }

    public void TurnProjectorOn()
    {
        if (_isOn)
        {
            if (ProjectorLight != null)
            {
                ProjectorLight.SetActive(true);
            }
            if (ParticleSystem != null)
            {
                ParticleSystem.Play();
            }
        }
    }
}
