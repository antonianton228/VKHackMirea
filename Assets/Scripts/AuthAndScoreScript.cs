using UnityEngine;
using System;
using System.Text;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;
using Assets.SimpleVKSignIn.Scripts;
using System.IO;

[Serializable]
public struct UserScoreboard
{
	public string name;
	public int score;
}

[Serializable]
public struct Scoreboard
{
	public int status;
	public List<UserScoreboard> scoreboard;
}

public class AuthAndScoreScript : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	[SerializeField] private string backend_adress;
	
	[SerializeField] private Scoreboard scoreboard;
	
	[SerializeField] private bool is_auth = false;
	
	[SerializeField] private GameObject SucseccfulAuthUI;
	
	[SerializeField] private GameObject AlreadyAuthUI;
	
	void Start()
	{
		VKAuth.OnTokenResponse += OnTokenResponse; // Optional. Subscribe to get an access token.
		
		
		
		scoreboard.status = -1;
		StartCoroutine(get_scoreboard(backend_adress + "get_score_table?count=15"));
	}

	private static void OnTokenResponse(TokenResponse response)
	{
		Debug.Log($"Access token: {response.access_token}");
	}
	
	
	public void SignIn()
	{
		if(VKAuth.SavedAuth != null)
		{
			VKAuth.SignOut();
			AlreadyAuthUI.SetActive(true);
		}
		else
		{
			VKAuth.SignIn(OnSignIn);
			SucseccfulAuthUI.SetActive(true);
		}
	}


	private void OnSignIn(bool success, string error, UserInfo userInfo)
	{
		
		
		string json = File.ReadAllText("Assets/Save.json");
		Save save = JsonUtility.FromJson<Save>(json);
		save.is_auth = true;
		save.vkid = userInfo.id.ToString();
		
		
		StartCoroutine(authVk(userInfo.first_name, userInfo.id.ToString()));
		
		File.WriteAllText("Assets/Save.json", JsonUtility.ToJson(save));
	}


	IEnumerator get_scoreboard(string uri)
	{
		UnityWebRequest uwr = UnityWebRequest.Get(uri);
		yield return uwr.SendWebRequest();

		if (uwr.isNetworkError)
		{
			scoreboard.status = -2;
			Debug.Log("Error While Sending: " + uwr.error);
		}
		else
		{
			scoreboard = JsonUtility.FromJson<Scoreboard>(uwr.downloadHandler.text);

			Debug.Log("Received: " + uwr.downloadHandler.text);
		}
		LeaderboardManagerScript scoreboard_manadger = GetComponent<LeaderboardManagerScript>();
		scoreboard_manadger.create_list(scoreboard.scoreboard);
	}
		
		
	IEnumerator authVk(string name, string vk)
	{

		var uwr = new UnityWebRequest(backend_adress + "new_user", "POST");
		byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes("{\"name\":\"" + name + "\", \"vk\": \"" + vk + "\"}");
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

	// Update is called once per frame
	void Update()
	{
		
	}
	
}