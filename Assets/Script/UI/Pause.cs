using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sprite PauseSprite;
    [SerializeField] private Sprite ContinueSprite;
    private bool state = false;
    private SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        state = !state;
        sr.sprite = state ? PauseSprite : ContinueSprite;
        Time.timeScale = state ? 1 : 0;
    }
}
