using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class controller : MonoBehaviour 
{
	public static bool[] connected = new bool[4];
	public static PlayerIndex[] playerIndex = new PlayerIndex[4];
	public static GamePadState[] state = new GamePadState[4];
	public static GamePadState[] prevState = new GamePadState[4];
	
	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < 4; ++i)
		{
			connected[i] = false;
		}
		
		GamePad.SetVibration ((PlayerIndex)1, 0f, 0f);

		//GamePad.SetVibration (playerIndex [2], 0f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < 4; ++i)
		{
			if (!connected[i])
			{
				PlayerIndex testPlayerIndex = (PlayerIndex)i;
				GamePadState testState = GamePad.GetState(testPlayerIndex);
				if (testState.IsConnected)
				{
					state[i] = testState;
					playerIndex[i] = testPlayerIndex;
					connected[i] = true;
				}
			}
			else
			{
				//Update input.
				prevState[i] = state[i];
				state[i] = GamePad.GetState(playerIndex[i]);
			}
		}
	}
}
