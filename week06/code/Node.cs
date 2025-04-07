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

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else if (Left.Data == value)
                return; // If value already exists, do nothing
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else if (Right.Data == value)
                return; // If value already exists, do nothing
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

        if (value < Data)
        {
            if (Left is not null)
            {
                if (Left.Data == value)
                    return true;
                else
                    return Left.Contains(value); //Recall from Left value(subtree)
            }

        }
        else if (value > Data)
        {
            if (Right is not null)
            {
                if (Right.Data == value)
                    return true;
                else
                    return Right.Contains(value); // Recall from Right value(subtree)
            }
        }

        return false; // Value not found
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        // If the side is not null, call GetHeight() on that side
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        // Return 1 plus either the left or right, whichever is greater (max)
        return 1 + Math.Max(leftHeight, rightHeight);

    }
}