public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            return Left is not null && Left.Contains(value);
        }
        else if (value > Data)
        {
            return Right is not null && Right.Contains(value);
        }

        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = 0;
        if (Left is not null)
        {
            leftHeight = Left.GetHeight();
        }

        int rightHeight = 0;
        if (Right is not null)
        {
            rightHeight = Right.GetHeight();
        }

        return 1 + Math.Max(leftHeight, rightHeight);

    }
}