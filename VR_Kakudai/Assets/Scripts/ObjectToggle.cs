using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ObjectToggle : MonoBehaviour
{
    public GameObject targetObject; // �\��/��\���ɂ���I�u�W�F�N�g
    private Vector3 originalScale; // �I�u�W�F�N�g�̌��̃X�P�[��
    private bool isRightClicking = false; // �E�N���b�N��������Ă��邩�ǂ���
    private Coroutine scaleCoroutine;

    void Start()
    {
        // �X�^�[�g���ɃI�u�W�F�N�g���\���ɂ��A���̃X�P�[�����L������
        if (targetObject != null)
        {
            targetObject.SetActive(false);
            originalScale = targetObject.transform.localScale;
        }
    }

    void Update()
    {
        bool wasRightClicking = isRightClicking;
        CheckRightClick();

        if (isRightClicking)
        {
            if (targetObject != null && !targetObject.activeSelf)
            {
                targetObject.SetActive(true);
                if (scaleCoroutine != null) StopCoroutine(scaleCoroutine);
                scaleCoroutine = StartCoroutine(ScaleObjectOverTime(Vector3.zero, originalScale, 0.1f));
            }

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == targetObject)
                {
                    // �I�u�W�F�N�g�Ƀ}�E�X���d�Ȃ��Ă���ꍇ
                    ScaleObject(1.2f); // �I�u�W�F�N�g��1.2�{�ɂ���
                }
                else
                {
                    // �I�u�W�F�N�g����}�E�X������Ă���ꍇ
                    ResetScale(); // �I�u�W�F�N�g�̃X�P�[�������ɖ߂�
                }
            }
            else
            {
                // �q�b�g�����I�u�W�F�N�g���Ȃ��ꍇ�����ɖ߂�
                ResetScale();
            }
        }
        else if (wasRightClicking && targetObject.activeSelf)
        {
            if (scaleCoroutine != null) StopCoroutine(scaleCoroutine);
            scaleCoroutine = StartCoroutine(ScaleObjectOverTime(targetObject.transform.localScale, Vector3.zero, 0.1f, () => targetObject.SetActive(false)));
        }
    }

    IEnumerator ScaleObjectOverTime(Vector3 fromScale, Vector3 toScale, float duration, System.Action onComplete = null)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            targetObject.transform.localScale = Vector3.Lerp(fromScale, toScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        targetObject.transform.localScale = toScale;
        onComplete?.Invoke();
    }

    void ScaleObject(float scaleMultiplier)
    {
        if (targetObject != null)
        {
            targetObject.transform.localScale = originalScale * scaleMultiplier; // �X�P�[����ύX����
        }
    }

    void ResetScale()
    {
        if (targetObject != null)
        {
            targetObject.transform.localScale = originalScale; // ���̃X�P�[���ɖ߂�
        }
    }

    void CheckRightClick()
    {
        bool rightMouseButton = Input.GetMouseButton(1); // �E�N���b�N�̓���
        bool rightStickButton = false; // �E�X�e�B�b�N�������݂̓���

        // XR�f�o�C�X�̓��͂��擾
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right, devices);

        foreach (var device in devices)
        {
            if (device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool stickClick))
            {
                rightStickButton = stickClick;
                break;
            }
        }

        isRightClicking = rightMouseButton || rightStickButton;
    }
}