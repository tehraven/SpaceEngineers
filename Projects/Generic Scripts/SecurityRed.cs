void Main(string arg)
{
    List<IMyTerminalBlock> blocklist = new List<IMyTerminalBlock>();
    GridTerminalSystem.GetBlocksOfType<IMyAirtightHangarDoor>(blocklist);
    
    IMyTextPanel screen = ((IMyTextPanel)GridTerminalSystem.GetBlockWithName("Text: Security Red"));
    screen.WritePublicText("Found " + blocklist.Count + " Blocks");
    
    if(blocklist.Count <= 0)
        return;
    
    for(int i = 0; i < blocklist.Count; i++)
    {
        var action = blocklist[i].GetActionWithName("OnOff_On");
		if (action != null)
			action.Apply(blocklist[i]);
        
        action = blocklist[i].GetActionWithName("Open_Off");
		if (action != null)
			action.Apply(blocklist[i]);
    }
}