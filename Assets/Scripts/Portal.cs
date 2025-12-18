using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{    
     public string borderTag; 
    public float buffer = 0.1f; 
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if(!other.CompareTag("teleportable")) return;

        Vector2 newPos = other.transform.position;

        switch(borderTag)
        {
            case "BorderLeft":
               
                newPos.x = GameObject.FindGameObjectWithTag("BorderRight").transform.position.x + buffer;
                break;

            case "BorderRight":
               
                newPos.x = GameObject.FindGameObjectWithTag("BorderLeft").transform.position.x - buffer;
                break;

            case "BorderTop":
               
                newPos.y = GameObject.FindGameObjectWithTag("BorderBottom").transform.position.y - buffer;
                break;

            case "BorderBottom":
               
                newPos.y = GameObject.FindGameObjectWithTag("BorderTop").transform.position.y + buffer;
                break;
        }

        other.transform.position = newPos;
        Debug.Log($"{other.name} teleported to {newPos}");
    }
}

