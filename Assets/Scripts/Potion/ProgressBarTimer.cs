using Spine.Unity;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarTimer : MonoBehaviour
{
    [SerializeField] private Image _progressBarImage;
    [SerializeField] private SkeletonAnimation _animCauldron;
    [SerializeField] private SkeletonAnimation _animHands;

    public delegate void TimerCompleted();
    public event TimerCompleted OnTimerCompleted;

    private void Awake()
    {
        if (_progressBarImage != null)
        {
            _progressBarImage.fillAmount = 0;
            _progressBarImage.gameObject.SetActive(false);
        }
    }

    public void StartTimer(float duration)
    {
        if (_progressBarImage != null)
        {
            _progressBarImage.fillAmount = 0;
            _progressBarImage.gameObject.SetActive(true);
            StartCoroutine(TimerCoroutine(duration));
        }
    }

    private IEnumerator TimerCoroutine(float duration)
    {
        float elapsedTime = 0f;
        _animCauldron.AnimationName = "MAGIC";
        _animHands.AnimationName = "MAGIC";
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            _progressBarImage.fillAmount = elapsedTime / duration;
            yield return null;
        }

        _progressBarImage.fillAmount = 1f;
        _progressBarImage.gameObject.SetActive(false);

        // Уведомление о завершении таймера
        _animCauldron.AnimationName = "SELECTION";
        _animHands.AnimationName = "IDLE";
        OnTimerCompleted?.Invoke();
    }

    public void ResetTimer()
    {
        if (_progressBarImage != null)
        {
            StopAllCoroutines();
            _progressBarImage.fillAmount = 0;
            _progressBarImage.gameObject.SetActive(false);
        }
    }
}
