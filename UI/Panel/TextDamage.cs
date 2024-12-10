using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextDamage : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _desroy;
    [SerializeField] private TextMeshProUGUI _text;

    public Image Tipe;
    public float Damage;

    private void Awake()
    {
        _text.text = Convert.ToString(Damage);
        Destroy(gameObject, _desroy);
    }
    private void Update()
    {
        _text.color -= new Color(0,0,0,_speed * Time.deltaTime);
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void OnApplicationPause(bool pause)
    {
        Destroy(gameObject);
    }
}
