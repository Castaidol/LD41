using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Attack : MonoBehaviour {

    private Deck deck;
    List<GameObject> cards;

    private void Start()
    {
        deck = GameObject.FindGameObjectWithTag("Deck").GetComponent<Deck>();

        GetFirstHand();
    }

	private void Update()
	{
        
        if (transform.childCount < 3)
        {
            Instantiate(deck.cards[0], transform.position, Quaternion.identity, this.transform);

            deck.cards.RemoveAt(0);
            Debug.Log(deck.cards.Count);
        }


	}


	void GetFirstHand()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(deck.cards[0], transform.position, Quaternion.identity, this.transform);

            deck.cards.RemoveAt(0);
            Debug.Log(deck.cards.Count);
        }
    }

}
