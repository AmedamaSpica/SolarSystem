using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    int maxtime = 100;
    int currenttime;
    public Slider slider;

    int damage = 10;

    bool touch = false;

    float seconds;

    void Start()
    {
        //Slider�R���|�[�l���g�������I�Ɏ擾
        if (slider == null)
        {
            slider = GetComponentInChildren<Slider>();
        }

        //Slider�𖞃^���ɂ���
        slider.value = 1;
        //���݂̎��Ԃ��ő厞�ԂƓ����ɂ���
        currenttime = maxtime;
        
    }

    void Update()
    {
        if (touch)
        {
            seconds += Time.deltaTime;
            if (seconds >= 1)
            {
                seconds = 0;

                

                //���݂̎��Ԃ���_���[�W������
                currenttime -= damage;
                

                if (currenttime <= 0)
                {
                    currenttime = maxtime;
                }

                //�ő厞�Ԃɂ����錻�݂̎��Ԃ�Slider�ɔ��f
                slider.value = (float)currenttime / (float)maxtime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("�΂�");
            touch = true;
        }
    }
}
