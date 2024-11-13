using UnityEngine;

public class ClockwiseRotation : MonoBehaviour
{
    // ��]�̒��S�_�i�Ⴆ�΁A���v�̒��S�j
    public Transform pivotPoint;

    // ��]���x�i�x/�b�j
    public float rotationSpeed = 30f;

    void Update()
    {
        // pivotPoint �𒆐S�Ƃ��Ď��v���ɉ�]����
        transform.RotateAround(pivotPoint.position, Vector3.forward, -rotationSpeed * Time.deltaTime);
    }
}
