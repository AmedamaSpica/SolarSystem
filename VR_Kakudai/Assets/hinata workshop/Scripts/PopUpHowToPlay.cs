using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
public class PopUpHowToPlay : MonoBehaviour
{
    [SerializeField] private Grabbable _grabbable; // Grabbable�I�u�W�F�N�g
    [SerializeField] private GameObject _panel; // �\���E��\���ɂ���p�l��
    [SerializeField] private Vector3 _offset = new Vector3(0, 0.2f, 0); // �p�l���̈ʒu�I�t�Z�b�g

    private Camera _mainCamera;

    private void Start()
    {
        // ���C���J�������擾
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        // �I�u�W�F�N�g�����܂ꂽ�Ƃ��̃C�x���g���X�i�[��ݒ�
        _grabbable.WhenPointerEventRaised += OnPointerEvent;
    }

    private void OnDisable()
    {
        // �C�x���g���X�i�[������
        _grabbable.WhenPointerEventRaised -= OnPointerEvent;
    }

    private void OnPointerEvent(PointerEvent evt)
    {
        if (evt.Type == PointerEventType.Select)
        {
            // �I�u�W�F�N�g�̏�Ƀp�l����z�u
            PositionPanelAboveObject();
            _panel.SetActive(true); // �p�l����\��
        }
        else if (evt.Type == PointerEventType.Unselect)
        {
            _panel.SetActive(false); // �p�l�����\��
        }
    }

    private void PositionPanelAboveObject()
    {
        // �O���u���ꂽ�I�u�W�F�N�g��Transform���擾
        Transform grabbedObjectTransform = _grabbable.transform;

        // �p�l���̈ʒu���I�u�W�F�N�g�̂���ɐݒ�
        _panel.transform.position = grabbedObjectTransform.position + _offset;

        // �p�l�����J�����̕��Ɍ�����
        _panel.transform.LookAt(_mainCamera.transform);

        // �p�l�������Ε����������ꍇ�́A180�x��]������
        _panel.transform.Rotate(0, 180, 0);
    }
}
