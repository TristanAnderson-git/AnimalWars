using System.Collections;
using UnityEngine;

public abstract class Building : Entity
{
    public float refreshTime = 0.0f;
    public float buildTime = 1.0f;
    public bool placed = false;

    [HideInInspector]
    public float progress = 0.0f;

    protected Coroutine currentState = null;

    public void Spawn()
    {
        if (currentState == null)
            StartCoroutine(Build());
    }

    private void Update()
    {
        CheckHealth();
    }

    private IEnumerator Build()
    {
        float time = 0.0f;
        
        while (health > 0)
        {
            if (progress >= 1.0f)
            {
                progress = 0.0f;
                currentState = null;

                StartTask();
                break;
            }

            yield return null;

            time += Time.deltaTime;
            progress = time / refreshTime;
        }
    }

    private void StartTask()
    {
        if (currentState == null)
            currentState = StartCoroutine(Task());
    }

    private IEnumerator Task()
    {
        float time = 0.0f;

        while(health > 0)
        {
            if (progress >= 1.0f)
            {
                Perform();
                progress = 0.0f;
                time = 0.0f;
            }

            yield return null;

            time += Time.deltaTime;
            progress = time / refreshTime;
        }
    }

    public abstract void Perform();
}
