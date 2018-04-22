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
            //Debug.Log(eventData.pointerDrag.name + "was drop on");

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
        if(card.GetComponent<Attack>() != null)
        {
            if (card.GetComponent<Attack>().burstAttack == true)
            {
                card.GetComponent<Attack>().burst = true;

                yield return new WaitForSeconds(card.GetComponent<Attack>().duration);

                Destroy(card);
                canDrop = true;
            }
            else if (card.GetComponent<Attack>().autoAttack == true)
            {
                card.GetComponent<Attack>().auto = true;
                yield return new WaitForSeconds(card.GetComponent<Attack>().duration);

                Destroy(card);
                canDrop = true;

            }
            else
            {
                Destroy(card);
                canDrop = true;
            }
        }else
        {
            yield return new WaitForSeconds(5f);
            Destroy(card);
            canDrop = true;
        }

       

       
    }

}
