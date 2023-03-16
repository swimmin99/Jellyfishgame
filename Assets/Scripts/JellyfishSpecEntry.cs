using System;
[Serializable]
public class JellyfishSpecEntry
{
    public string[] jellyfishName = new string[30];
    public float [] size = new float[30];
    public float [] colorR = new float[30];
    public float [] colorG = new float[30];
    public float [] colorB = new float[30];
    public float [] colorA = new float[30];

    public JellyfishSpecEntry(int i, string jellyfishName, float size, float colorR, float colorG, float colorB, float colorA)
    {
        this.jellyfishName[i] = jellyfishName;
        this.size[i] = size;
        this.colorR[i] = colorR;
        this.colorG[i] = colorG;
        this.colorB[i] = colorB;
        this.colorA[i] = colorA;
    }
}

