using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    
    public float aheaddistance;//oyuncuyu tam merkeze almaz biraz oynatýr oynayabilirsin sýfýr yaparsan merkeze alýr
    public float cameraSpeed;//kamera hýzý
    private float lookahead;
    //player follower
    public Transform player;
    private void Update()
    {
        transform.position = new Vector3(player.position.x+lookahead, player.position.y, transform.position.z);
        lookahead = Mathf.Lerp(lookahead, (aheaddistance * player.localScale.x), Time.deltaTime * cameraSpeed);

         
    }

 
}
