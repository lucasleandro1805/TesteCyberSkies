using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnLifeChangedListener(float life); 

public class HumanoidLife : MonoBehaviour
{
    [SerializeField]
    private float life = 100;

    public bool isAlive = true;

    private List<OnLifeChangedListener> onLifeChangedListeners = new List<OnLifeChangedListener>();

    public void SetLife(float value)
    {
        bool callListeners = false;
        if(this.life != value)
        {
            callListeners = true;
        }
        this.life = value;
        if(callListeners)
        {
            CallListeners();
        }
    
        isAlive = this.life > 0;
        gameObject.SetActive(isAlive);    
    }

    public void ApplyDamage(float damage)
    {        
        SetLife(this.life - damage);
        if(damage != 0)
        {
            CallListeners();
        }
    }

    private void CallListeners()
    {
        foreach(OnLifeChangedListener listener in onLifeChangedListeners)
        {
            listener?.Invoke(life);
        }
    }

    public void AddListener(OnLifeChangedListener listener)
    {
        if(listener == null)
        {
            throw new System.Exception("listener can't be null!");
        }
        onLifeChangedListeners.Add(listener);
    }
    public void RemoveListener(OnLifeChangedListener listener)
    {
        if(listener == null)
        {
            throw new System.Exception("listener can't be null!");
        }
        onLifeChangedListeners.Add(listener);
    }
}
