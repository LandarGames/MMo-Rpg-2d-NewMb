using System.Collections.Generic;
using UnityEngine;

public class SeeTarget : MonoBehaviour
{
    public List<GameObject> _targets = new List<GameObject>();

    [SerializeField] private bool _enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_enemy == true)
        {
            if (collision.gameObject.GetComponent<State>() && collision.gameObject.tag != "Enemy")
            {
                _targets.Add(collision.gameObject);
            }
            return;
        }
        if (collision.gameObject.GetComponent<State>())
        {
            _targets.Add(collision.gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_enemy == true)
        {
            if (collision.gameObject.GetComponent<State>() && collision.gameObject.tag != "Enemy")
            {
                _targets.Remove(collision.gameObject);
            }
            return;
        }
        if (collision.gameObject.GetComponent<State>())
        {
            _targets.Remove(collision.gameObject);
        }
    }
}
