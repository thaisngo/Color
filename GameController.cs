using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    void Start()
    {
        AdsController.instance.InitAds();
        AdsController.instance.RequestAds();
    }    
}