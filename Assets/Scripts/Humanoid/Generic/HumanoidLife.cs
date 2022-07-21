using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnLifeChangedListener(float life); 

public class HumanoidLife : MonoBehaviour
{
    [SerializeField]
    private float life = 100;

    public bool isAlive = true;

    public GameObject onDieInstantiateObject;
    public BattleController battleController;
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

        UpdateAliveState(null);
    }

    public async void ApplyDamage(object[] args)
    { 
        ApplyDamage((float)args[0], args[1] as GameObject);
    }

    public void ApplyDamage(float damage, GameObject from)
    {                
        if(damage != 0)
        {
            this.life -= damage;
            CallListeners();
            UpdateAliveState(from);
        }
    }

    private void UpdateAliveState(GameObject killFrom)
    {
        isAlive = this.life > 0;
        gameObject.SetActive(isAlive);    
        if(this.life <= 0)
        {
            Die(killFrom);
        }   
    }

    public void Die(GameObject killFrom)
    {
        if(onDieInstantiateObject != null)
        {
            GameObject.Instantiate(onDieInstantiateObject, this.transform.position, this.transform.rotation);
        }
        if(killFrom == null)
        {
            // means a suicide
            killFrom = gameObject;
        }
        battleController.RegisterKill(gameObject, killFrom);
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
