using System;
using System.Diagnostics;

public static class PrincessGameActionHandler
{
	public static PrincessGameActionHandler.ActionDelegate OnAction;

	public static void EnlistAction(PrincessGameActionTypeID id, ObjectForDraw target, int actionCount = 1)
	{
		if (PrincessGameActionHandler.OnAction != null)
		{
			PrincessGameActionHandler.OnAction(id, target, actionCount);
		}
	}

	public delegate void ActionDelegate(PrincessGameActionTypeID id, ObjectForDraw target, int actionCount);
}
