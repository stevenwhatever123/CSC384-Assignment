using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    public float radius = 5f;

    private float initialRadius = 0f;

    public float timeAllowed = 2f;

    public float counter;

    public CircleCollider2D collider2D;

    private Circle circleGenerator;

    public bool active = false;

    private EnemyScript enemy;
    
    void Awake()
    {
        circleGenerator = GameObject.Find("CircleGenerator").GetComponent<Circle>();
        collider2D = GetComponent<CircleCollider2D>();
        collider2D.radius = 0;
    }
    
    void Update()
    {
        if (active)
        {
            collider2D.enabled = true;
            if (counter <= timeAllowed)
            {
                collider2D.radius += radius/2 * Time.deltaTime;
            }
            else
            {
                Destroy(this.gameObject);
            }

            counter += Time.deltaTime;
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Ghost"))
        {
            enemy = other.gameObject.GetComponent<EnemyScript>();
            enemy.Eaten();
        }
    }

    public void setWaveActive(bool b)
    {
        active = b;
        circleGenerator.setCollider(collider2D);
    }
}
