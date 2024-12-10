using UnityEngine;
using UnityEngine.Diagnostics;

public class Skil : MonoBehaviour
{
    public GameObject[] Skils;
    public GameObject[] PasivSkil;
    public float[] Range;
    public bool[] Active;
    public float[] KD;

    private void Update()
    {
        Kd();
        PowerSkil();
        if (gameObject.GetComponent<NegativeEffect>().Stan < 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SkilActive(Skils[0], 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                SkilActive(Skils[1], 0, 1);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SkilActive(Skils[2], 0, 2);
            }
            if (Active[0] == true)
            {
                Skils[0].GetComponent<Power>().Skil(gameObject, 0, gameObject.GetComponent<State>(), GetComponent<Player>().SeeUnit(GetComponent<Player>().Range(Range[0])));
            }
            if (Active[1] == true)
            {
                Skils[1].GetComponent<Power>().Skil(gameObject, 1, gameObject.GetComponent<State>(), GetComponent<Player>().SeeUnit(GetComponent<Player>().Range(Range[1])));
            }
            if (Active[2] == true)
            {
                Skils[2].GetComponent<Power>().Skil(gameObject, 2, gameObject.GetComponent<State>(), GetComponent<Player>().SeeUnit(GetComponent<Player>().Range(Range[2])));
            }
        }     
    }

    private void SkilActive(GameObject activ, int tipe, int skils)
    {
        if (KD[skils] <= 0)
        {
            if (tipe == 0)
            {
                activ.GetComponent<Power>().Skil(gameObject, skils, gameObject.GetComponent<State>(), GetComponent<Player>().SeeUnit(GetComponent<Player>().Range(Range[skils])));
            }
            if (tipe == 1)
            {
                if (Active[skils] == false)
                    Active[skils] = true;
                else
                    Active[skils] = false;
                activ.GetComponent<Power>().End(gameObject);

            }
        }     
    }
    private void Kd()
    {
        for (int i = 0; i < KD.Length; i++)
        {
            KD[i] -= Time.deltaTime * gameObject.GetComponent<State>().KdHeist;
        }
    }

    private void PowerSkil()
    {
        GetComponent<State>().PowerSkil = 0;
        for (int i = 0; i < KD.Length; i++)
        {
            GetComponent<State>().PowerSkil += Skils[i].GetComponent<Power>().PowerSkil;
        }
    }
}
