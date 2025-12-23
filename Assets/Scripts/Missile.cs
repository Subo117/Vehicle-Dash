using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] float missileSpeed = 10f;

    private void Update()
    {
        transform.position += Vector3.forward * missileSpeed;

        if (transform.position.z > 800) Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))

        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
