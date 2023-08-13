using DataStructures.Node;

var red = new SingleNode("red");
var orange = new SingleNode("orange");
var yellow = new SingleNode("yellow");
var green = new SingleNode("green");
var blue = new SingleNode("blue");
var indigo = new SingleNode("indigo");
var violet = new SingleNode("violet");

red.SetNextNode(orange);
orange.SetNextNode(yellow);
yellow.SetNextNode(green);
green.SetNextNode(blue);
blue.SetNextNode(indigo);
indigo.SetNextNode(violet);

var currentNode = red;

while (currentNode != null)
{
    Console.WriteLine(currentNode.ToString());
    currentNode = (SingleNode?)currentNode.GetNextNode();
}

Console.WriteLine("Done.");

Console.WriteLine("Double Linked List using Chromatic Music Notation");
Console.ReadLine();

Console.WriteLine(new string('*', 64));

var c = new DoubleNode("C");
var d = new DoubleNode("D");
var e = new DoubleNode("E");
var f = new DoubleNode("F");
var g = new DoubleNode("G");
var a = new DoubleNode("A");
var b = new DoubleNode("B");

Console.WriteLine("Ode to Joy Melody");
Console.WriteLine(new string('-', 64));

// Notes for "Ode to Joy" melody
var notes = new string[] { "E", "E", "F", "G", "G", "F", "E", "D", "C", "D", "E", "E", "D", "E", "E", "F", "G", "G", "F", "E", "D", "C", "D", "E", "D", "D", "E", "F", "E", "D", "D", "E", "F", "E", "F", "E", "D", "D", "G", "G", "E", "E", "F", "G", "G", "E", "F", "E", "F", "D", "D", "D", "D", "E", "E", "F", "E", "F", "D", "E", "F", "E", "F", "F", "G", "E", "D", "F", "E", "F", "E", "F", "F", "E", "F", "F", "F", "F", "F", "E", "F", "F", "E", "F", "F", "F", "F", "E", "F", "F", "E", "F", "F", "F", "F", "E", "F", "F", "E", "F" };

// Create and link the nodes
DoubleNode? head = null;
DoubleNode? current = null;

foreach (var note in notes)
{
    var next = new DoubleNode(note);

    if (head == null)
    {
        head = next;
    }
    else
    {
        current!.SetNextNode(next);
        next.SetPrevNode(current);
    }

    current = next;
}

// Display the melody
Console.WriteLine(string.Join(", ", notes));

current = head;

while (current != null)
{
    Console.WriteLine(current.ToString());
    current = (DoubleNode?)current.GetNextNode();
    Console.ReadLine();
}
