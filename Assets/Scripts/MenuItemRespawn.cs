using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;



public class MenuItemRespawn : XRSocketInteractor
{
    public GameObject listRef;
    // Update is called once per frame
    

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
        XRSocketInteractor interactor = gameObject.GetComponent<MenuItemRespawn>();
        StartCoroutine(RespawnObj(args.interactableObject, interactor));
    }




    public IEnumerator RespawnObj(IXRSelectInteractable obj, XRSocketInteractor interactor)
    {
            
            GameObject cloneObj = obj.transform.gameObject;
            cloneObj.transform.parent = null;
            cloneObj.GetComponent<variables>().isSocketed = false;
            GameObject refClone = Instantiate(cloneObj, interactor.attachTransform.position,interactor.attachTransform.rotation);
            listRef.GetComponent<InputManager>().listObjets.Add(refClone);
            listRef.GetComponent<InputManager>().socket.Add(interactor.attachTransform.transform.gameObject);
            refClone.transform.parent = null;
            refClone.GetComponent<variables>().isSocketed = true;
            refClone.GetComponent<Rigidbody>().isKinematic = false;
            refClone.GetComponent<Rigidbody>().useGravity = true;
            yield return null;
    }
}
