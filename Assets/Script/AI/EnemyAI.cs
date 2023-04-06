using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public LayerMask player;
    public LayerMask ground;
    public GameObject gun;
    public HPManager hPManager;
    public bool isdead;
    //寻敌半径
    public float findRange;
    public EnemyAttack enemyAttack;
    //-1==left,1=right
    public int trend;
    public float currentattackTime;
    //攻击半径
    public float attackRange;
    public float patrolTime;
    public float currentTime;
    public Animator enemyAni;
    public Rigidbody2D enemyRb;
    //stage=1:巡逻，stage=2:追击，stage=3:攻击
    public int stage;
    public bool isRun;

    //UTF-8环境编码
    void Awake()
    {
        enemyAni = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();
        currentTime = 0;
        trend = 1;
        isdead = false;
        hPManager = GetComponent<HPManager>();
    }
    void Update()
    {
        if (!hPManager.isdead)
        {
            ChangeStage();
            ActionByStage();
            ChangeAni();
        }
        else
        {

            enemyAni.SetBool("IsDead", true);
            enemyAttack.gunAni.SetBool("IsFire", false);

        }
    }


    void ChangeAni()
    {
        enemyAni.SetBool("IsRun", isRun);
    }
    void ActionByStage()
    {
        switch (stage)
        {
            case 1:
                {
                    Patrol();
                }
                break;
            case 2:
                {
                    Pursuit(GetAimObjectInCircle(transform.position, findRange));
                }
                break;
            case 3:
                {

                    Attack();
                }
                break;
        }
    }
    //巡逻
    void Patrol()
    {
        //巡逻时间内巡逻，其余时间静止
        if (currentTime < patrolTime)
        {
            transform.Translate(new Vector2(5, 0) * trend * Time.deltaTime, Space.World);
            isRun = true;
            if (IsChangeTrend())
            {
                trend = -trend;
                transform.localScale = new Vector3(trend, 1, 1);
            }


        }
        else if (currentTime < 1.2 * patrolTime)
        {
            isRun = false;
        }
        else
        {
            currentTime = 0;
            trend = -trend;
            transform.localScale = new Vector3(trend, 1, 1);
        }

        currentTime = currentTime + 0.02f;


    }
    //追击
    void Pursuit(GameObject player)
    {
        if (player != null)
        {
            Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, 0);
            transform.Translate(direction * 2 * Time.deltaTime, Space.World);
            if (direction.x < 0)
            { trend = -1; }
            else
            { trend = 1; }
            transform.localScale = new Vector3(trend, 1, 1);
            isRun = true;
        }
    }
    void Attack()
    {

        isRun = false;
        GameObject player = GetAimObjectInCircle(transform.position, attackRange + 1);
        if (player != null)
        {
            followPlayer(player);
            if (currentattackTime >= 0.4f)
            {
                enemyAttack.EnemyFire(player);
                currentattackTime = 0;
            }
            currentattackTime += 0.02f;

        }

    }
    public bool IsWall(Vector2 StartPos, Vector2 EndPos)
    {
        Vector2 direction = StartPos - EndPos;
        RaycastHit2D ray = Physics2D.Raycast(StartPos, direction, Vector2.Distance(StartPos, EndPos), ground);
        if (ray.collider != null)
        {
            return true;
        }
        else
            return false;


    }
    public void followPlayer(GameObject player)
    {


        Vector2 playPos = player.transform.position;
        if (playPos.x - this.gameObject.transform.position.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (playPos.x - this.gameObject.transform.position.x >= 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        float delta;
        float z;
        float distance = (playPos - new Vector2(gun.transform.position.x, gun.transform.position.y)).magnitude;
        delta = (playPos.y - gun.transform.position.y);
        z = Mathf.Asin(delta / distance) * 180 / Mathf.PI;
        if (playPos.x - this.gameObject.transform.position.x > 0)
        { gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, z)); }
        if (playPos.x - this.gameObject.transform.position.x <= 0)
        { gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -z)); }


    }
    bool IsChangeTrend()
    {
        Vector2 startPos = transform.position;
        Vector2 direction1 = new Vector2(0, -1);
        Vector2 direction2 = new Vector2(-trend, 0);
        //悬崖检测
        RaycastHit2D ray1 = Physics2D.Raycast(startPos, direction1, 10f, ground);
        //撞墙检测
        RaycastHit2D ray2 = Physics2D.Raycast(startPos, direction2, 1f, ground);
        if (ray1.collider != null)
        {
            if (ray2.collider == null)
            {
                return false;
            }
            else if (ray2.collider.tag == "Ground")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        else
        {
            return true;
        }


    }
    public GameObject GetAimObjectInCircle(Vector2 center, float radius)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(center, radius, player);
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.tag == "Body")
                { return colliders[i].gameObject; }

            }

        }

        return null;

    }
    void ChangeStage()
    {
        if (Physics2D.OverlapCircle(transform.position, findRange, player))
        {
            GameObject ObjinRange = GetAimObjectInCircle(transform.position, findRange);

            if (ObjinRange != null)
            {
                if (!IsWall(transform.position, ObjinRange.transform.position))
                {
                    GameObject ObjinAttack = null;
                    if (Physics2D.OverlapCircle(transform.position, attackRange, player))
                    {
                        ObjinAttack = GetAimObjectInCircle(transform.position, attackRange);
                    }

                    if (ObjinAttack != null)
                    {
                        stage = 3;
                    }
                    else
                    {
                        stage = 2;
                    }
                }
                else
                {
                    stage = 1;
                }
            }

        }
        else
        {
            stage = 1;
        }
    }
}
