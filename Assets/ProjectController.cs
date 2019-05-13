using UnityEngine;

public class ProjectController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 15f;
    private Rigidbody rb;
    private int floorLayerMask;
    private const float maxDistance = 1000f;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        floorLayerMask = LayerMask.GetMask("Floor");
    }

    private void FixedUpdate()
    {
        Move();
        Turning();
    }

    public void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        var direction = new Vector3(h, 0.0f, v);
        direction.Normalize();

        var deltaPos = direction * speed * Time.deltaTime;
        var nextPos = transform.position + deltaPos;

        rb.MovePosition(nextPos);
    }

    public void Turning()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit, maxDistance, floorLayerMask))
            return;

        Vector3 playerToMouse = hit.point - transform.position;
        playerToMouse.y = 0f;
        Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);
        rb.MoveRotation(newRotatation);
    }
}

