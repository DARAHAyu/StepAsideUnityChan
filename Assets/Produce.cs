using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Produce : MonoBehaviour
{
    // Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;
    // �J�����̃I�u�W�F�N�g
    private GameObject MainCamera;
    // carPrefab������
    public GameObject carPrefab;
    // coinPrefab������
    public GameObject coinPrefab;
    // cornPrefab������
    public GameObject conePrefab;
    // �A�C�e�����o���������͈̔�
    private float posRange = 3.4f;
    // Unity������40m��
    private float distance;
    // �Ō�ɃA�C�e���𐶐���������Unity������z���W
    private float lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        // �J�����̃I�u�W�F�N�g���擾
        this.MainCamera = GameObject.Find("Main Camera");
        // Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {

        // �Ō�ɐ��������A�C�e������15m�i�񂾎��ɁA�V���ȃA�C�e���𐶐�����
        if (this.unitychan.transform.position.z - this.lastPosition > 15)
            {
            Debug.Log("produce");
            // �ǂ̃A�C�e�����o���������_���ɐݒ�
            int num = Random.Range(1, 11);
            this.lastPosition = this.unitychan.transform.position.z;
            if (num <= 2)
            {
                    // �R�[�������������Ɉ꒼���ɐ���
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        Debug.Log("cone");
                        GameObject cone = Instantiate(conePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.unitychan.transform.position.z + 40);

                    }
            }
            else
            {
                // ���[�����ƂɃA�C�e���𐶐�
                for (int j = -1; j <= 1; j++)
                {
                    // �A�C�e���̎�ނ����߂�
                    int item = Random.Range(1, 11);
                    // �A�C�e����u���y���W�̃I�t�Z�b�g�������_���ɐݒ�
                    int offsetZ = Random.Range(-5, 6);
                    // 60%�R�C���ݒu�F30���Ԕz�u�F10�������Ȃ�
                    if (1 <= item && item <= 6)
                    {
                        // �R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.unitychan.transform.position.z + offsetZ + 40);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        // �Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.unitychan.transform.position.z + offsetZ + 40);
                    }
                }
            }
        }
    }
}
