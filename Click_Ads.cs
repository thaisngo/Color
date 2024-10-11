using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Click_Ads : MonoBehaviour
{
    public GameObject panel_ads;
    public void button_ADS()
    {
        panel_ads.SetActive(true);
    }

    public void Ads_Home()
    {
        SceneManager.LoadScene("batDau");
    }

    public void Remove_Ads()
    {

    }
}
