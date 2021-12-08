using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWidowController : VuforiaObjectController
{
    protected override void OnTrackingFoundMessage()
    {
        base.OnTrackingFoundMessage();
        Debug.Log("OnTrackingFoundMessage(): " + this.name);
    }

    protected override void OnTrackingLostMessage()
    {
        base.OnTrackingLostMessage();
        Debug.Log("OnTrackingLostMessage(): " + this.name);
    }
}
