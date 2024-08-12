using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public GameObject dialog;
    public void DialogSetActive(bool state)
    {
        if (dialog.activeSelf == true)
        {
            dialog.SetActive(false);
        }
        else
        {
            dialog.SetActive(true);
        }
    }

}
