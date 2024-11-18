using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;

    public Image bar;

    public UnityEvent onDeath;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(0, health);

        bar.transform.localScale = new Vector3((float)health / maxHealth, 1, 1);

        if (health <= 0)
        {
            onDeath.Invoke();
        }
    }
}
