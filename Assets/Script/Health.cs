using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{
    public static float currentHealth;
    public Image healthBar;
    public Text ratioText;
    float maxHealth = 100;

    private void Start()
    {
        //Update();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        //healthBar.fillAmount = currentHealth / maxHealth;
        float ratio = currentHealth / maxHealth;
        //Debug.Log(ratio);

        if (currentHealth < 0)
        {
            currentHealth = 0.0f;
            Debug.Log("Dead!");
        }
        healthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0");
    }

    //private void TakeDamage(float damage)
    //{
    //    currentHealth -= damage;
    //    if (currentHealth < 0)
    //    {s
    //        currentHealth = 0.0f;
    //        Debug.Log("Dead!");
    //    }
    //    Update();
    //}

    private void HealUp(float heal)
    {
        currentHealth += Time.deltaTime * heal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        Update();
    }

    //void OnTriggerEnter(Collider collider)
    //{
    //    if (collider.gameObject.tag == "HealCube")
    //    {
    //        HealUp(10.0f);
    //    }
    //}

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "HealCube")
        {
            HealUp(10.0f);
        }
    }
}
