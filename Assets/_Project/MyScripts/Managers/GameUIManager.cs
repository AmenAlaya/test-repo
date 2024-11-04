using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static int currentLevel = 0;

    [Header("Panels")]
    [SerializeField] private GameObject _levelSelectPanel;
    [SerializeField] private GameObject _settingsPanelPrefab;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;


    [Header("AudioSource")]
    [SerializeField] private AudioSource myMusicPlayer;
    [SerializeField] private AudioSource myAudioSource;

    [Header("Music Sprites")]
    [SerializeField] private Image _musicImg;
    [SerializeField] private Sprite _musicBtnOnSprite;
    [SerializeField] private Sprite _musicBtnOffSprite;

    [Header("SFX Sprites")]
    [SerializeField] private Image _sfxImg;
    [SerializeField] private Sprite _sfxBtnOnSprite;
    [SerializeField] private Sprite _sfxBtnOffSprite;

    [Header("AudioClips")]
    [SerializeField] private AudioClip _clickClip;
    [SerializeField] private AudioClip _winClip;
    [SerializeField] private AudioClip _loseClip;

    private bool sfxOn = true;
    private bool musicOn = true;



    private void Awake()
    {
        SoundsState();
    }

    private void Start()
    {
        EventManager.Instance.GameUIMangerEvents.OnSoundPlayed += PlaySound;
        EventManager.Instance.GameUIMangerEvents.OnWInLosePanelShowHide += WinlosePanelShowHide;
    }

    private void WinlosePanelShowHide(bool isWin, int star)
    {
        if (isWin)
        {
            SaveLoadManager.Save(Constant.LEVEL_DONE + currentLevel, star);
            PlaySound(_winClip); _winPanel.SetActive(true);
        }
        else
        {
            PlaySound(_loseClip); _losePanel.SetActive(true);
        }
    }

    private void OnDisable()
    {
        EventManager.Instance.GameUIMangerEvents.OnSoundPlayed -= PlaySound;
        EventManager.Instance.GameUIMangerEvents.OnWInLosePanelShowHide -= WinlosePanelShowHide;
    }
    public void HomeBtn()
    {
        SceneManager.LoadScene(Constant.MAIN_MENU);
    }

    private void PlaySound(AudioClip clip)
    {
        if (sfxOn)
            myAudioSource.PlayOneShot(clip);
    }

    public void ShowHideSettingsPanel(bool isShow)
    {
        Time.timeScale = isShow ? 0 : 1;

        PlaySound(_clickClip);
        _settingsPanelPrefab.SetActive(isShow);
    }

    public void ShowHideLevelSelectPanel(bool isShow)
    {
        PlaySound(_clickClip);
        _levelSelectPanel.SetActive(isShow);
    }

    private void SoundsState()
    {
        musicOn = ((int)SaveLoadManager.Load(Constant.IS_MUSIC_ON) == 1);
        sfxOn = ((int)SaveLoadManager.Load(Constant.IS_SOUND_ON) == 1);

        myMusicPlayer.mute = !musicOn;
        myAudioSource.mute = !sfxOn;

        if (musicOn)
        {
            _musicImg.sprite = _musicBtnOnSprite;
        }
        else
        {
            _musicImg.sprite = _musicBtnOffSprite;
        }

        if (sfxOn)
        {
            _sfxImg.sprite = _sfxBtnOnSprite;
        }
        else
        {
            _sfxImg.sprite = _sfxBtnOffSprite;
        }

    }

    public void SfxBtn()
    {
        PlaySound(_clickClip);

        if (sfxOn)
        {
            sfxOn = false;
            _sfxImg.sprite = _sfxBtnOffSprite;
            myAudioSource.mute = true;
            SaveLoadManager.Save(Constant.IS_SOUND_ON, 1);
        }
        else
        {
            sfxOn = true;
            _sfxImg.sprite = _sfxBtnOnSprite;
            myAudioSource.mute = false;
            SaveLoadManager.Save(Constant.IS_SOUND_ON, 0);
        }
    }

    public void MusicBtn()
    {
        PlaySound(_clickClip);

        if (musicOn)
        {
            musicOn = false;
            _musicImg.sprite = _musicBtnOffSprite;
            myMusicPlayer.mute = true;
            SaveLoadManager.Save(Constant.IS_MUSIC_ON, 0);

        }
        else
        {
            musicOn = true;
            _musicImg.sprite = _musicBtnOnSprite;
            myMusicPlayer.mute = false;
            SaveLoadManager.Save(Constant.IS_MUSIC_ON, 1);

        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
