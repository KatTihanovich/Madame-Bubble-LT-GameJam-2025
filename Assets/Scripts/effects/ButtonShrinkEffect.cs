using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonShrinkEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 originalScale;
    [SerializeField] private float shrinkFactor = 0.8f; 
    [SerializeField] private float animationSpeed = 5f; 

    private Vector3 targetScale;
    private bool isPointerDown = false; 

    private void Awake()
    {
        originalScale = transform.localScale;
        targetScale = originalScale; 
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * animationSpeed);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        targetScale = originalScale * shrinkFactor;
        isPointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        targetScale = originalScale;
        isPointerDown = false;
    }
}
