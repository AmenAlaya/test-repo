using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelBtn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lvlIndex;
    [SerializeField] private GameObject _starConatiner;
    [SerializeField] private GameObject[] _starNumber;

    private Button _button;
    private Image _image;
    [SerializeField] private Sprite _lockedSprite;

    private int _index;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(LoadLevel);
        _lvlIndex.text = (_index + 1).ToString();

        if (_index == 0)
        {
            SaveLoadManager.Save(Constant.LEVEL_REACHED + _index.ToString(), 0);
        }

        ButtonState();
    }

    private void LoadLevel()
    {
        GameUIManager.currentLevel = _index;
        SceneManager.LoadScene(Constant.MAIN_GAME);
    }


    private void ButtonState()
    {
        if (PlayerPrefs.HasKey(Constant.LEVEL_DONE + _index.ToString()))
        {
            Debug.Log("Done here");
            _lvlIndex.gameObject.SetActive(true);
            _starConatiner.SetActive(true);
            for (int i = 0; i < (int)SaveLoadManager.Load(Constant.LEVEL_DONE + _index.ToString()); i++)
            {
                _starNumber[i].SetActive(true);
            }
        }
        else
        {
            if (PlayerPrefs.HasKey(Constant.LEVEL_REACHED + _index.ToString()))
            {
                _lvlIndex.gameObject.SetActive(true);
                Debug.Log("Reached here");
            }
            else
            {
                _button.interactable = false;
                _image.sprite = _lockedSprite;
            }
        }
    }

    public void SetIndex(int index)
    {
        _index = index;
    }
}
