using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public GetRoleData characterData;
    public AnimationCurve curve;
    public LayerMask Ground;
    public GameObject PlayerHead;
    public GameObject playerFeet;
    public float JumpForce;
    public float JumpTime;
    public int JumpCount = 1;
    public GameObject gun;
    public Vector2 mpoint;
    public float delta;
    public float speed;
    public bool IsSquats = false;
    public int stage = 0;
    public float z;
    void Start()
    {
        speed = characterData.speed;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        float currentSpeed = speed;

        Animator animator = GetComponent<Animator>();
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, Vertical);
        // 判断是否有输入，如果有则播放 Run 动画，否则播放 Idle 动画
        //判断方向，更改角色方向
        followMouse();
        ChangeWay(movement);
        if (Physics2D.OverlapCircle(playerFeet.transform.position, 1f, Ground) && JumpCount < 1)
        {
            JumpCount++;
            animator.SetBool("IsJump", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount > 0)
        {
            JumpCount--;
            animator.SetBool("IsJump", true);
            Jump();
        }

        if (Input.GetKey(KeyCode.S))
        {
            IsSquats = true;
            animator.SetBool("IsSquats", true);

        }
        else if (!Physics2D.OverlapCircle(PlayerHead.transform.position, 3f, Ground))
        {
            IsSquats = false;
            animator.SetBool("IsSquats", false);

        }
        if (movement.x != 0)
        {
            if (!IsSquats)
            {
                animator.SetBool("IsRun", true);
            }
            else
            {
                animator.SetBool("IsSquatsWolk", true);
            }
        }
        else
        {
            animator.SetBool("IsRun", false);
            animator.SetBool("IsSquatsWolk", false);
        }
        if (IsSquats)
        {
            currentSpeed = currentSpeed * 0.7f;

        }

        // 移动角色
        transform.Translate(new Vector2(movement.x * currentSpeed * Time.deltaTime, 0), Space.World);
        // 播放跳跃动画


    }
    void Jump()
    {
        StartCoroutine(StartCurve());
        IEnumerator StartCurve()
        {
            float time = 0;
            Rigidbody2D playerRig = this.gameObject.GetComponent<Rigidbody2D>();
            while (time <= JumpTime)
            {
                float normalizedTime = (time / JumpTime);
                time += Time.deltaTime;
                float curveValue = curve.Evaluate(normalizedTime);
                playerRig.velocity = new Vector2(playerRig.velocity.x, JumpForce * curveValue);
                yield return null;
            }
        }
    }
    void followMouse()
    {
        Camera camera = Camera.main;
        mpoint = Input.mousePosition;
        mpoint = camera.ScreenToWorldPoint(mpoint);
        float distance = (mpoint - new Vector2(gun.transform.position.x, gun.transform.position.y)).magnitude;
        delta = (mpoint.y - gun.transform.position.y);
        z = Mathf.Asin(delta / distance) * 180 / Mathf.PI;
        if (mpoint.x - this.gameObject.transform.position.x > 0)
        { gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, z)); }
        if (mpoint.x - this.gameObject.transform.position.x <= 0)
        { gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -z)); }


    }
    void ChangeWay(Vector2 movement)
    {
        Vector2 mousepos = Input.mousePosition;
        Camera main = Camera.main;
        mousepos = main.ScreenToWorldPoint(mousepos);
        if (mousepos.x - this.gameObject.transform.position.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (mousepos.x - this.gameObject.transform.position.x >= 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
