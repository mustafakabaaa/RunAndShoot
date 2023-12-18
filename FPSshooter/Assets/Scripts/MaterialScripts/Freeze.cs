using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public float freezeSpeed = 5f;
   
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0f, freezeSpeed * Time.deltaTime, 0f);
        
    }
}
