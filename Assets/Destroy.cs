using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // カメラのオブジェクト
    private GameObject MainCamera;
    // carPrefabを入れる
    public GameObject carPrefab;
    // coinPrefabを入れる
    public GameObject coinPrefab;
    // cornPrefabを入れる
    public GameObject conePrefab;

    // Start is called before the first frame update
    void Start()
    {
        // カメラのオブジェクトを取得
        this.MainCamera = GameObject.Find("Main Camera");
    }
    // Update is called once per frame
    void Update()
    {
        // 画面外に出たアイテムを破棄する
        if(this.MainCamera.transform.position.z > this.transform.position.z)
        {
            Debug.Log("destory");
            Destroy(this.gameObject);
        }
    }


}
