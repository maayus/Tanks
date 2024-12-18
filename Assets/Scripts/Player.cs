using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool isPlayer1 = true;

    [Header("Movement")]
    public float speed = 10.0f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public ParticleSystem ParticleSystem;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;

    [Header("Health")]
    public Health health;

    void Start()
    {
        InvokeRepeating("Shoot", 0.0f, fireRate);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        ParticleSystem.Play();
    }

    void Update()
    {
        var input = new Vector3();

        if (isPlayer1)
        {
            input.x = Input.GetAxis("HorizontalKeys");
            input.z = Input.GetAxis("VerticalKeys");
        }
        else
        {
            input.x = Input.GetAxis("HorizontalArrows");
            input.z = Input.GetAxis("VerticalArrows");
        }

        transform.position += input * speed * Time.deltaTime;

        if (input != Vector3.zero)
        {
            transform.forward = input;
        }
        if (health.health <= 0)
        {
            if (isPlayer1)
            {
                SceneManager.LoadScene("Blue");
            }
            else
            {
                SceneManager.LoadScene("Yellow");
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Health"))
        {
            health.TakeDamage(-10);
            Destroy(other.gameObject);
        }
    }
}
