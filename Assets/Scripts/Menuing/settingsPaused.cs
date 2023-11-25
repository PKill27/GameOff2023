using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsPaused : MonoBehaviour
{

    public void CloseSettings()
    {
        gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(true);
    }

}
