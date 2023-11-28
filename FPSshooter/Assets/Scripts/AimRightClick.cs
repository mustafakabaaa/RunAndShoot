using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRightClick : MonoBehaviour
{
    public Vector3 normalpos;
    public Vector3 aimPos;
    public bool isScopeOpen;
    public float aimSpeed;
    PlayerAmmo playerAmmo;

    // Start is called before the first frame update
    void Start()
    {
        playerAmmo = GameObject.FindObjectOfType<PlayerAmmo>();
        if (playerAmmo == null)
        {
            Debug.LogError("PlayerAmmo component not found on the same GameObject!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1)&&!playerAmmo.isReloading)
        {
            transform.localPosition=Vector3.Slerp(transform.localPosition, aimPos, aimSpeed*Time.deltaTime);
            isScopeOpen = true;
        }
        else
        {

            transform.localPosition=Vector3.Slerp(transform.localPosition,normalpos, aimSpeed*Time.deltaTime);
            isScopeOpen = false;
        }


    }
}
