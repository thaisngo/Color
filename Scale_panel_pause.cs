using UnityEngine;
using DG.Tweening;
public class Scale_panel_pause : MonoBehaviour
{
    RectTransform trans;
    public float vtoc = 2.0f;
    public Ease dotEase;
    void Start()
    {
        trans = GetComponent<RectTransform>();
        TweenControl.GetInstance().MoveFollowBenzier(gameObject, new Vector2(0f,MaTran_Luoi.instance.sizeScreen.y * (800f / 1136)), Vector2.zero);
    }
}
