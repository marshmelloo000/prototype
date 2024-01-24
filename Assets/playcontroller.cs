using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playcontroller : MonoBehaviour
{
    public float speed;
    public float jumpForce; //jumpforce即为决定跳多高的变量
    private float moveInput;//决定左右移动的变量，配合GetAxis("Horizontal")使用

    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;          //extrajump为额外跳的次数
    public int extraJumpsValue;     //extrajumpsvalue为预设次数

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

    void FixedUpdate()                                    //fixedupdate 0.02s执行一次，与物理相关的操作代码写里面
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed,rb.velocity.y);
    }
}
