using UnityEngine;
using System.Collections;

public class TargetHitFeedback : MonoBehaviour
{
    [Header("演出設定")]
    [SerializeField] private float hitScale = 1.3f;
    [SerializeField] private float duration = 0.1f;
    [SerializeField] private Color flashColor = Color.white;
    [SerializeField] private float flashIntensity = 0.7f;

    private Vector3 originalScale;
    private Color originalColor;
    private SpriteRenderer sr;
    private Coroutine feedbackRoutine;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;

        if (sr != null)
        {
            originalColor = sr.color;
        }
    }

    public void PlayHitEffect()
    {
        if (feedbackRoutine != null)
        {
            StopCoroutine(feedbackRoutine);
        }

        feedbackRoutine = StartCoroutine(FeedbackRoutine());
    }

    private IEnumerator FeedbackRoutine()
    {
        float timer = 0f;

        // 拡大＆発光初期処理
        transform.localScale = originalScale * hitScale;
        if (sr != null)
        {
            sr.color = Color.Lerp(originalColor, flashColor, flashIntensity);
        }

        // 戻す処理
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;

            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, t);

            if (sr != null)
            {
                sr.color = Color.Lerp(sr.color, originalColor, t);
            }

            yield return null;
        }

        transform.localScale = originalScale;
        if (sr != null)
        {
            sr.color = originalColor;
        }
    }
}
