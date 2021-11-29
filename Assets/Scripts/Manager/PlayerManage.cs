using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManage : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerManage instance;

   

    private bool bAttack = false;
    //--------------------------MOVEMENT--------------
    //人物移动
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    private FixedJoystick joystick;
    [SerializeField] private float speed;　//　速度
    private Vector2 movement;　

   //大概是获取水平、竖直按键，改变人物坐标
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;

        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        joystick = FindObjectOfType<FixedJoystick>();
    }

    // Update is called once per frame

    private void Update()
    {
        if(Time.timeScale != 0)
        {
            Move();
            attack();
            SwitchAnim();
        }
    }
    void Move()
    {
        //键盘
       
       /* movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");*/
        
        //操作杆
        
        if (joystick.Horizontal > 0.1)
            movement.x = 1;
        else if (joystick.Horizontal < -0.1)
            movement.x = -1;
        else
            movement.x = 0;
        if (joystick.Vertical > 0.1)
            movement.y = 1;
        else if (joystick.Vertical < -0.1)
            movement.y = -1;
        else
            movement.y = 0;
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
    //切换动画
    void SwitchAnim()
    {
        if (movement != Vector2.zero)
        {
            anim.SetFloat("horizontal", movement.x);
            anim.SetFloat("vertical", movement.y);
        }
        anim.SetFloat("speed", movement.magnitude);
    }
    //----------------------ATTACK-----------------------
    //攻击
    //攻击冷却
    private float timer = 0;
    private float delta = 1.6f;
    //攻击动画
    [Header("FX")]
    public GameObject Attack;

    //如果按了Ｋ且冷却好了　根据人物方向播放攻击动画
    void attack()
    {
        if (Input.GetKeyDown(KeyCode.K) && (Time.time >= timer + delta || timer == 0) || bAttack)
        {
            if (instance.anim.GetFloat("horizontal") == -1)
            {
                instance.Attack.transform.position = instance.transform.position + new Vector3(-1, -0.3f, 0);
                instance.Attack.transform.rotation = Quaternion.Euler(0, 180, 0);
                instance.Attack.SetActive(true);
            }
            else if (instance.anim.GetFloat("vertical") == 1)
            {
                instance.Attack.transform.position = instance.transform.position + new Vector3(0, 1, 0);
                instance.Attack.transform.rotation = Quaternion.Euler(0, 0, 90);
                instance.Attack.SetActive(true);
            }
            else if (instance.anim.GetFloat("vertical") == -1)
            {
                instance.Attack.transform.position = instance.transform.position + new Vector3(0, -1, 0);
                instance.Attack.transform.rotation = Quaternion.Euler(0, 0, -90);
                instance.Attack.SetActive(true);
            }
            else if (instance.anim.GetFloat("horizontal") == 1)
            {
                instance.Attack.transform.position = instance.transform.position + new Vector3(1, -0.3f, 0);
                instance.Attack.transform.rotation = Quaternion.Euler(0, 0, 0);
                instance.Attack.SetActive(true);
            }
            instance.timer = Time.time;
            bAttack = false;
        }
    }
    //　按下了　ｋ键　即手机端的右键
    public void buttonAttack()
    {
        bAttack = true;
    }
    //----------------------Transmit-----------------------
    //改变人物坐标，传送用
    public static void transmit(Transform mid)
    {
        instance.transform.position = mid.position;
    }
}
