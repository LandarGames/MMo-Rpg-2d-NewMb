using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField] private float _time;
    void Awake()
    {
        Destroy(gameObject, _time);
    }

    void Update()
    {
        GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, _time / _time * Time.deltaTime);
    }
}
