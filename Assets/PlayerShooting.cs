using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform gunBarrelEnd;
    private LineRenderer gunLine;
    private Light gunLight;

    public float power = 10000f;
    public float range = 100f;
    public float timeBetweenBullets = 0.15f;
    public float effectsDisplayTime = 0.05f;
    private Ray ray = new Ray();
    private RaycastHit hit;
    private float timer = 0f;

    public void Awake()
    {
        gunLine = GetComponentInChildren<LineRenderer>();
        gunLight = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    public void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer > timeBetweenBullets)
        {
            timer = 0f;
            Shoot();
        }
        if (timer > effectsDisplayTime)
            DisableEffects();
    }
    private void Shoot()
    {
        gunLine.SetPosition(0, gunBarrelEnd.position);

        ray.origin = gunBarrelEnd.position;
        ray.direction = gunBarrelEnd.forward;

        if (Physics.Raycast(ray, out hit, range))
        {
            gunLine.SetPosition(1, hit.point);
            if (hit.collider != null)
            {
                var rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.AddForce(gunBarrelEnd.forward * power);
            }
        }
        else
        {
            var goalPosition = gunBarrelEnd.position + (gunBarrelEnd.forward * range);
            gunLine.SetPosition(1, goalPosition);
        }
        EnableEffects();
    }

    private void EnableEffects()
    {
        gunLine.enabled = true;
        gunLight.enabled = true;
    }

    private void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }
}
