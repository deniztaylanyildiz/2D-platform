using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVLSets : MonoBehaviour
{
    //oda mant��� i�in ileri geri gibi
    public GameObject[] enemies;
    private Vector3[] initialPositions;
    private void Awake()
    {
        initialPositions = new Vector3[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            initialPositions[i] = enemies[i].transform.position;
        }
    }
    public void activateroom(bool _status)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i]!=null)
                {
                enemies[i].SetActive(_status);
                enemies[i].transform.position = initialPositions[i];
        }
        }


    }
}
