using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hunger_bar : MonoBehaviour
{
    public Slider slider_Cheese;
    public Slider slider_Water;
    public float Interval = 2f;
    private float _timer = 0f;
    HealthSystem hb = null;
    void Start() { hb = GetComponent<HealthSystem>(); }
    void Update()
    {
        Gererslidercheese();
        Gerersliderwater();
    }
    public void Cheeseeat()
    {
        slider_Cheese.value = slider_Cheese.maxValue;
        Debug.Log("Eat Cheese",this);
    }
    public void RefillWater()
    {
        slider_Water.value = slider_Water.maxValue;
    }
    public void Gererslidercheese()
    {
        _timer += Time.deltaTime;
        if (_timer >= Interval)
        {
            if (slider_Cheese.value > 0)
            {
                slider_Cheese.value -= 1;
            }

            _timer = 0f;
        }
        if (slider_Cheese.value < 0)
        {

            FindObjectOfType<HealthSystem>();
            hb.TakeDamage(1);
        }
    }
    public void Gerersliderwater()
    {
        _timer += Time.deltaTime;
        if (_timer >= Interval)
        {
            if (slider_Water.value > 0)
            {
                slider_Water.value -= 1;
            }

            _timer = 0f;
        }
        if (slider_Water.value < 0)
        {

            FindObjectOfType<HealthSystem>();
            hb.TakeDamage(1);
        }
    }
}