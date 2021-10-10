//задание 1
//namespace GeekBrainsTests

//класс элемента связного списка
public class ListNode
{
    //узел 
    private ListNode PrevNode;
    private ListNode NextNode;
    private int ValueNode;

    //новый элемент
    public ListNode(ListNode PrevNode, ListNode NextNode, int ValueNode)
    {
        this.PrevNode = PrevNode;
        this.NextNode = NextNode;
        this.ValueNode = ValueNode;
    }

    //замена частей узла
    public ListNode GetSetNextNode
    {
        get { return this.NextNode; }
        set { this.NextNode = value; }
    }

    public ListNode GetSetPrevNode
    {
        get { return this.PrevNode; }
        set { this.PrevNode = value; }
    }

    public int GetSetValueNode
    {
        get { return this.ValueNode; }
        set { this.ValueNode = value; }
    }
}
public interface ILinkedList
{
    int GetCount(); // число элементов списка
    void AddNode(int value);  // добавляет новый элемент списка
    void AddNodeAfter(ListNode node, int value); // добавляет новый элемент списка после определённого элемента
    void RemoveNode(int index); // удаляет элемент по индексу
    ListNode SearchNode(int index); // ищет элемент по его индексу
}

public class MyList : ILinkedList

{
    private ListNode LastNode;
    private ListNode FirstNode;

    private int count = 0;
    private object startNode;

    //число элементов списка
    public int GetCount()
    {
        return count;
    }

    //добавить элемент в список
    public void AddNode(int value)
    {
        ListNode NewNode = new ListNode(null, null, value);
        if (FirstNode == null)
        {
            FirstNode = NewNode;
        }
        else
        {
            LastNode.GetSetNextNode = NewNode;
            NewNode.GetSetPrevNode = LastNode;
        }
        count++;
    }

    //добавляет новый элемент списка после определённого элемента

    public void AddNodeAfter(ListNode node, int value)
    {
        ListNode NewNode = new ListNode(null, null, value);
        ListNode temp = FirstNode;
        NewNode.GetSetNextNode = temp;
        FirstNode = NewNode;

        if (value == 0)
        {
            FirstNode = LastNode;
        }
        else
        {
            temp.GetSetPrevNode = NewNode;
        }
        count++;
    }



    //удалить элемент по индексу
    public void RemoveNode(int index)
    {
        ListNode Prev;
        ListNode Next;

        if (index == 0)
        {
            FirstNode = SearchNode(index + 1);
            return;
        }

        Prev = SearchNode(index - 1);
        Next = SearchNode(index + 1);

        Prev.GetSetNextNode = Next;
        Next.GetSetPrevNode = Prev;

        count--;

        return;

    }


    //поиск элемента по индексу
    public ListNode SearchNode(int index)
    {
        //присваиваю первый или последний член списка
        ListNode Prev = LastNode;
        ListNode Next = FirstNode;

        //Проверка на недопустимый индекс / проход с начала / конца списка.
        if (index > count || index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        else if (index < ((count + 1) / 2))
        {
            if (index == 0)
            {
                return FirstNode;
            }

            for (; index != 0; index--)
            {
                Next = Next.GetSetNextNode;
            }

            return Next;
        }
        else
        {
            for (; index < count; index++)
            {
                Prev = Prev.GetSetPrevNode;
            }

            return Prev;
        }
    }
}




