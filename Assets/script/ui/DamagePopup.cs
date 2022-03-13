using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePopup : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
    }

    public void SetDamageValue(float value)
    {
        text.text = value.ToString();
    }
}
