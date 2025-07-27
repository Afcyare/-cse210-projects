public class Video
{
    public string _title;
    public string _author;
    public int _lenght;

    public List<Comment> _comments = new List<Comment>();

    public Video()
    {

    }
    public Video(string title, string author, int lenght)
    {
        _title = title;
        _author = author;
        _lenght = lenght;
    }

    public void AddComments(Comment add)
    {
        _comments.Add(add);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

}