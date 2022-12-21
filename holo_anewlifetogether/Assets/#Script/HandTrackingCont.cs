using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class HandTrackingCont : MonoBehaviour
{

    public GameObject sphereMarker;
    public GameObject sphereMarker2;

    GameObject thumbObject;
    GameObject indexObject;

    MixedRealityPose pose;
    // Start is called before the first frame update
    void Start()
    {
        thumbObject = Instantiate(sphereMarker, this.transform);
        indexObject = Instantiate(sphereMarker2, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        thumbObject.GetComponent<Renderer>().enabled = false;
        indexObject.GetComponent<Renderer>().enabled = false;

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out pose))
        {
            thumbObject.GetComponent<Renderer>().enabled = true;
            thumbObject.GetComponent<SphereCollider>().enabled = true;
            thumbObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
        {
            indexObject.GetComponent<Renderer>().enabled = true;
            indexObject.GetComponent<SphereCollider>().enabled = true;
            indexObject.transform.position = pose.Position;
        }
        // if (TrackedHandJoint.ThumbTip)

    }
}
