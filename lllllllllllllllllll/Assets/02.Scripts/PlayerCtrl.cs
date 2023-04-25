using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public float maxSpeed;
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public float atkSpeed = 1;
    public bool attacked = false;
    public Image nowHpbar;

    Rigidbody2D rb; //�����̵��� ���� ���� ���� 
    SpriteRenderer spriteRenderer;
    Animator animator;

    void AttackTrue()
    {
        attacked = true;
    }
    void AttackFalse()
    {
        attacked = false;
    }
    void SetAttackSpeed(float speed)
    {
        animator.SetFloat("attackSpeed", speed);
        atkSpeed = speed;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>(); //���� �ʱ�ȭ 

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
        
    }
    void Start()
    {
        maxHp = 50;
        nowHp = 50;
        atkDmg = 10;

        transform.position = new Vector3(0, -3, 0);
        animator = GetComponent<Animator>();
        SetAttackSpeed(1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;

        if (Input.GetButtonUp("Horizontal"))
        {
            rb.velocity = new Vector2(0.5f * rb.velocity.normalized.x, rb.velocity.y);
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
        

    
    
}
    // Start is called before the first frame update
    
}
