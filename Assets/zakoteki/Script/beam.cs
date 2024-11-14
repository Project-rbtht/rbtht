using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Inspector�Őݒ�\�ɂ��邽�߂�public�ɂ���
    public GameObject objectToSpawn; // ��������I�u�W�F�N�g
    public float spawnInterval = 5f; // �I�u�W�F�N�g�𐶐�����Ԋu�i�b�j
    public Vector3 spawnPosition;    // �����ʒu

    void Start()
    {
        // �R���[�`�����J�n���āA�w�肵���Ԋu�ŃI�u�W�F�N�g�𐶐�
        StartCoroutine(SpawnObjectWithInterval());
    }

    // �w�肵���Ԋu�ŃI�u�W�F�N�g�𐶐�����R���[�`��
    private System.Collections.IEnumerator SpawnObjectWithInterval()
    {
        while (true)
        {
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity); // �I�u�W�F�N�g�𐶐�
            yield return new WaitForSeconds(spawnInterval); // �w�肵���Ԋu�ҋ@
        }
    }
}
