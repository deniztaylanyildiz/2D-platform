using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLauncher : MonoBehaviour
{
    public Transform enemy;

    private void Update()
    {
        transform.localScale = enemy.localScale;
    }

}
