namespace BinaryTreeLib;

public class BTNode<ValType> where ValType : IComparable<ValType>
{
    // Значение в узле.
    private ValType _value;
    
    // Левый наследник.
    private BTNode<ValType>? _left;
    
    // Правый наследник.
    private BTNode<ValType>? _right;

    // Свойство досутпа к левому наследнику.
    public BTNode<ValType>? Left
    {
        set => _left = value;
        get => _left;
    }
    
    // Свойство досутпа к правому наследнику.
    public BTNode<ValType>? Right
    {
        set => _right = value;
        get => _right;
    }

    // Свойство досутпа к значению.
    public ValType Value
    {
        get => _value;
        set => _value = value;
    }

    /// <summary>
    /// Конструктор с параметром значения.
    /// </summary>
    /// <param name="value"> Значение, с которым создается узел. </param>
    public BTNode(ValType value)
    {
        _value = value;
        _left = null;
        _right = null;
    }

    /// <summary>
    /// Вставляет значение в узел или его наследников.
    /// </summary>
    /// <param name="node"> Узел, в которое предположтельно вставляется значение. </param>
    /// <param name="value"> Значение, которое нужно вставить. </param>
    /// <returns> Возвращает узел, когда вставка завершена. </returns>
    public static BTNode<ValType> InsertValue(BTNode<ValType>? node, ValType value)
    {
        // Если такого значения в дереве нет - создаем новый узел.
        if (node == null)
        {
            return new BTNode<ValType>(value);
        }

        // Если значение для вставки меньше значения в текущем узле - спускаемся по левой ветке и вставляем в нее.
        if (value.CompareTo(node.Value) < 0)
        {
            node.Left = InsertValue(node.Left, value);
        }
        // Если больше - в правую.
        else if (value.CompareTo(node.Value) > 0)
        {
            node.Right = InsertValue(node.Right, value);
        }

        // Возвращаем узел, когда вставка завершена. 
        return node;
    }
}