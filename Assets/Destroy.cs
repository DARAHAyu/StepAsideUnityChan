using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // �J�����̃I�u�W�F�N�g
    private GameObject MainCamera;
    // carPrefab������
    public GameObject carPrefab;
    // coinPrefab������
    public GameObject coinPrefab;
    // cornPrefab������
    public GameObject conePrefab;

    // Start is called before the first frame update
    void Start()
    {
        // �J�����̃I�u�W�F�N�g���擾
        this.MainCamera = GameObject.Find("Main Camera");
    }
    // Update is called once per frame
    void Update()
    {
        // ��ʊO�ɏo���A�C�e����j������
        if(this.MainCamera.transform.position.z > this.transform.position.z)
        {
            Debug.Log("destory");
            Destroy(this.gameObject);
        }
    }


}
