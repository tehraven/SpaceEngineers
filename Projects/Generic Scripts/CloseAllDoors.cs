void Main(string arg)
{	
	List <IMyTerminalBlock> doors = new List<IMyTerminalBlock>(); 
	GridTerminalSystem.GetBlocksOfType<IMyDoor>(doors);
	for(int i = 0; i < doors.Count; i++)
	{
        action = doors[i].GetActionWithName("OnOff_On");
		if (action != null)
			action.Apply(doors[i]);
        
		var action = doors[i].GetActionWithName("Open_Off");
		if (action != null)
			action.Apply(doors[i]);
        
        action = doors[i].GetActionWithName("OnOff_Off");
		if (action != null)
			action.Apply(doors[i]);
	}
}