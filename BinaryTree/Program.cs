using System;
using BinaryTreeLib;

class Program
{
    public static void Main()
    {
        // Создание бинарного дерева.
        BinaryTree<int> binaryTree = new BinaryTree<int>();
        
        // Заполнение бинарного дерева.
        binaryTree.Insert(6);
        binaryTree.Insert(4);
        binaryTree.Insert(9);
        binaryTree.Insert(3);
        binaryTree.Insert(10);
        
        // Такое значение уже есть, заново не добавится.
        binaryTree.Insert(6);
        
        // Вывод в прямом порядке.
        Console.WriteLine("Вывод в прямом порядке:");
        binaryTree.Preorder(binaryTree.Root);

        // Симметричный вывод.
        Console.WriteLine("\nСимметричный вывод:");
        binaryTree.Inorder(binaryTree.Root);

        // Вывод в обратном порядке.
        Console.WriteLine("\nВывод в обратном порядке:");
        binaryTree.Postorder(binaryTree.Root);

        // Поиск существующего значения.
        int value = 3;
        Console.WriteLine(binaryTree.Search(binaryTree.Root, value) == null ? $"\nЗначения {value} нет в дереве" : $"\nЗначение {value} есть в дереве");
        
        // Поиск несуществующего значения.
        value = 2;
        Console.WriteLine(binaryTree.Search(binaryTree.Root, value) == null ? $"Значения {value} нет в дереве" : $"Значение {value} есть в дереве");

        // Удаление значения.
        Console.WriteLine("Удаление значения:");
        binaryTree.Delete(binaryTree.Root, 4);
        binaryTree.Inorder(binaryTree.Root);

        // Очистка всех элементов дерева.
        Console.WriteLine("\nОчистка всех элементов дерева:");
        binaryTree.Clear(binaryTree.Root);
        binaryTree.Inorder(binaryTree.Root);
    }
}