using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    private List<GameObject> targets = new List<GameObject>();

    [SerializeField] private int _tipe;
    [SerializeField] private float _speed;
    [SerializeField] private bool _forPlayer;
    [SerializeField] private bool _destroy;

    public float Damage;
    public float Health;
    public GameObject Parent;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        foreach (GameObject target in targets)
        {
            if (target == collider.gameObject)
            {
                return;
            }
        }
        if (_forPlayer)
        {
            if (collider.gameObject.GetComponent<State>() && collider.gameObject.tag == "Player" && collider.gameObject != Parent)
            {
                Parent?.GetComponent<State>().Healt(Health);
                collider.gameObject.GetComponent<State>().TakeDamage(Damage, _tipe);
                targets.Add(collider.gameObject);
                if (_destroy == true)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            if (collider.gameObject.GetComponent<State>() && collider.gameObject != Parent)
            {
                Parent?.GetComponent<State>().Healt(Health);
                collider.gameObject.GetComponent<State>().TakeDamage(Damage, _tipe);
                targets.Add(collider.gameObject);
                if (_destroy == true)
                {
                    Destroy(gameObject);
                }
            }
        }
        
    }
}
