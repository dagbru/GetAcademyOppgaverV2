public class Bottle
{
    private readonly int _capacity;
    public int Content { get; private set; }

    public Bottle(int capacity)
    {
        _capacity = capacity;
    }

    public int Empty()
    {
        var currentContent = Content;
        Content = 0;
        
        return currentContent;
    }

    public void FillToTopFromTap()
    {
        Content = _capacity;
    }

    public void Fill(int volume)
    {
        Content = Math.Min(Content + volume, _capacity);
    }

    public void FillToTop(Bottle bottle)
    {
        var maxToFill = _capacity - Content;
        var actualFillVolume = Math.Min(maxToFill, bottle.Content);
        Content += actualFillVolume;
        bottle.Content -= actualFillVolume;
    }
}