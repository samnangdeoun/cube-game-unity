using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if(playerController != null)
        {
            float x = playerController.transform.position.x;
            float z = playerController.transform.position.z;
            float y = transform.position.y;
            transform.position = new Vector3(x, y, z);
        }
    }
}
