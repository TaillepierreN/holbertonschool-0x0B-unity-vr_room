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
    }

    void OnDisable()
    {
        interactable.hoverEntered.RemoveListener(OnHoverEnter);
        interactable.hoverExited.RemoveListener(OnHoverExit);
    }

    void OnHoverEnter(HoverEnterEventArgs args)
    {
        if (objectRenderer != null && highlightMaterialInstance != null)
            objectRenderer.material = highlightMaterialInstance;
    }

    void OnHoverExit(HoverExitEventArgs args)
    {
        if (objectRenderer != null && originalMaterial != null)
            objectRenderer.material = originalMaterial;
    }
}
