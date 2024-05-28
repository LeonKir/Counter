using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Counter1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private IEnumerator _coroutine;

    float timeUpdate = 0.5f;

    bool isPaused = false;

    private void Start()
    {
        _text.text = "";

        _coroutine = Countdown(timeUpdate);
        StartCoroutine(_coroutine);
    }

    private IEnumerator Countdown(float delay)
    {
        var wait = new WaitForSeconds(delay);

        int number = 0;

        while (true)
        {
            DisplayCountdown(number++);
            yield return wait;
        }
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString("");
    }

    public void Click()
    {
        if (isPaused)
        {
            StartCoroutine(_coroutine);
            isPaused = false;
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                isPaused = true;
            }            
        }
    }
}