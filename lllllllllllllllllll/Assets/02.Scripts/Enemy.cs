using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float health = 50.0f;
    public GameObject expEffect;
    private Rigidbody2D rb;
    private Transform tr;

    public float Health
    {
        get
        {
            return health;
        }
    }

    void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            die();
        }
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
            Debug.Log("health :" + health);
            coll.gameObject.SetActive(false);
            if (coll.collider.CompareTag("BULLET"))
            {
                // �Ѿ� ���� Ƚ���� ������Ű�� 3ȸ �̻��̸� ���� ó��
                if (++hitCount == 3)
                {
                    ExpEnemy();
                }
            }
        }
        // �巳���� ���߽�ų �Լ�
        void ExpEnemy()
        {
            // ���� ȿ�� ��ƼŬ ����
            GameObject exp = Instantiate(expEffect, tr.position, Quaternion.identity);
            // ���� ȿ�� ��ƼŬ 1�� �Ŀ� ����
            Destroy(exp, 1.0f);
            // Rigidbody ������Ʈ�� mass�� 1.0���� ������ ���Ը� ������ ��
            rb.mass = 1.0f;
            // ���� �ڱ�ġ�� ���� ����
            rb.AddForce(Vector3.up * 1500.0f);
            // 3�� �Ŀ� �巳�� ����
            Destroy(gameObject, 3.0f);
        }
    }

    void die()
    {
        Destroy(this.gameObject);
    }

    
    // �Ѿ� ���� Ƚ���� ������ų ����
    private int hitCount = 0;

    

    public float height = 1.7f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(16, -2, 0);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
