﻿using UnityEngine;
using System;
using System.Text;
using System.Security.Cryptography;

public static class UserService
{
	private static User _user;
	public static User user
	{
        get { return _user; }
    }

	public static WWW Login (string email, string password)
	{
		WWWForm loginForm = new WWWForm ();
		loginForm.AddField ("email", email);
		loginForm.AddField ("password", password);

		if (PlayerPrefs.HasKey("MinhaArvore:Conectar"))
		{
			PlayerPrefs.SetString("MinhaArvore:Email", email);
			PlayerPrefs.SetString("MinhaArvore:Senha", password);
		}

		WebService.route = ENV.USERS_ROUTE;
		WebService.action = ENV.AUTH_ACTION;

		return WebService.Post(loginForm);
	}

	public static WWW Register (User user)
	{
		WWWForm registerForm = new WWWForm();
		registerForm.AddField ("name", user.name);
		registerForm.AddField ("email", user.email);
		registerForm.AddField ("password", user.password);
		
		WebService.route = ENV.USERS_ROUTE;
		WebService.action = ENV.REGISTER_ACTION;

		return WebService.Post(registerForm);
	}

	public static WWW Update (User user)
	{
		WWWForm updateForm = new WWWForm();
		updateForm.AddField ("name", user.name);
		updateForm.AddField ("email", user.email);
		updateForm.AddField ("sex", user.sex);
		updateForm.AddField ("phone", user.phone);

		Debug.Log("passed birth:" + user.birth);
		updateForm.AddField ("birth", UtilsService.GetInverseDate(user.birth));
		updateForm.AddField ("password", user.password);
		updateForm.AddField ("street", user.street);
		updateForm.AddField ("complement", user.complement);
		updateForm.AddField ("number", user.number);
		updateForm.AddField ("neighborhood", user.neighborhood);
		updateForm.AddField ("city", user.city);
		updateForm.AddField ("state", user.state);
		updateForm.AddField ("zipcode", user.zipcode);

		WebService.route = ENV.USERS_ROUTE;
		WebService.action = ENV.UPDATE_ACTION + "/" + user._id;

		return WebService.Post(updateForm);
	}

	public static void UpdateLocalUser (User newUser)
	{
		_user = newUser;
	}

	public static void UpdateLocalUser (string json)
	{
		_user = JsonUtility.FromJson<User>(json);
	}

}