using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int shootTime;
    private int maxAmmo;
    private float reloadTime;
    public DamageManager damageManager;
    public Animator gunAni;
    public SoundManager soundManager;
    public GetGunData GunData;
    public GameObject GunMuzzle;
    public GameObject GunStock;
    public bool isReload;
    public float attack;
    public bool IsFire;
    public float originOffset;
    public float currentOffset;
    public float currentreloadTime;
    public int bulletNumber;
    public Material GunFireLine;
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject GunPng;
    public LayerMask enemy;
    public GameObject AttackEffect;
    public void Start()
    {
        maxAmmo = GunData.ammoCap;
        attack = GunData.attack;
        reloadTime = GunData.reloadSpeed;
        originOffset = GunData.originOffset;
        currentOffset = originOffset;
        bulletNumber = GunData.bulletNumber;
        rightHand.transform.localPosition = GunData.R_handPos;
        leftHand.transform.localPosition = GunData.L_handPos;
        GunMuzzle.transform.localPosition = GunData.GunMuzzlePos;
        GunPng.GetComponent<SpriteRenderer>().sprite = GunData.GunPng;
        GunPng.transform.localPosition = GunData.PngOffset;
        shootTime = 0;
    }
    public void FixedUpdate()
    {
        if (isReload)
        {
            currentreloadTime += 0.02f;
            if (currentreloadTime >= reloadTime)
            {
                isReload = false;
                shootTime = 0;
                currentreloadTime = 0;
            }
        }


    }
    public void EnemyFire(GameObject gameObject)
    {


        if (shootTime >= maxAmmo)
        {
            isReload = true;
            IsFire = false;
        }
        else
        {
            shootTime++;
            IsFire = true;
            soundManager.PlayFire();
            for (int i = 0; i < bulletNumber; i++)
            {
                Vector2 startPos = GunMuzzle.transform.position;
                float randomOffset = Random.Range(-currentOffset, currentOffset);
                Vector2 endPos = new Vector2(GunStock.transform.position.x, GunStock.transform.position.y + randomOffset);
                Vector2 direction = startPos - endPos;
                RaycastHit2D ray = Physics2D.Raycast(startPos, direction, 100f, enemy);
                endPos = gameObject.transform.position;
                GameObject effect = Instantiate(AttackEffect, endPos, Quaternion.identity);
                Destroy(effect, 0.25f);
                LineRenderer lineRenderer = CreateLine(startPos, endPos);
                damageManager.Damage(attack, damageManager.FindGameObject(gameObject), gameObject);
                Destroy(lineRenderer.gameObject, 1);

            }
        }
        ChangeAnimation();
    }
    public LineRenderer CreateLine(Vector2 startPos, Vector2 endPos)
    {
        GameObject lineObject = new GameObject("Line");
        lineObject.transform.position = Vector3.zero;
        lineObject.transform.rotation = Quaternion.identity;
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.startColor = new Color(1, 1, 0.5f, 1);
        lineRenderer.endColor = new Color(1, 1, 0.5f, 1);
        lineRenderer.material = GunFireLine;
        // 设置顶点位置
        Vector3[] positions = new Vector3[2];
        positions[0] = new Vector3(startPos.x, startPos.y, 0);
        positions[1] = new Vector3(endPos.x, endPos.y, 0);
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(positions);
        return lineRenderer;
    }
    public void ChangeAnimation()
    {
        if (IsFire)
        {
            gunAni.speed = 0.4f;
            gunAni.SetBool("IsFire", true);
            gunAni.SetBool("IsReload", false);
        }
        else
        if (isReload)
        {
            gunAni.speed = 2f / reloadTime;
            gunAni.SetBool("IsFire", false);
            gunAni.SetBool("IsReload", true);

        }
        else
        {
            gunAni.speed = 1;
            gunAni.SetBool("IsFire", false);
            gunAni.SetBool("IsReload", false);

        }
    }


}
