using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "CreateNewGun")]
public class Gun_SO : ScriptableObject
{
    public int settingID;
    //������
    public float attack;
    //�����ٶȣ���λÿ�룩
    public int speed;
    //��ʼ��ɢ
    public float originOffset;
    //��ϻ����
    public int ammoCap;
    //�󱸵�ҩ
    public int reserveAmmo;
    //�����ٶ�
    public float reloadSpeed;
    //������?
    public float recoil;
    //��ɢ�ָ��ٶ�
    public float recoilRecover;
    //�˺���ʼ˥������
    public int fadeDistance;
    public int bulletNumber;
    public Sprite GunPng;
    public Vector2 L_handPos;
    public Vector2 R_handPos;
    public Vector2 GunMuzzlePos;
    public Vector2 PngOffset;
    public string audioSrc;


}
