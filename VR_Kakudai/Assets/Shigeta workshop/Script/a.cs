using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // parent �̐���
        var parent = new GameObject("Parent").transform;
        // child �̐���
        var child = new GameObject("Child").transform;
        // parent �� child �̐e�ɐݒ�
        child.SetParent(parent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
