using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private Button _button;
    private Image _image;
    private Animator _animator;

    [SerializeField]private int _id;
    [SerializeField] private Sprite _sprite;
    private Sprite intialSprite;

    [SerializeField] private AudioClip _flipSound;

    private void PlayFlipSound()
    {
        EventManager.Instance.GameUIMangerEvents.PlaySound(_flipSound);
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _animator = GetComponent<Animator>();
        _image = GetComponent<Image>();

        intialSprite = _image.sprite;
        _button.onClick.AddListener(() => Flip(Constant.FLIP_ANIM));
    }

    public int GetId()
    {
        return _id;
    }
    public void SetMe(int id, Sprite sprite)
    {
        _id = id;
        _sprite = sprite;

    }


    public void Flip(string animation)
    {
        _animator.Play(animation);
    }

    public void ShowCard()
    {
        PlayFlipSound();
        _button.interactable = false;
        EventManager.Instance.gameManagerEvents.CardSelected(this);
        _image.sprite = _sprite;
    }

    public void HideCard()
    {
        _button.interactable = true;
        _image.sprite = intialSprite;
    }
}
