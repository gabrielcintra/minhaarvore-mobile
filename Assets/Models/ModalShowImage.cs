﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ModalShowImage : ModalGeneric 
{
	public GameObject loadingHolder;
	public Image mapImage;

	private string location, location_lat, location_lng,
				   PLANTS_VIEW = "Plants";

	public void Start ()
	{
		if (GetViewName() == PLANTS_VIEW)
		{
			Plant currentPlant = PlantsService.plant;
			location_lat = (currentPlant.location_lat != null ? currentPlant.location_lat : "0");
			location_lng = (currentPlant.location_lng != null ? currentPlant.location_lng : "0");
		}
		else
		{
			MissionAnswer currentAnswer = MissionsService.missionAnswer;
			location_lat = (currentAnswer.location_lat != null ? currentAnswer.location_lat : "0");
			location_lng = (currentAnswer.location_lng != null ? currentAnswer.location_lng : "0");
		}

		location = location_lat + "," + location_lng;

		StartCoroutine(_UpdateImage());
	}

	private IEnumerator _UpdateImage ()
    {
    	if (location == null)
    		yield break;

    	string url = ENV.GOOGLE_MAPS_COORD_URL.Replace("PLACE", location);
    	
    	UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
		www.SetRequestHeader("Accept", "image/*");
		
		var async = www.SendWebRequest();
		while (!async.isDone)
		    yield return null;

		if (!www.isNetworkError)
		{
		    yield return new WaitForEndOfFrame();

		    byte[] results = www.downloadHandler.data;
		    Texture2D texture = new Texture2D(100, 100);

		    texture.LoadImage(results);
		    Sprite sprite = Sprite.Create(texture, new Rect(0,0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);

		    mapImage.sprite = sprite;
		    Destroy(loadingHolder);
		}
    }

}
