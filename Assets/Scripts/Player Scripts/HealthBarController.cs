using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Image totalHealth;
    [SerializeField] private Image currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth.fillAmount = PlayerController.instance.currentHealth / PlayerController.instance.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth.fillAmount = PlayerController.instance.currentHealth / PlayerController.instance.maxHealth;
    }
}
