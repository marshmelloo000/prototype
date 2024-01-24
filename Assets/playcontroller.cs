using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playcontroller : MonoBehaviour
{
    public float speed;
    public float jumpForce; //jumpforce��Ϊ��������ߵı���
    private float moveInput;//���������ƶ��ı��������GetAxis("Horizontal")ʹ��

    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;          //extrajumpΪ�������Ĵ���
    public int extraJumpsValue;     //extrajumpsvalueΪԤ�����

    // Start is called before the first frame update
    void Start()
    {

        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }




        if (Input.GetKeyDown(KeyCode.Space) && extraJumps >0 )
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }else if(Input.GetKeyDown(KeyCode.Space) && extraJumps ==0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

    }

    void FixedUpdate()                                    //fixedupdate 0.02sִ��һ�Σ���������صĲ�������д����
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed,rb.velocity.y);
    }
}
