class Vertex
{
    int x;
    int y;
    string name;

    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public string GetName
    {
        get { return name; }
    }

    public Vertex(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.name = "";
    }

    public Vertex(string name, int x, int y)
    {
        this.x = x;
        this.y = y;
        this.name = name;
    }

}


public class Flow
{
    int v1;
    int v2;
    int flow;

    public Flow(int v1, int v2, int f)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.flow = f;
    }

    public int GetV1
    {
        get { return v1; }

    }

    public int GetV2
    {
        get { return v2; }

    }

    public int GetF
    {
        get { return flow; }

    }

}