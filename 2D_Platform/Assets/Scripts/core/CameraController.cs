using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    
    public float aheaddistance;//oyuncuyu tam merkeze almaz biraz oynat�r oynayabilirsin s�f�r yaparsan merkeze al�r
    public float cameraSpeed;//kamera h�z�
    private float lookahead;
    //player follower
    public Transform player;
    private void Update()
    {
        transform.position = new Vector3(player.position.x+lookahead, player.position.y, transform.position.z);
        lookahead = Mathf.Lerp(lookahead, (aheaddistance * player.localScale.x), Time.deltaTime * cameraSpeed);

         
    }

 
}
