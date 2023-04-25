using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    public float maxSpeed; 
    public float BulletSpeed;
    public GameObject BulletPrefab;
    public float speed = 0.1f;
    public string transferMapName;
    public float jumpPower;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public AudioClip jumpSfx;
    public AudioClip fireSfx;

    int health = 100;

    private new AudioSource audio;
    Rigidbody2D rb; //�����̵��� ���� ���� ���� 
   

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rb.velocity.x > maxSpeed)  //���������� �̵� (+) , �ִ� �ӷ��� ������ 
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y); //�ش� ������Ʈ�� �ӷ��� maxSpeed 

        //Max speed left
        else if (rb.velocity.x < maxSpeed * (-1)) // �������� �̵� (-) 
            rb.velocity = new Vector2(maxSpeed * (-1), rb.velocity.y); //y���� ������ �����̹Ƿ� 0���� ������ �θ� �ȵ� 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
            Destroy(collision.gameObject);

            if (collision.gameObject.CompareTag("portal"))
            {
                SceneManager.LoadScene("transferMapName");
            }
        }
    }

   
    void Start()
    {
        transform.position = new Vector3(1, -2, 0);
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
        {

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, speed, 0);
            audio.PlayOneShot(jumpSfx, 1.0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, -speed, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(speed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 1; i++)
            {
                GameObject Bullet = Instantiate(BulletPrefab);
                Vector3 bulletPos = transform.position;
                bulletPos.x += 0.3f * i;
                Bullet.transform.position = bulletPos;
                Bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * BulletSpeed);
                audio.PlayOneShot(fireSfx, 1.0f);





            }
            // Start is called before the first frame update

        }
    }
    
}

