using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chronometer : MonoBehaviour
{
    public static Chronometer instancia;
    public Text chrono;
    private TimeSpan timeChrono;
    private bool chronoBool;
    public float timing;


    private void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        chrono.text = "00:00:00";
        chronoBool = false;

    }

    public void timeStart()
    {
        chronoBool = true;
        timing = 0F;

        StartCoroutine(timeUpdate());
    }

    public void timeEnd()
    {
        chronoBool = false;
    }

    private IEnumerator timeUpdate()
    {
        while (chronoBool)
        {
            timing += Time.deltaTime;
            timeChrono = TimeSpan.FromSeconds(timing);
            //string chronoString = timeChrono.ToString("mm':'ss':'ff");
            chrono.text = timeChrono.ToString("mm':'ss':'ff");

            yield return null;
        }
    }
}
