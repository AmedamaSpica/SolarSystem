using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerRequest : MonoBehaviour
{

    //Inspector�Őݒ肵�Ăق����Ƃ���
    [SerializeField] private GameObject[] RequestDishes;//�����̎��
    [SerializeField] private Sprite[] DishesSprits;//�����̉摜
    [SerializeField] private Sprite[] SizeSpecificationSprits;//�傫���w��̉摜
    [SerializeField] private Image DishesImage;//�����̉摜���f���ꏊ�̐ݒ�
    [SerializeField] private Image SizeImage;//�傫���̉摜���f���ꏊ�̐ݒ�

    private int DishesSpriteValue; private int DishesSpriteValueMin; private int DishesSpriteValueMax;
    private int SizeSpecificationSpriteValue; private int SizeSpecificationSpriteValueMin; private int SizeSpecificationSpriteValueMax;


    // Start is called before the first frame update
    void Start()
    {
        //���������̏���Ɖ�����ݒ�
        DishesSpriteValueMin = 0;
        DishesSpriteValueMax = RequestDishes.Length;
        SizeSpecificationSpriteValueMin = 0;
        SizeSpecificationSpriteValueMax = SizeSpecificationSprits.Length;

        //���������ŗ����Ƒ傫��������
        DishesSpriteValue = Random.Range(DishesSpriteValueMin, DishesSpriteValueMax);
        DishesImage.sprite = DishesSprits[DishesSpriteValue];
        SizeSpecificationSpriteValue = Random.Range(SizeSpecificationSpriteValueMin, SizeSpecificationSpriteValueMax);
        SizeImage.sprite = SizeSpecificationSprits[SizeSpecificationSpriteValue];

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider colliderDishes)
    {

        //���������I�u�W�F�N�g�𔻒�
        if (colliderDishes.tag == RequestDishes[DishesSpriteValue].tag)//�����̎�ނ�tag�Ŕ���
        {

            if (SizeSpecificationSpriteValue < colliderDishes.transform.localScale.x)//�����̑傫����Scale.x�Ŕ���
            {
                Destroy(colliderDishes.gameObject);
            }
        }
    }
}
