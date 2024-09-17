using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleTimer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float timerLimit;
    float seconds = 0f;

    //�ǉ��@Clock��Inspector�ォ��ݒ肷�邽��
    [SerializeField] TestClock testclock;

    void Start()
    {

    }

    void Update()
    {
        //�ύX�@Clock��UpdateClock�֐����Ăяo��
        //�@�@�@������_updateTimer()��timer�̒l
        testclock.UpdateClock(_updateTimer());
    }

    //�ύX�@void ����float
    float _updateTimer()
    {
        seconds += Time.deltaTime;
        float timer = seconds / timerLimit;

        //�ǉ��@float�^��timer��Ԃ�
        return timer;
    }
}
