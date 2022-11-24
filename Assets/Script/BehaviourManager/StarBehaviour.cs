using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarBehaviour : MonoBehaviour
{
    [SerializeField] Sprite _fullIMG;
    Image _image;
    bool _isLooted;

    public Image Image { get => _image; }
    public bool IsLooted
    {
        get => _isLooted; set
        {
            _isLooted = value;

            if (_isLooted)
                _image.sprite = _fullIMG;
        }
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
}
