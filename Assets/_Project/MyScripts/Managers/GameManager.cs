using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Card firstCard = null;

    [SerializeField] private int _numberOfAttempt = 3;
    private void OnEnable()
    {
        EventManager.Instance.gameManagerEvents.OnCardSelected += CardSelected;
    }

    private void OnDisable()
    {
        EventManager.Instance.gameManagerEvents.OnCardSelected -= CardSelected;
    }

    private void CardSelected(Card card)
    {
        if (!firstCard)
        {
            firstCard = card;
            return;
        }

        if (firstCard.GetId() == card.GetId())
        {
            Debug.Log("Match");
            SpawnManager.Instance.RemoveCard(firstCard);
            SpawnManager.Instance.RemoveCard(card);
        }
        else
        {
            firstCard.Flip(Constant.FLIP_BACK_ANIM);
            card.Flip(Constant.FLIP_BACK_ANIM);
            Debug.Log("No match");
            _numberOfAttempt--;

        }

        WinLLoaseBehiavior();

        firstCard = null;
    }


    private void WinLLoaseBehiavior()
    {
        if (_numberOfAttempt == 0)
        {
            Debug.Log("You Lose");
            EventManager.Instance.GameUIMangerEvents.ShowHideWinLosePanel(false, 0);
            return;
        }
        if (SpawnManager.Instance.GetCardsList().Count == 0)
        {
            Debug.Log("You Win");
            EventManager.Instance.GameUIMangerEvents.ShowHideWinLosePanel(true, _numberOfAttempt);
        }
    }

}
