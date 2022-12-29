using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    [SerializeField] Sprite _FullStar;
    Image _image;
    bool _isLooted;

    public Image Image { get => _image;}
    public bool IsLooted
    {
        get => _isLooted; set
        {
            _isLooted = value;

            if (_isLooted)
                _image.sprite = _FullStar;
        }
    }



    private void Awake()
    {
        _image = GetComponent<Image>();
    }
   
}
