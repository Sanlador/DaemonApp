using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class ConsoleWidget : MonoBehaviour
{

	private float contentSize = 4096.0f;
	private float lineSize = 40.1f;
	public InputField consoleInput;
	public Text consoleOutput;
	public Scrollbar scroll;
	private VerticalLayoutGroup[] vlg;
	public GameObject content;
	uint newline_timeout = 0;


	System.Random rando = new System.Random();

	List<string> lines = new List<string>();

	void PrintLine(string line)
	{
		//while(lines.Count >= maxLineCount){
		//lines.RemoveAt(0);
		//}
		lines.Add(line);
		consoleOutput.text = string.Join("\n", lines) + "\n\n";

		scroll.value = 0.0f;//1.0f - ((lines.Count-1.0f)*lineSize / contentSize);
		Canvas.ForceUpdateCanvases();
		foreach (var v in vlg)
		{
			v.enabled = false;
			v.enabled = true;
		}
		scroll.value = 0.0f;//1.0f - ((lines.Count-1.0f)*lineSize / contentSize);
		Canvas.ForceUpdateCanvases();
		newline_timeout = 2;
		/*
		foreach(var v in vlg){
			v.enabled = false;
			v.enabled = true;
		}
		*/
		content.GetComponent<RectTransform>().sizeDelta = content.GetComponent<RectTransform>().sizeDelta + new Vector2(0, 20);
	}




	void Roll(string[] tokens)
	{
		string result = "";
		string errstr = "Invalid tokens: ";
		bool bad = false;
		char[] d = { 'd' };

		if (tokens.Length <= 1)
		{
			PrintLine("Rolls must be of form XdY.");
			return;
		}

		string[] subs = tokens[1].Split(d);
		if (subs.Length != 2)
		{
			PrintLine("Bad Roll: '" + tokens[1] + "' . \nRolls must be of form XdY.");
			return;
		}


		int count;
		int sides;
		try
		{
			count = int.Parse(subs[0]);
		}
		catch (FormatException)
		{
			PrintLine("Die count value '" + subs[0] + "' doesn't look like an integer.");
			return;
		}
		catch (OverflowException)
		{
			PrintLine("Die count value '" + subs[0] + "' is too big or too small.");
			return;
		}

		try
		{
			sides = int.Parse(subs[1]);
		}
		catch (FormatException)
		{
			PrintLine("Side count value '" + subs[1] + "' doesn't look like an integer.");
			return;
		}
		catch (OverflowException)
		{
			PrintLine("Side count value '" + subs[1] + "' is too big or too small.");
			return;
		}


		if ((sides < 0) || (count < 0))
		{
			PrintLine("Negative die count or side count values are invalid.");
			return;
		}


		int val = 0;
		string res = tokens[1] + " : ";
		for (int i = 0; i < count; i++)
		{
			int r = rando.Next(1, sides + 1);
			if ((i < 5) || (count - i < 5))
			{
				if (i != 0)
				{
					res += " + ";
				}
				res += r.ToString();
			}
			else if (i == 5)
			{
				res += " ... ";
			}
			val += r;
		}

		PrintLine(res + " = " + val.ToString());



	}


	void HandleCommand(string command)
	{

		/*
		char[] newl = { ' ', '\t' };
		string[] tokens = consoleInput.text.Split(newl, StringSplitOptions.RemoveEmptyEntries);

		string cmd = "";
		for (int i = 0; i < tokens.Length; i++)
		{
			tokens[i] = tokens[i].Trim();
			cmd += tokens[i] + " ";
		}
		Debug.Log(cmd);

		if (tokens.Length == 0)
		{
			return;
		}

		switch (tokens[0])
		{
			case "roll":
				Roll(tokens);
				break;
			case "":
				PrintLine("...");
				break;
			default:
				PrintLine("Unrecognized Command: '" + tokens[0] + "'");
				break;
		}
		*/
		DiceExpr cmd = new DiceExpr(command);
		PrintLine(ToString(cmd.Eval()));

	}


	void HandleChange()
	{
		//Debug.Log("YO");
		char[] newl = { '\n', '\r' };
		string[] commands = consoleInput.text.Split(newl);

		if (commands.Length == 1)
		{
			Debug.Log("BLUH");
			return;
		}

		for (int i = 0; i < commands.Length - 1; i++)
		{
			Debug.Log("'" + commands[i] + "'");
			HandleCommand(commands[i]);
		}
		consoleInput.text = "";
	}


	// Start is called before the first frame update
	void Start()
	{
		consoleInput = GetComponentInChildren<InputField>();
		consoleOutput = GetComponentInChildren<UnityEngine.UI.Text>();
		consoleInput.onValueChanged.AddListener(delegate { HandleChange(); });
		scroll = GetComponentInChildren<Scrollbar>();
		vlg = GetComponentsInChildren<VerticalLayoutGroup>(true);
	}

	// Update is called once per frame
	void Update()
	{
		if (newline_timeout > 0)
		{
			scroll.value = 0.0f;
			newline_timeout--;
		}
	}
}
