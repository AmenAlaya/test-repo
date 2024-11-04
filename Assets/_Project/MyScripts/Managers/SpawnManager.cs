using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Card _cardPrefab;
    [SerializeField] private List<CardSO> _cardsSO;
    [SerializeField] private Transform _cardParent;

    private List<Card> _cardsList = new List<Card>();

    private void Start()
    {
        List<CardSO> firstCardSOs = new List<CardSO>(_cardsSO);
        List<CardSO> secondCardSOs = new List<CardSO>(_cardsSO);
        List<CardSO> totalCardSOs = firstCardSOs.Concat(secondCardSOs).ToList();

        Shuffle(totalCardSOs);

        for (int i = 0; i < totalCardSOs.Count; i++)
        {
            CreateCard(totalCardSOs[i]);
        }
    }

    void Shuffle(List<CardSO> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(i, list.Count);
            CardSO temp = list[i];
            list[i] = list[rnd];
            list[rnd] = temp;
        }
    }

    private void CreateCard(CardSO cardSO)
    {
        Card card = Instantiate(_cardPrefab, _cardParent);
        card.SetMe(cardSO.id, cardSO.sprite);
        _cardsList.Add(card);
    }

}
