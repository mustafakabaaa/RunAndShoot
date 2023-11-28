using UnityEditor;


[CustomEditor(typeof(Interacrtable),true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interacrtable interacrtable = (Interacrtable)target;
        if (target.GetType() == typeof(EventOnlyInteractTable))
        {
            interacrtable.prompMessage=EditorGUILayout.TextField("Prompt Message",interacrtable.prompMessage);
            EditorGUILayout.HelpBox("EventOnlyInteract can Only use UnityEvents.",MessageType.Info);
           
            if (interacrtable.GetComponent<InteractionsEvents>() == null)
            {
                interacrtable.useEvents=true;
                interacrtable.gameObject.AddComponent<InteractionsEvents>();
            }
        }
        else
        {

        
            base.OnInspectorGUI();
            if (interacrtable.useEvents)
            {
                if(interacrtable.GetComponent<InteractionsEvents>()==null) 
                interacrtable.gameObject.AddComponent<InteractionsEvents>();


            }
            else
            {
                if( interacrtable.GetComponent<InteractionsEvents>()!=null)
                {
                    DestroyImmediate(interacrtable.GetComponent<InteractionsEvents>());
                }
            }
        }
    }
}
