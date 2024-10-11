using UnityEngine;
using DG.Tweening;
public class Scale_panel_endGame : MonoBehaviour
{
    public float vtoc = 2.0f;
    public Ease dotEase;
    void Start()
    {
        transform.localScale = new Vector2(0f, 0f);
        transform.DOScale(1f, 0.5f);
    }
}
