using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] private Sprite buttonOnSprite;
    [SerializeField] private Sprite buttonOffSprite;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnMouseEnter()
    {
        image.sprite = buttonOnSprite;
    }

    public void OnMouseExit()
    {
        image.sprite = buttonOffSprite;
    }
}
