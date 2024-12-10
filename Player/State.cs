using System;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] private SpawnTextDamage _spawnText;
    public SpriteRenderer Sp;

    [Header("Hp")]
    public float MaxHP;
    public float Hp;

    [Header("Mage")]
    public float Mana;
    public float ManaMax;
    public float Power;
    public float PowerSkil;
    public float DopMageDamage;
    public float KdHeist;

    [Header("Atak")]
    public float AtakSpeed;
    public float Damage;

    [Header("Speed")]
    public int JerkMax;
    public float JerkKd;
    public float JerkSpeed;
    public int JerkReal;
    public float JerkKdReal;
    public float TimeJerk;
    public float Speed;
    public float RealSpeed;

    [Header("Armor")]
    public float MageArmor;
    public float PhisArmor;

    [Header("Health")]
    public float BazeRegen;
    public float PhisHealt;
    public float MageHealt;

    private float _bazeMageArmor;
    private float _bazePhisArmor;
    private float _mageArmor;
    private float _phisArmor;

    private void Awake()
    {
        _bazeMageArmor = MageArmor;
        _bazePhisArmor = PhisArmor;
        JerkReal = JerkMax;
        States();
    }

    private void Update()
    {
        Powers();
        JerksKd();
        Sp.color += new Color(2.5f * Time.deltaTime, 2.5f * Time.deltaTime, 2.5f * Time.deltaTime, 2.5f * Time.deltaTime);
        if (Hp < MaxHP)
        {
            Healt(BazeRegen * Time.deltaTime);
        }
        if (Hp > MaxHP)
        {
            Hp = MaxHP;
        }
        
    }

    public void States()
    {
        RealSpeed = Speed;
        Hp = MaxHP;
        _mageArmor = MageArmor;
        _phisArmor = PhisArmor;
    }

    private void JerksKd()
    {
        if (JerkMax > JerkReal)
        {
            JerkKdReal += Time.deltaTime;
            if (JerkKdReal >= JerkKd)
            {
                JerkReal += 1;
                JerkKdReal = 0;
            }
        }
    }

    public void TakeDamage(float damage,int tipe)
    {
        _spawnText.Spawn(damage, tipe);
        Sp.color = new Color(1f, 0, 0);
        switch (tipe)
        {
            case 0:
                Hp -= damage * (1 - _phisArmor / 100);
                break;
            case 1:
                Hp -= damage * (1 - _mageArmor / 100);
                break;
            case 2:
                Hp -= damage;
                break;
        }            
    }

    public void TrataAgil(int agil)
    {
        Sp.color = new Color(1f, 1f, 0);
        JerkReal -= agil; 
    }

    public void Healt(float regen)
    {
        Hp += regen;
    }

    public void Powers()
    {
        Power = (int)((Convert.ToInt32(Damage / AtakSpeed) + MaxHP + PhisArmor + MageArmor + DopMageDamage + MageHealt + PhisHealt + Speed + (Convert.ToInt32(JerkSpeed / TimeJerk)) + JerkMax + PowerSkil) / 15);
    }
}
