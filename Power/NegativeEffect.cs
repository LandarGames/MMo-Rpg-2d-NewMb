using UnityEngine;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

public class NegativeEffect : MonoBehaviour
{
    public float Stan = -1;
    public async void Stans(float sec)
    {
        Stan = sec;
        while (Stan > 0)
        {
            Stan -= Time.deltaTime;
            await Task.Delay(1);
        }
    }

    public async void AnimStan(float sec)
    {
        Stan = sec;
        while (Stan > 0)
        {
            Stan -= Time.deltaTime;
            await Task.Delay(1);
        }
    }

    public async void SlowDown(float LowSpeed,float TimeEnd)
    {
        float speed = gameObject.GetComponent<State>().Speed;
        float time = 0;
        float slow = speed - LowSpeed;
        gameObject.GetComponent<State>().RealSpeed = slow;
        while (time < TimeEnd)
        {
            time += Time.deltaTime;
            await Task.Delay(1);
        }
        gameObject.GetComponent<State>().RealSpeed = speed;
    }

    public async void Burning(float intervalDamage, float longTime, float Damage, int tipe)
    {
        float intervals = 0;
        float _time = 0;
        while (_time < longTime)
        {
            _time += Time.deltaTime;
            intervals += Time.deltaTime;
            if (intervals > intervalDamage)
            {
                gameObject.GetComponent<State>().TakeDamage(Damage, tipe);
                intervals = 0;
            }
            await Task.Delay(1);

        }
    }
}
