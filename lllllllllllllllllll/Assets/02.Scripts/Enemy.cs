using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    float health = 50.0f;
    public GameObject expEffect;
    private Rigidbody2D rb;
    private Transform tr;
    public GameObject effectPrefab; // 이펙트 프리팹
    

    public float Health
    {
        get
        {
            return health;

        }
        set
        {
            health = value;
        }
    }

    public void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            die();
        }
    }

    public void AddEffect(Vector3 position)
    {
        GameObject effect = Instantiate(effectPrefab, position, Quaternion.identity);
        Destroy(effect, 1.0f); // 1초 후에 이펙트 삭제
    }

    public float GetHealth()
    {
        return health;
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("BULLET"))
        {
            TakeDamage(10);
            Debug.Log("$health값 : { health}");
            coll.gameObject.SetActive(false);
            
                
        }


       
    }

    void die()
    {
        Destroy(this.gameObject);
    }

    
    
    

    public float height = 1.7f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(16, -2, 0);
        Debug.Log($"health값 : {health}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
