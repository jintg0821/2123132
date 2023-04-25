using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 pos;
    float speed = 5;

   
    public int damage;
    public GameObject explosion;

    private Rigidbody2D rb;

    

    void DestroyBullet()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.tag == ("Enemy"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(Enemy.gameObject);
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        Invoke("DestroySelf", 2.0f);
        rb = GetComponent<Rigidbody2D>();
        // �Ѿ��� ���� �������� ��(Force)�� ���Ѵ�.

      
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
      
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
