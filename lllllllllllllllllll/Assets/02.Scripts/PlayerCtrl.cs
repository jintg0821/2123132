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

    Rigidbody2D rb; //물리이동을 위한 변수 선언 
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
        rb = GetComponent<Rigidbody2D>(); //변수 초기화 

    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rb.velocity.x > maxSpeed)  //오른쪽으로 이동 (+) , 최대 속력을 넘으면 
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y); //해당 오브젝트의 속력은 maxSpeed 

        //Max speed left
        else if (rb.velocity.x < maxSpeed * (-1)) // 왼쪽으로 이동 (-) 
            rb.velocity = new Vector2(maxSpeed * (-1), rb.velocity.y); //y값은 점프의 영향이므로 0으로 제한을 두면 안됨 

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
