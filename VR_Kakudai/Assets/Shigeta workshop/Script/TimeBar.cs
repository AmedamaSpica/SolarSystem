using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    //�ő�HP�ƌ��݂�HP�B
    int maxtime = 100;
    int currenttime;
    //Slider������
    public Slider slider;

    int damage = 10;

    float seconds;

    void Start()
    {
        //Slider�𖞃^���ɂ���B
        slider.value = 1;
        //���݂�HP���ő�HP�Ɠ����ɁB
        currenttime = maxtime;
        Debug.Log("Start currentHp : " + currenttime);
    }

    //Collider�I�u�W�F�N�g��IsTrigger�Ƀ`�F�b�N����邱�ƁB
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 1)
        {
            seconds = 0;

            Debug.Log("damage : " + damage);

            //���݂�HP����_���[�W������
            currenttime = currenttime - damage;
            Debug.Log("After currentHp : " + currenttime);

            if (currenttime <= 0)
            {
                currenttime = maxtime;
            }

            //�ő�HP�ɂ����錻�݂�HP��Slider�ɔ��f�B
            //int���m�̊���Z�͏����_�ȉ���0�ɂȂ�̂ŁA
            //(float)������float�̕ϐ��Ƃ��ĐU���킹��B
            slider.value = (float)currenttime / (float)maxtime;
        }

    }
}
