namespace BinaryTreeLib;

public class BinaryTree<ElemType> where ElemType : IComparable<ElemType>
{
    // Поле с корнем.
    private BTNode<ElemType>? _root;

    // Свойство доступа к корню.
    public BTNode<ElemType>? Root => _root;

    // Конструктор без параметров.
    public BinaryTree()
    {
        _root = null;
    }

    /// <summary>
    /// Метод вставляет значение в дерево.
    /// </summary>
    /// <param name="value"> Значение для вставки. </param>
    public void Insert(ElemType value)
    {
        // Вызываем рекурсивный метод для вставки в конкретный узел.
        _root = BTNode<ElemType>.InsertValue(_root, value);
    }

    /// <summary>
    /// Метод удаляет значение в дереве, если оно присутствует.
    /// </summary>
    /// <param name="node"> Узел, в котором предположтельно находится значение. </param>
    /// <param name="value"> Значение, которое нужно удалить. </param>
    /// <returns> Возвращает узел, когда удаление завершено. </returns>
    public BTNode<ElemType>? Delete(BTNode<ElemType>? node, ElemType value)
    {
        // Если узла с таким значением нет - возвращаем пустую ссылку.
        if (node == null)
        {
            return null;
        }

        // Если значение для вставки меньше значения в текущем узле - спускаемся по левой ветке и удаляем в ней.
        if (value.CompareTo(node.Value) < 0)
        {
            node.Left = Delete(node.Left, value);
            return node;
        }
        
        // Если больше - в правой.
        if (value.CompareTo(node.Value) > 0)
        {
            node.Right = Delete(node.Right, value);
            return node;
        }
        
        // Далее ситуация, когда значение равно значению в текущем узле.
        // Если левого наследника нет, то заменяем узел на правого наследника.
        if (node.Left == null)
        {
            return node.Right;
        }
        // Если правого наследника нет, то заменяем узел на левого наследника.
        if (node.Right == null)
        {
            return node.Left;
        }

        // Если оба наследника присутствуют - спускаемся в правого и ищем там минимального кандидата на место удаляемого узла.
        ElemType newValue = FindMinOfMaxes(node.Right).Value;
        node.Value = newValue;
        node.Right = Delete(node.Right, newValue);
        return node;
    }
    
    /// <summary>
    /// Всопомгательный метод для Delete. Ищет лучшего кандидата на место удаляемого узла.
    /// </summary>
    /// <param name="node"> Правый наследник удаляемого узла. </param>
    /// <returns> Узел, который встанет на место удаляемого. </returns>
    private BTNode<ElemType> FindMinOfMaxes(BTNode<ElemType> node)
    {
        // Если левого наследника не существует - минимальным кадидатом будет сам узел (см. метод Delete).
        if (node.Left is null)
        {
            return node;
        }

        // Иначе возвращаем левого наследника.
        return node.Left;
    }

    /// <summary>
    /// Ищет в дереве поданное значение.
    /// </summary>
    /// <param name="node"> Узел, в котором преположительно находится искомое значение. </param>
    /// <param name="value"> Искомое значение. </param>
    /// <returns> Возвращает узел, в котором находится искомое значение, иначе - пустую ссылку. </returns>
    public BTNode<ElemType>? Search(BTNode<ElemType>? node, ElemType value)
    {
        // Если такого узла не существует или значение узла совпало с искомым - возвращаем его.
        if (node is null || node.Value.CompareTo(value) == 0)
        {
            return node;
        }

        // Если искомое значение меньше значения в узле - спускаемся в левого наследника и ищем там.
        if (value.CompareTo(node.Value) < 0)
        {
            return Search(node.Left, value);
        }

        // Иначе - в правого.
        return Search(node.Right, value);
    }

    /// <summary>
    /// Выводит дерево в прямом порядке.
    /// </summary>
    /// <param name="node"> Корень текущего поддерева. </param>
    public void Preorder(BTNode<ElemType>? node)
    {
        // Если узла не существует - возвращаемся на уровень выше.
        if (node == null)
        {
            return;
        }

        // Выводим значение в текущем узле.
        Console.Write($"{node.Value} ");
        
        // Спускаемся в левое поддерево и выводим его.
        Preorder(node.Left);
        
        // Спускаемся в правое поддерево и выводим его.
        Preorder(node.Right);
    }
    
    /// <summary>
    /// Выводит дерево в обратном порядке.
    /// </summary>
    /// <param name="node"> Корень текущего поддерева. </param>
    public void Postorder(BTNode<ElemType>? node)
    {
        // Если узла не существует - возвращаемся на уровень выше.
        if (node == null)
        {
            return;
        }

        // Выводим значение в текущем узле.
        Console.Write($"{node.Value} ");
        
        // Спускаемся в правое поддерево и выводим его.
        Postorder(node.Right);
        
        // Спускаемся в левое поддерево и выводим его.
        Postorder(node.Left);
    }
    
    /// <summary>
    /// Выводит дерево в симметричном порядке (порядке возрастания).
    /// </summary>
    /// <param name="node"> Корень текущего поддерева. </param>
    public void Inorder(BTNode<ElemType>? node)
    {
        // Если узла не существует - возвращаемся на уровень выше.
        if (node == null)
        {
            return;
        }
        
        // Спускаемся в левое поддерево и выводим его.
        Inorder(node.Left);
        
        // Выводим значение в текущем узле.
        Console.Write($"{node.Value} ");
        
        // Спускаемся в правое поддерево и выводим его.
        Inorder(node.Right);
    }

    /// <summary>
    /// Метод очищает все элементы дерева.
    /// </summary>
    /// <param name="node"> Корень текущего поддерева. </param>
    public void Clear(BTNode<ElemType>? node)
    {
        // Если узла не существует - возвращаемся на уровень выше.
        if (node == null)
        {
            return;
        }
        
        // Очищаем левое поддерево и ссылку на его корень.
        Clear(node.Left);
        node.Left = null;
        
        // Затем - правое.
        Clear(node.Right);
        node.Right = null;
        
        // Очищаем корень текущего поддерева.
        _root = null;
    }
}