void Main(string arg)
{
	int d = 1;
	if(arg == "-1")
		d = -1;
	
	List <IMyTerminalBlock> spotlights = new List<IMyTerminalBlock>(); 
	GridTerminalSystem.GetBlocksOfType<IMyReflectorLight>(spotlights);
	for(int i = 0; i < spotlights.Count; i++)
	{
		var action = spotlights[i].GetActionWithName("OnOff_On");
		if (action != null)
			action.Apply(spotlights[i]);
	}
	
	List <IMyTerminalBlock> leftRotors = new List<IMyTerminalBlock>();
	GridTerminalSystem.SearchBlocksOfName("Rotor Left ", leftRotors);
	for(int i = 0; i < leftRotors.Count; i++)
	{
		((IMyMotorStator)leftRotors[i]).RequestEnable(true);
		((IMyMotorStator)leftRotors[i]).SetValueFloat("Velocity", 3 * d);
	}
	
	List <IMyTerminalBlock> rightRotors = new List<IMyTerminalBlock>();
	GridTerminalSystem.SearchBlocksOfName("Rotor Right ", rightRotors);
	for(int i = 0; i < rightRotors.Count; i++)
	{
		((IMyMotorStator)rightRotors[i]).RequestEnable(true);
		((IMyMotorStator)rightRotors[i]).SetValueFloat("Velocity", -3 * d);
	}
	
	for(int i = 0; i < spotlights.Count; i++)
	{
		var action = spotlights[i].GetActionWithName("OnOff_Off");
		if (action != null)
			action.Apply(spotlights[i]);
	}
}