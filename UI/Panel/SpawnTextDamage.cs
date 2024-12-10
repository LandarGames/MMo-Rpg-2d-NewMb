using UnityEngine;

public class SpawnTextDamage : MonoBehaviour
{
    [SerializeField] private TextDamage _text;
    [SerializeField] private Sprite[] _tipe;

    public void Spawn(float damage,int tipe)
    {
        _text.Tipe.sprite = _tipe[tipe];
        _text.Damage = damage;
        Instantiate(_text, transform.position, Quaternion.identity);
    }
}
