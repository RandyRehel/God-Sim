using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;



public class MenuItemRespawn : XRSocketInteractor
{
    bool cdDone = true;
    
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
            GameObject refClone = Instantiate(cloneObj, interactor.attachTransform.position,interactor.attachTransform.rotation);
            refClone.GetComponent<Rigidbody>().isKinematic = false;
            refClone.GetComponent<Rigidbody>().useGravity = true;
            yield return null;
    }
}
