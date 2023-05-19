using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Produce : MonoBehaviour
{
    // Unityちゃんのオブジェクト
    private GameObject unitychan;
    // カメラのオブジェクト
    private GameObject MainCamera;
    // carPrefabを入れる
    public GameObject carPrefab;
    // coinPrefabを入れる
    public GameObject coinPrefab;
    // cornPrefabを入れる
    public GameObject conePrefab;
    // アイテムを出すｘ方向の範囲
    private float posRange = 3.4f;
    // Unityちゃんの40m先
    private float distance;
    // 最後にアイテムを生成した時のUnityちゃんのz座標
    private float lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        // カメラのオブジェクトを取得
        this.MainCamera = GameObject.Find("Main Camera");
        // Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {

        // 最後に生成したアイテムから15m進んだ時に、新たなアイテムを生成する
        if (this.unitychan.transform.position.z - this.lastPosition > 15)
            {
            Debug.Log("produce");
            // どのアイテムを出すかランダムに設定
            int num = Random.Range(1, 11);
            this.lastPosition = this.unitychan.transform.position.z;
            if (num <= 2)
            {
                    // コーンをｘ軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        Debug.Log("cone");
                        GameObject cone = Instantiate(conePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.unitychan.transform.position.z + 40);

                    }
            }
            else
            {
                // レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    // アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    // アイテムを置くＺ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    // 60%コイン設置：30％車配置：10％何もなし
                    if (1 <= item && item <= 6)
                    {
                        // コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.unitychan.transform.position.z + offsetZ + 40);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        // 車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.unitychan.transform.position.z + offsetZ + 40);
                    }
                }
            }
        }
    }
}
