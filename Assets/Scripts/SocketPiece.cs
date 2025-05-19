using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SocketPiece : MonoBehaviour
{
    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor _socket;
    [SerializeField] private string _requiredLayer = "KnightLight";
    [SerializeField] private Projector _projector;
    [SerializeField] private AudioSource _audioSource;


    public static int score = 0;

    private void OnEnable()
    {
        _socket.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnDisable()
    {
        _socket.selectEntered.RemoveListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        var interactable = args.interactableObject as XRBaseInteractable;

        if (interactable == null)
        {
            Debug.LogWarning("Interactable is not an XRBaseInteractable.");
            return;
        }

        var pieceLayerMask = interactable.interactionLayers;
        var requiredMask = InteractionLayerMask.GetMask(_requiredLayer);

        if ((pieceLayerMask & requiredMask) != 0)
        {
            _audioSource.Play();
            _projector.PieceAdded();
        }
    }
}
