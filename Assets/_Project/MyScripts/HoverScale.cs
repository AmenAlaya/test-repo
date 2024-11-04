using UnityEngine;
using UnityEngine.EventSystems;

public class HoverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1.2f); // Scale when hovering
    public float transitionSpeed = 10f; // Speed of scaling transition

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale; // Store the original scale
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleTo(hoverScale)); // Scale up on hover
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleTo(originalScale)); // Scale back to original on exit
    }

    private System.Collections.IEnumerator ScaleTo(Vector3 targetScale)
    {
        while (Vector3.Distance(transform.localScale, targetScale) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * transitionSpeed);
            yield return null;
        }
        transform.localScale = targetScale;
    }
}
