using UnityEngine;

public abstract class Power : MonoBehaviour
{
    public float Kd;
    public int PowerSkil;
    public abstract void Skil(GameObject player, int skil, State state,GameObject target);

    public abstract void End(GameObject player);
}
