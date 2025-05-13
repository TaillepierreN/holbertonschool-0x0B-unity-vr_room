using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class HighlightOnHover : MonoBehaviour
{
    public Material highlightMaterialTemplate;
    private Material highlightMaterialInstance;
    private Material originalMaterial;
    private Texture originalMainTex;

    private Renderer objectRenderer;
    private XRBaseInteractable interactable;

    private bool isGrabbed = false;

    void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        interactable = GetComponent<XRBaseInteractable>();

        if (objectRenderer != null)
        {
            originalMaterial = objectRenderer.material;
            originalMainTex = originalMaterial.GetTexture("_BaseMap");
        }

        if (highlightMaterialTemplate != null)
        {
            highlightMaterialInstance = new Material(highlightMaterialTemplate);
            if (originalMainTex != null)
            {
                highlightMaterialInstance.SetTexture("_BaseMap", originalMainTex);
            }
        }
    }

    void OnEnable()
    {
        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.hoverExited.AddListener(OnHoverExit);
        interactable.selectEntered.AddListener(OnGrab);
        interactable.selectExited.AddListener(OnRelease);
    }

    void OnDisable()
    {
        interactable.hoverEntered.RemoveListener(OnHoverEnter);
        interactable.hoverExited.RemoveListener(OnHoverExit);
        interactable.selectEntered.RemoveListener(OnGrab);
        interactable.selectExited.RemoveListener(OnRelease);
    }

    void OnHoverEnter(HoverEnterEventArgs args)
    {
        if (!isGrabbed && objectRenderer != null && highlightMaterialInstance != null)
            objectRenderer.material = highlightMaterialInstance;
    }

    void OnHoverExit(HoverExitEventArgs args)
    {
        if (objectRenderer != null && originalMaterial != null)
            objectRenderer.material = originalMaterial;
    }

        void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        if (objectRenderer != null && originalMaterial != null)
            objectRenderer.material = originalMaterial;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
    }
}
