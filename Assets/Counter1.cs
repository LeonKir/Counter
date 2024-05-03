using System.Collections;
using TMPro;
using UnityEngine;

public class Counter1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private bool _isWork = true;

    private void Start()
    {
        _text.text = "";

        StartCoroutine(Countdown(0.5f));        
    }

    private IEnumerator Countdown(float delay)
    {
        var wait = new WaitForSeconds(delay);
        
        int number = 0;

        while (true)
        {
            if (_isWork)
            {
                DisplayCountdown(number++);
                yield return wait;
            }
            else
            {
                yield return null;
            }
        }
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString("");
    }

    public void Click()
    {
        if (_isWork)
        {
            _isWork = false;
        }
        else
        {
            _isWork = true;
        }
    }
}