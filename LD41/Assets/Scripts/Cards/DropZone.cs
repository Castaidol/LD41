using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler {

    private bool canDrop = true;

	private void Start()
	{
	}

	public void OnDrop(PointerEventData eventData)
    {
        if(canDrop)
        {
            Debug.Log(eventData.pointerDrag.name + "was drop on");

            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null)
            {
                d.parentToReturn = this.transform;
                canDrop = false;

                StartCoroutine(DestroyCard(eventData.pointerDrag));
            } 
        }else
        {
            return;
        }

    }

    IEnumerator DestroyCard(GameObject card)
    {
        card.GetComponent<BurstAttack>().burst = true;
       
        yield return new WaitForSeconds(5f);

        Destroy(card);
        canDrop = true;
    }

}
