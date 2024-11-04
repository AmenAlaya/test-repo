using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEvents 
{
    public Action<Card> OnCardSelected { get; set; }

    public void CardSelected(Card card)
    {
        OnCardSelected?.Invoke(card);
    }
}
