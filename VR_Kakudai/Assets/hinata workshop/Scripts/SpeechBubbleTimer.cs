using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubbleTimer : MonoBehaviour
{
    //timerLimitで制限時間変更
    float timerLimit;
    float seconds = 0f;
    
    [SerializeField] TestClock testclock;
    [SerializeField] Image hukidasi;
    [SerializeField] Canvas hukidasiImage;

    bool touch = false;
    void Start()
    {
        timerLimit = Random.Range(2,6 ) * 5;
        Debug.Log("制限時間" + timerLimit);

        hukidasi.color = Color.green;

        hukidasiImage.enabled = false;
    }

    void Update()
    {
        if (touch)
        {
            hukidasiImage.enabled=true;
            testclock.UpdateClock(_updateTimer());
        }
    }
    float _updateTimer()
    {
        seconds += Time.deltaTime;
        float timer = 1 - seconds / timerLimit;
        if(timer < 0.25)
        {
            hukidasi.color = Color.red;
        }

        return timer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("ばあ");
            touch = true;
        }
    }
}
