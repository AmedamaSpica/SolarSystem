using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotation : MonoBehaviour
{

    [SerializeField] private GameObject MainCamera;


    void LateUpdate()
    {
        //�@�J�����Ɠ��������ɐݒ�
        transform.rotation = MainCamera.transform.rotation;
    }
}
