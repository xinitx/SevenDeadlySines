using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManage : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerManage instance;

   

    private bool bAttack = false;
    //--------------------------MOVEMENT--------------
    //�����ƶ�
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    private FixedJoystick joystick;
    [SerializeField] private float speed;��//���ٶ�
    private Vector2 movement;��

   //����ǻ�ȡˮƽ����ֱ�������ı���������
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
        //����
       
       /* movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");*/
        
        //������
        
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
    //�л�����
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
    //����
    //������ȴ
    private float timer = 0;
    private float delta = 1.6f;
    //��������
    [Header("FX")]
    public GameObject Attack;

    //������ˣ�����ȴ���ˡ��������﷽�򲥷Ź�������
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
    //�������ˡ���������ֻ��˵��Ҽ�
    public void buttonAttack()
    {
        bAttack = true;
    }
    //----------------------Transmit-----------------------
    //�ı��������꣬������
    public static void transmit(Transform mid)
    {
        instance.transform.position = mid.position;
    }
}
