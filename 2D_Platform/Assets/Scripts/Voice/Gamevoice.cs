using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamevoice : MonoBehaviour
{
    public GameObject voice;



    public void Awake()
    {
        if (voice == null)
        {

            DontDestroyOnLoad(voice);
        }
        else
        {
            Destroy(voice);

        }

    }
}
