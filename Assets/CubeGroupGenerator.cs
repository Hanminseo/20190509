using UnityEngine;

public class CubeGroupGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 position = new Vector3(10.0f, 0.0f, 0.0f);
    public Vector3 count = new Vector3(10f, 10f, 10f);

    public void Awake()
    {
        Generator(count, position);
    }

    private static void Generator(Vector3 count, Vector3 position)
    {
        var layer = LayerMask.NameToLayer("Shootable");
        Transform parent = new GameObject().transform;
        GameObject newCube = null;
        for (int x = 0; x < count.x; x++)
        {
            for (int y = 0; y < count.y; ++y)
            {
                for (int z = 0; z < count.z; ++z)
                {
                    newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    newCube.transform.position = new Vector3(x, y, z);
                    newCube.name = string.Format("Cube ({0}, {1}, {2})", x, y, z);
                    newCube.AddComponent<Rigidbody>();
                    newCube.transform.SetParent(parent);
                    newCube.layer = layer;
                }
            }
        }
        parent.name = string.Format("Cube gruops :{0}x{1}x{2}", count.x, count.y, count.z);
        parent.position = position;
        parent.gameObject.layer = layer;
    }
}


   
