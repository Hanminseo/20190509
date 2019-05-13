using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public float speed = 5f;
    private Vector3 offset;

    public void Awake()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    public void Update()
    {
        var goalPos = target.position + offset;
        var nextPos = Vector3.Lerp(transform.position, goalPos, speed * Time.deltaTime);
        transform.position = nextPos;
    }
}
