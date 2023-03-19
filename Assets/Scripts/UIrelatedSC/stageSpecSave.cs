using System;

[Serializable]

public class stageSpecSave
{
	public int isFirst;
	public int money;
	public float backgroundR;
	public float backgroundG;
	public float backgroundB;
	public float backgroundA;
	public int backgroundDecoID;

	public stageSpecSave(int isFirst, int money, float backgroundR, float backgroundG, float backgroundB, float backgroundA, int backgroundDecoID)
	{
		this.isFirst = isFirst;
		this.money = money;
		this.backgroundR = backgroundR;
		this.backgroundG = backgroundG;
		this.backgroundB = backgroundB;
		this.backgroundA = backgroundA;
		this.backgroundDecoID = backgroundDecoID;
	}
}

