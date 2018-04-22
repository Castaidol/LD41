using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_DefUt : MonoBehaviour {

    private Deck deck;
    List<GameObject> cards;

    private void Start()
    {
        deck = GameObject.FindGameObjectWithTag("Deck").GetComponent<Deck>();

        GetFirstHand();
    }

    private void Update()
    {

        if (transform.childCount < 2)
        {
            Instantiate(deck.dUCards[0], transform.position, Quaternion.identity, this.transform);

            deck.dUCards.RemoveAt(0);
            Debug.Log(deck.dUCards.Count);
        }


    }


    void GetFirstHand()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(deck.dUCards[0], transform.position, Quaternion.identity, this.transform);

            deck.dUCards.RemoveAt(0);
            Debug.Log(deck.dUCards.Count);
        }
    }
}
