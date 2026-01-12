using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] float missileSpeed = 10f;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] ParticleSystem blastVFX;
    [SerializeField] AudioClip blastClip;

    private void Update()
    {
        transform.position += Vector3.forward * missileSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);

        if (transform.position.z > 800) Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))

        {
            ParticleSystem vfx = Instantiate(blastVFX, transform.position, Quaternion.identity);

            vfx.Play();
            MusicSettingManager.instance.PlaySound(blastClip);

            float totalTime = vfx.main.duration + vfx.main.startLifetime.constantMax;

            Destroy(vfx.gameObject, totalTime);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
