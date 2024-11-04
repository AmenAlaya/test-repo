using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Card firstCard = null;

    [SerializeField] private int _numberOfAttempt = 3;
    [SerializeField]private AudioClip matchClip;
    [SerializeField]private AudioClip notMatchClip;

    [SerializeField] private TextMeshProUGUI _numberOfAttemptText;

    private void Awake()
    {
        NumberOfAttemptText();
    }

    private void NumberOfAttemptText()
    {
        _numberOfAttemptText.text = "Number of attemps : " + _numberOfAttempt.ToString();

    }

    private void OnEnable()
    {
        EventManager.Instance.gameManagerEvents.OnCardSelected += CardSelected;
    }

    private void OnDisable()
    {
        EventManager.Instance.gameManagerEvents.OnCardSelected -= CardSelected;
    }

    private void PlaySfx(AudioClip audioClip)
    {
        EventManager.Instance.GameUIMangerEvents.PlaySound(audioClip);
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
            PlaySfx(matchClip);
            SpawnManager.Instance.RemoveCard(firstCard);
            SpawnManager.Instance.RemoveCard(card);
        }
        else
        {
            PlaySfx(notMatchClip);
            firstCard.Flip(Constant.FLIP_BACK_ANIM);
            card.Flip(Constant.FLIP_BACK_ANIM);
            _numberOfAttempt--;
            NumberOfAttemptText();

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
