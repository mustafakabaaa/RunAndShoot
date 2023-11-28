using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public abstract class Interacrtable : MonoBehaviour
{
    public bool useEvents;

    [SerializeField]
    public string prompMessage;



    public void BaseInteract()
    {
        if(useEvents)
        {
            GetComponent<InteractionsEvents>().onInteract.Invoke();
        }
        Interact();

    }
    public virtual string OnLook()
    {
        return prompMessage;
    }
    
    protected virtual void Interact()
    {

    }
   
}
