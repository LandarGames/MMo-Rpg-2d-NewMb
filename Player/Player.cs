using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Money;

    public GameObject Gun;
    public GameObject Target;
    public GameObject[] Item;
    public float TimeInJerk;

    private Rigidbody2D _rb;

    [SerializeField] private float _rangeSee;
    [SerializeField] private GameObject Shop;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GetComponent<State>().States();
    }

    private void Update()
    {
        if (GetComponent<NegativeEffect>().Stan < 0)
        {
            Range(_rangeSee);
            MoveMent();
            if (Gun != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Gun.GetComponent<Gun>().Atak(GetComponent<State>(),gameObject);
                }
                if (Range(_rangeSee).Count > 0)
                {
                    Gun.GetComponent<Gun>().Aim(SeeUnit(Range(_rangeSee)));
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            ShopOpen();
        }
    }

    private void ShopOpen()
    {
        if (!Shop.activeSelf)
        {
            Shop.SetActive(true);
        }
        else
        {
            Shop.SetActive(false);
        }
    }
    public void Items()
    {
        foreach (GameObject item in Item)
        {
            if (item)
            {
                item.GetComponent<ItemPasiv>().Active(gameObject);
            }
        }
    }

    public List<GameObject> Range(float range)
    {
        Vector2 size = new Vector2(range, range);
        Collider2D[] see = Physics2D.OverlapCapsuleAll(transform.position, size, CapsuleDirection2D.Horizontal, 360f);

        List<GameObject> targets = new();

        foreach (Collider2D target in see)
        {
            if (target.GetComponent<State>() && target.gameObject != gameObject)
            {
                Debug.Log(target);
                targets.Add(target.gameObject);
            }
        }
        return targets;
    }

    public GameObject SeeUnit(List<GameObject> targets)
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in targets)
        {
            Vector2 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                distance = curDistance;
                Target = go;
            }
        }
        return Target;
    }
    private void MoveMent()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (GetComponent<State>().JerkReal > 0)
            {
                TimeInJerk = GetComponent<State>().TimeJerk;
                GetComponent<State>().TrataAgil(1); 
            }
        }
        if (TimeInJerk <= 0)
        {
            _rb.velocity = new Vector2(x * GetComponent<State>().RealSpeed, y * GetComponent<State>().RealSpeed);
            _rb.bodyType = RigidbodyType2D.Dynamic;
            if (x == 0 && y == 0)
            {
                GetComponent<State>().Sp.gameObject.GetComponent<Animator>()?.SetTrigger("Stoika");
            }
            else
            {
                GetComponent<State>().Sp.gameObject.GetComponent<Animator>()?.SetTrigger("Run");
            }
        }
        else
        {
            Jerk(x, y, GetComponent<State>().JerkSpeed);
        }
    }

    public void Jerk(float x, float y,float speed)
    {
        GetComponent<State>().Sp.gameObject.GetComponent<Animator>()?.SetTrigger("Rivok");
        _rb.bodyType = RigidbodyType2D.Kinematic;
        TimeInJerk -= Time.deltaTime;
        _rb.velocity = new Vector2(x * speed, y * speed);
    }
}
