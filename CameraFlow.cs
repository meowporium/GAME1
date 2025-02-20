using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target; 

    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0, 2, -5); 

    private void Start()
    {
        target = GameObject.Find("Player").transform; 
    }

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}

