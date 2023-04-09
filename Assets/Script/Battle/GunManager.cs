using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class GunManager : MonoBehaviour
{
    [Header("GunData")]
    private float FireTime;
    public UIManager uIManager;
    public SoundManager soundManager;
    private int maxAmmo;
    private int currentAmmo;
    private int reserveAmmo;
    private int maxReserveAmmo;
    private float reloadTime;
    public DamageManager damageManager;
    public Animator GunFire;
    public Animator gunAni;
    public GetGunData GunData;
    public GameObject GunMuzzle;
    public GameObject GunStock;
    public bool isReload;
    public float originOffset;
    public float currentOffset;
    public float recoil;
    public float recoilRecover;
    public int bulletNumber;
    public Material GunFireLine;
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject GunPng;
    public float currentTime;
    public LayerMask enemy;
    public GameObject AttackEffect;
    public void Start()
    {
        Init();
    }
    public void FixedUpdate()
    {
        ChangeAnimation();

        if (isReload && currentTime >= reloadTime && reserveAmmo > 0)
        {
            if (reserveAmmo > maxAmmo)
            {
                reserveAmmo -= maxAmmo - currentAmmo;
                currentAmmo = maxAmmo;

            }
            else
            {
                currentAmmo = reserveAmmo;
                reserveAmmo = 0;
            }
            uIManager.ChangeAmmo(currentAmmo, reserveAmmo);
            isReload = false;
        }
        if (Input.GetKey(KeyCode.R) && currentAmmo < maxAmmo && !isReload && reserveAmmo >= 0)
        {
            isReload = true;
            currentTime = 0;
        }
        if (Input.GetButton("Fire1") && !isReload)
        {
            if (currentAmmo > 0)
            {
                if (currentTime >= FireTime)
                {

                    Fire();
                    gunAni.SetBool("IsFire", true);
                    gunAni.speed = 0.1f / FireTime;
                    if (currentOffset < originOffset * 2)
                    { currentOffset += recoil; }
                    currentTime = 0;
                    soundManager.PlayFire();
                    currentAmmo--;
                    uIManager.ChangeAmmo(currentAmmo, reserveAmmo);
                }

            }
            else
            {
                isReload = true;
                currentTime = 0;
            }
        }
        else
        {
            if (currentOffset > originOffset)
            {
                currentOffset -= recoilRecover;
            }
        }

        currentTime += 0.02f;
    }
    public void Fire()
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            Vector2 startPos = GunMuzzle.transform.position;
            float randomOffset = Random.Range(-currentOffset, currentOffset);
            Vector2 endPos = new Vector2(GunStock.transform.position.x, GunStock.transform.position.y + randomOffset);
            Vector2 direction = startPos - endPos;
            RaycastHit2D ray = Physics2D.Raycast(startPos, direction, 100f, enemy);
            if (ray.collider != null)
            {
                if (ray.collider != null)
                {
                    GameObject target = damageManager.FindGameObject(ray.collider.gameObject);
                    if (target.tag == "Enemy")
                    {
                        damageManager.Damage(GunData.attack, target, ray.collider.gameObject);
                    }
                    endPos = ray.point;
                    GameObject effect = Instantiate(AttackEffect, endPos, Quaternion.identity);
                    Destroy(effect, 0.25f);

                }
            }
            else
            {
                endPos = startPos + direction * 10f;
            }
            LineRenderer lineRenderer = CreateLine(startPos, endPos);

            Destroy(lineRenderer.gameObject, 1);
        }

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
        gunAni.SetBool("IsFire", false);
        if (Input.GetButton("Fire1") && !isReload)
        {
            GunFire.speed = 0.5f;
            GunFire.SetBool("Fire", true);

        }
        else
        {
            GunFire.speed = 1f;
            GunFire.SetBool("Fire", false);
        }
        if (isReload)
        {
            gunAni.speed = 2.0f / reloadTime;
            gunAni.SetBool("IsReload", true);
        }
        else
        {
            gunAni.speed = 1f;
            gunAni.SetBool("IsReload", false);
        }
    }
    private void Init()
    {
        GunData.GunData = GameObject.Find("Player").GetComponent<GetJobData>().EquipGun;
        uIManager=GameObject.Find("RoleInfo").GetComponent<UIManager>();
        FireTime = (float)1 / GunData.speed;
        currentTime = FireTime;
        maxAmmo = GunData.ammoCap;
        currentAmmo = maxAmmo;
        maxReserveAmmo = GunData.reserveAmmo;
        reserveAmmo = maxReserveAmmo;
        reloadTime = GunData.reloadSpeed;
        originOffset = GunData.originOffset;
        currentOffset = originOffset;
        recoil = GunData.recoil;
        recoilRecover = GunData.recoilRecover;
        bulletNumber = GunData.bulletNumber;
        rightHand.transform.localPosition = GunData.R_handPos;
        leftHand.transform.localPosition = GunData.L_handPos;
        GunMuzzle.transform.localPosition = GunData.GunMuzzlePos;
        GunPng.GetComponent<SpriteRenderer>().sprite = GunData.GunPng;
        GunPng.transform.localPosition = GunData.PngOffset;
    }
}
