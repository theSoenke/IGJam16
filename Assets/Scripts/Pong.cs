using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pong : MonoBehaviour
{
	public Image image;
	private Texture2D texture;

	const int width = 600;
	const int height = 450;

	const int ballSize = 10;
	const int flipperHeight = 50;
	const float relFlipperSize = (float)flipperHeight / (float)height;

	float dx;
	float dy;

	float posX;
	float posY;

	float playerPos;
	float enemyPos;

	int playerScore;
	int enemyScore;

	float velY;
	float startVel;
	float dtSinceKeyPress;

	void ClearTexture ()
	{
		for (int i = 0; i < width; i++)
			for (int j = 0; j < height; j++)
				texture.SetPixel (i, j, new Color (0f, 0f, 0f, 1f));
	}

	int GetBallPosY (float y)
	{
		const int activeHeight = height - ballSize;
		return Mathf.Max(Mathf.Min (Mathf.RoundToInt (y * activeHeight), activeHeight), 0);
	}

	void DrawBallWithColor (Color c)
	{
		int startPosX = ballSize + Mathf.RoundToInt (posX * (width - 3 * ballSize));
		int startPosY = GetBallPosY (posY);

		for (int x = startPosX; x < startPosX + ballSize; x++)
			for (int y = startPosY; y < startPosY + ballSize; y++)
				texture.SetPixel (x, y, c);
	}

	void ClearBall ()
	{
		DrawBallWithColor (new Color (0, 0, 0, 1));
	}

	void DrawBall ()
	{
		DrawBallWithColor (new Color (1, 1, 1, 1));
	}

	void DrawFlipperWithColor (int startPosX, int startPosY, Color c)
	{
		for (int x = startPosX; x < startPosX + ballSize; x++)
			for (int y = startPosY; y < startPosY + flipperHeight; y++)
				texture.SetPixel (x, y, c);
	}

	int GetFlipperPos (float y)
	{
		const int activeHeight = height - flipperHeight;
		return Mathf.Max(Mathf.Min (Mathf.RoundToInt (y * activeHeight), activeHeight), 0);
	}

	void ClearFlipper ()
	{
		int playerX = 0;
		int playerY = GetFlipperPos (playerPos);
		int enemyX = width - ballSize - 1;
		int enemyY = GetFlipperPos (enemyPos);

		DrawFlipperWithColor (playerX, playerY, new Color (0, 0, 0, 1));
		DrawFlipperWithColor (enemyX, enemyY, new Color (0, 0, 0, 1));
	}

	void DrawFlipper ()
	{
		int playerX = 0;
		int playerY = GetFlipperPos (playerPos);
		int enemyX = width - ballSize - 1;
		int enemyY = GetFlipperPos (enemyPos);

		DrawFlipperWithColor (playerX, playerY, new Color (1, 1, 1, 1));
		DrawFlipperWithColor (enemyX, enemyY, new Color (1, 1, 1, 1));
	}

	void DrawScoreWithColor (Color c)
	{
		int startPosX = ballSize + Mathf.RoundToInt (posX * (width - 3 * ballSize));
		int startPosY = Mathf.RoundToInt (posY * (height - ballSize));

		for (int x = startPosX; x < startPosX + ballSize; x++)
			for (int y = startPosY; y < startPosY + ballSize && y < height && y >= 0; y++)
				texture.SetPixel (x, y, c);
	}

	void ClearScore ()
	{
		//DrawFlipperWithColor (new Color (0, 0, 0, 1));
		//DrawFlipperWithColor (new Color (0, 0, 0, 1));
	}

	void DrawScore ()
	{
		//DrawFlipperWithColor (new Color (1, 1, 1, 1));
		//DrawFlipperWithColor (new Color (0, 0, 0, 1));
	}

	void ResetBall ()
	{
		dx = 0.0f;
		while (Mathf.Abs (dx) < 0.006)
			dx = Random.Range (-0.01f, 0.01f);
		dy = Random.Range (-0.01f, 0.01f);
		float len = 60f * Mathf.Sqrt (dx * dx + dy * dy);
		dx /= len;
		dy /= len;

		posX = 0.5f;
		posY = 0.5f;
	}

	void Start ()
	{
		texture = new Texture2D (width, height);
		Sprite sprite = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), new Vector2 (0.5f, 0.5f));
		image.sprite = sprite;

		ResetBall ();
			
		playerPos = 0.5f;
		enemyPos = 0.5f;

		posX = 0.5f;
		posY = 0.5f;

		ClearTexture ();
		texture.Apply ();
	}

	float Interpolate (float a, float b, float factor)
	{
		factor = Mathf.Min (1.0f, Mathf.Max (0.0f, factor));
		return a * (1.0f - factor) + factor * b;
	}

	bool BounceAt(float flipper) {
		float len = Mathf.Sqrt (dx * dx + dy * dy);
		float absBall = posY * (float)(height - ballSize) + ballSize / 2.0f;
		float absFlipper = flipper * (float)(height - flipperHeight) + flipperHeight / 2.0f;
		float relPos = (float)(absBall - absFlipper) / (0.5f * flipperHeight);

		if (Mathf.Abs (relPos) >= 1.0)
			return false;

		relPos *= 0.4f * Mathf.PI;
		Debug.Log (Mathf.Cos (relPos));
		dx = -Mathf.Sign(dx) * Mathf.Cos (relPos);
		dy = Mathf.Sin (relPos);

		float newLen = Mathf.Sqrt (dx * dx + dy * dy);
		dx = dx / newLen * len;
		dy = dy / newLen * len;
		return true;
	}

	void Update ()
	{
		ClearBall ();
		ClearFlipper ();
		ClearScore ();

		// handle player

		dtSinceKeyPress += Time.deltaTime;
		if (Input.GetKey (KeyCode.UpArrow)) {
			velY += 0.01f;
			startVel = velY;
			dtSinceKeyPress = 0.0f;
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			velY -= 0.01f;
			startVel = velY;
			dtSinceKeyPress = 0.0f;
		} else {
			if (Mathf.Abs (velY) < 0.0001f)
				velY = 0.0f;
			else
				velY = Interpolate (velY, 0.0f, 3.0f * dtSinceKeyPress);
		}

		velY = Mathf.Clamp (velY, -0.04f, 0.04f);
		playerPos += velY;

		if (playerPos > 1.0f) {
			velY = 0.0f;
			playerPos = 1.0f;
		}

		if (playerPos < 0.0f) {
			velY = 0.0f;
			playerPos = 0.0f;
		}

		// handle enemy
			
		float diff = posY - enemyPos;
		float enemyVelY = Mathf.Clamp (diff, -0.02f, 0.02f);
		enemyPos += enemyVelY;

		if (enemyPos > 1.0f) {
			enemyPos = 1.0f;
		}

		if (enemyPos < 0.0f) {
			enemyPos = 0.0f;
		}

		// handle ball

		posX += dx;
		posY += dy;

		if (posX > 1.0f) {
			// @ enemy
			posX = 1.0f;
			if (!BounceAt(enemyPos)) {
				playerScore++;
				ResetBall ();
			}
		}
		if (posX < 0.0f) {
			// @player
			posX = 0.0f;
			if (!BounceAt(playerPos)) {
				enemyScore++;
				ResetBall ();
			}
		}

		if (posY >= 1.0f || posY < 0.0f)
			dy = -dy;

		DrawScore ();
		DrawBall ();
		DrawFlipper ();
		texture.Apply ();

		Sprite sprite = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), new Vector2 (0.5f, 0.5f));
		image.sprite = sprite;
	}
}