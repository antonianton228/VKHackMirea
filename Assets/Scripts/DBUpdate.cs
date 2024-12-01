using UnityEngine;
using System;
using System.Text;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;
using Assets.SimpleVKSignIn.Scripts;
using System.IO;


public class DBUpdate : MonoBehaviour
{
	
	[SerializeField] private string backend_adress;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
	public IEnumerator update_db(Save save)
	{

		var uwr = new UnityWebRequest(backend_adress + "update_score", "POST");
		byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes("{\"score\":" + save.score + ", \"vk\": \"" + save.vkid + "\"}");
		uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
		uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
		uwr.SetRequestHeader("Content-Type", "application/json");

		//Send the request then wait here until it returns
		yield return uwr.SendWebRequest();


		if (uwr.isNetworkError)
		{
			Debug.Log("Error While Sending: " + uwr.error);
		}
		else
		{
			Debug.Log("Received: " + uwr.downloadHandler.text);
		}
	}
}
