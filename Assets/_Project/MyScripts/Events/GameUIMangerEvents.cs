using System;
using UnityEngine;

public class GameUIMangerEvents 
{
    public Action<AudioClip> OnSoundPlayed;

    public void PlaySound(AudioClip clip)
    {
        OnSoundPlayed?.Invoke(clip);
    }

    public Action<bool,int> OnWInLosePanelShowHide;
    public void ShowHideWinLosePanel(bool isShow,int star)
    {
        OnWInLosePanelShowHide?.Invoke(isShow,star);
    }
}
