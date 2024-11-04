using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Card firstCard = null;
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
        }
        else
        {
            firstCard.Flip(Constant.FLIP_BACK_ANIM);
            card.Flip(Constant.FLIP_BACK_ANIM);
            Debug.Log("No match");
        }

        firstCard = null;
    }
}
