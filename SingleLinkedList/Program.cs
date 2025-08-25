

using SingleLinkedList;

LinkedList list = new LinkedList(); 
list.InsertTail(1);
List<int> printList = list.GetValues();

//foreach(int value in printList)
//{
//    Console.WriteLine(value);
//}
//Console.WriteLine($"head points to: {list.head.nextNode.value}");
//Console.WriteLine($"tail points to: {list.tail.nextNode.value}");
//Console.WriteLine("___");

list.InsertTail(2);
printList = list.GetValues();

Console.WriteLine(list.Get(1));
//foreach (int value in printList)
//{
//    Console.WriteLine(value);
//}
//Console.WriteLine($"head points to: {list.head.nextNode.value}");
//Console.WriteLine($"tail points to: {list.tail.nextNode.value}");
//Console.WriteLine("___");

list.Remove(1);
printList = list.GetValues();


//foreach (int value in printList)
//{
//    Console.WriteLine(value);
//}
//Console.WriteLine($"head points to: {list.head.nextNode.value}");
//Console.WriteLine($"tail points to: {list.tail.nextNode.value}");
//Console.WriteLine("___");

list.InsertTail(2);
Console.WriteLine(list.Get(1));
Console.WriteLine(list.Get(0));

//Console.WriteLine($"head points to: {list.head.nextNode.value}");
//Console.WriteLine($"tail points to: {list.tail.nextNode.value}");
//Console.WriteLine("___");



