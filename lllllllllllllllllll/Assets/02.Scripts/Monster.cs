using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    Rigidbody2D rigid;
    public int nextMove;//���� �ൿ��ǥ�� ������ ����
    Animator animator;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 5); // �ʱ�ȭ �Լ� �ȿ� �־ ����� �� ����(���� 1ȸ) nextMove������ �ʱ�ȭ �ǵ����� 

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y); //nextMove �� 0:���� -1:���� 1:������ ���� �̵� 


        //Platform check(�� ���� ���������� �ڵ��� ���ؼ� ������ Ž��)


        //�ڽ��� �� ĭ �� ������ Ž���ؾ��ϹǷ� position.x + nextMove(-1,1,0�̹Ƿ� ������)
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.4f, rigid.position.y);

        //��ĭ �� �κоƷ� ������ ray�� ��
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));

        //���̸� ���� ���� ������Ʈ�� Ž�� 
        RaycastHit2D raycast = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));

        //Ž���� ������Ʈ�� null : �� �տ� ������ ����
        if (raycast.collider == null)
        {
            Turn();
        }

    }


    void Think()
    {//���Ͱ� ������ �����ؼ� �Ǵ� (-1:�����̵� ,1:������ �̵� ,0:����  ���� 3���� �ൿ�� �Ǵ�)

        //Set Next Active
        //Random.Range : �ּ�<= ���� <�ִ� /������ ���� ���� ����(�ִ�� �����̹Ƿ� �����ؾ���)
        nextMove = Random.Range(-1, 2);

        //Sprite Animation
        //WalkSpeed������ nextMove�� �ʱ�ȭ 
        animator.SetInteger("WalkSpeed", nextMove);


        //Flip Sprite
        if (nextMove != 0) //������ �� ���� ������ �ٲ� �ʿ䰡 ���� 
            spriteRenderer.flipX = nextMove == 1; //nextmove �� 1�̸� ������ �ݴ�� ����  


        //Recursive (����Լ��� ���� �Ʒ��� ���°� �⺻��) 
        float time = Random.Range(2f, 5f); //�����ϴ� �ð��� �������� �ο� 
        //Think(); : ����Լ� : �����̸� ���� ������ CPU����ȭ �ǹǷ� ����Լ��� ���� �׻� ���� ->Think()�� ���� ȣ���ϴ� ��� Invoke()���
        Invoke("Think", time); //�Ű������� ���� �Լ��� time���� �����̸� �ο��Ͽ� ����� 
    }

    void Turn()
    {

        nextMove = nextMove * (-1); //�츮�� ���� ������ �ٲپ� �־����� Think�� ��� ���߾����
        spriteRenderer.flipX = nextMove == 1;

        CancelInvoke(); //think�� ��� ���� �� �����
        Invoke("Think", 2);//  

    }

}
