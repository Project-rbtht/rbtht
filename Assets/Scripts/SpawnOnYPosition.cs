using UnityEngine;

public class SpawnOnYPosition : MonoBehaviour
{
    public float targetYPosition; // ���B���ׂ�y���W
    private bool hasSpawned = false; // ���łɏo���������ǂ����̃t���O

    void Start()
    {
        // �ŏ��ɃI�u�W�F�N�g���\���ɂ���
        gameObject.SetActive(false);
    }

    void Update()
    {
        // PlayerObject�̈ʒu���擾
        GameObject player = GameObject.FindWithTag("Player"); // PlayerObject�̃^�O���uPlayer�v�ł��邱�Ƃ�z��
        if (player != null)
        {
            // Player��y���W���w�肵��y���W�𒴂����ꍇ
            if (player.transform.position.y >= targetYPosition && !hasSpawned)
            {
                SpawnObject();
                hasSpawned = true; // �o���ς݂ɂ���
            }
        }
    }

    void SpawnObject()
    {
        // ���g���o��������
        gameObject.SetActive(true);
    }
}
