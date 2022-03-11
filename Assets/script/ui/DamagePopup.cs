using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePopup : MonoBehaviour
{
    public Text text;
    public float duration = 0.5f;

    private void Start()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
    }

    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetDamageValue(float value)
    {
        text.text = value.ToString();
    }
}
