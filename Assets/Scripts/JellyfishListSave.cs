using System;

[Serializable]
public class JellyfishListSave
{
    public string jellyfishName;
    public float size;
    public int originalPrice;

    public float color1_x;
    public float color1_y;
    public float color1_z;
    public float color1_a;

    public float color2_x;
    public float color2_y;
    public float color2_z;
    public float color2_a;


    public JellyfishListSave(string jellyfishName,
    float size,
    int originalPrice,
    float color1_x,
    float color1_y,
    float color1_z,
    float color1_a,

    float color2_x,
    float color2_y,
    float color2_z,
    float color2_a)
    {
        this.jellyfishName = jellyfishName;
        this.size = size;
        this.originalPrice = originalPrice;
        this.color1_x = color1_x;
        this.color1_y = color1_y;
        this.color1_z = color1_z;
        this.color1_a = color1_a;

        this.color2_x = color2_x;
        this.color2_y = color2_y;
        this.color2_z = color2_z;
        this.color2_a = color2_a;
}
}
