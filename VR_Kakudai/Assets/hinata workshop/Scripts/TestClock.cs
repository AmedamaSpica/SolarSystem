using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestClock : MonoBehaviour
{
    // Start is called before the first frame update
    //�摜�R���|�[�l���g�p�ϐ���錾
    Image clockImage;

    private void Start()
    {
        //���g�̉摜�R���|�[�l���g���擾
        clockImage = GetComponent<Image>();
    }

    //fillAmount�̒l��ύX����֐��iClockTimer����Ă΂��j
    public void UpdateClock(float second)
    {
        //�󂯎����float�^�̒l��������
        clockImage.fillAmount = second;
    }
}
