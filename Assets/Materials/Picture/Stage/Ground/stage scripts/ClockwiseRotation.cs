using UnityEngine;

public class ClockwiseRotation : MonoBehaviour
{
    // 回転の中心点（例えば、時計の中心）
    public Transform pivotPoint;

    // 回転速度（度/秒）
    public float rotationSpeed = 30f;

    void Update()
    {
        // pivotPoint を中心として時計回りに回転する
        transform.RotateAround(pivotPoint.position, Vector3.forward, -rotationSpeed * Time.deltaTime);
    }
}
