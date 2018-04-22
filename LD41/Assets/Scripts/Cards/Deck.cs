using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public int attackDeckSize;
    public GameObject[] attackCards;

    public int defUtDeckSize;
    public GameObject[] defUtCards;

    [HideInInspector]
    public List<GameObject> cards = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> dUCards = new List<GameObject>();

	private void Awake()
	{
        PopulateAttackDeck();
        PopulateDUDeck();

        foreach(GameObject card in cards)
        {
            //Debug.Log(card.name);
        }
	}



    void PopulateAttackDeck()
    {
        for (int i = 0; i < attackDeckSize; i++)
        {
            cards.Add(attackCards[Random.Range(0, attackCards.Length)]);
        }
    }


    void PopulateDUDeck()
    {
        for (int i = 0; i < defUtDeckSize; i++)
        {
            dUCards.Add(defUtCards[Random.Range(0, defUtCards.Length)]);
        }
    }
}
