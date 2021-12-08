using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VuforiaObjectController : MonoBehaviour
{
    private bool onTracking = false;
    public static List<VuforiaObjectController> Controllers = new List<VuforiaObjectController>();

    public bool OnTracking
    {
        get { return onTracking; }
    }

    public Vector3 ScreenPosition
    {
        get { return Camera.main.ScreenToWorldPoint(this.transform.position); }
    }

    public VuforiaObjectController()
    {
        Controllers.Add(this);
    }

    ~VuforiaObjectController()
    {
        if (Controllers != null && Controllers.Contains(this))
        {
            Controllers.Remove(this);
        }
    }

    protected virtual void OnTrackingFoundMessage()
    {
        onTracking = true;
    }

    protected virtual void OnTrackingLostMessage()
    {
        onTracking = false;
    }
}
