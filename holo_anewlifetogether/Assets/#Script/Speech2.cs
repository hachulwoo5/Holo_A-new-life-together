using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Speech2 : MonoBehaviour, IMixedRealitySpeechHandler
{
    // Start is called before the first frame update
    void Start()
    {
        CoreServices.InputSystem?.RegisterHandler<IMixedRealitySpeechHandler>(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSpeechKeywordRecognized(SpeechEventData eventData)
    {
        switch(eventData.Command.Keyword.ToLower())
        {
            case "feed":
                Debug.Log("Hello world");
                break;

        }
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
