using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generation : MonoBehaviour
{

    //��������Q�[���I�u�W�F�N�g
    public GameObject target;
    public Transform position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate( ��������I�u�W�F�N�g,  �ꏊ, ��] );  ��]�͂��̂܂܂Ȃ火
            Instantiate(target, this.transform.position, Quaternion.identity);
        }
    }
}
