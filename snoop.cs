using System;

// Declare our variables, you dig?
string myGreeting = "What's crackin', world?";
int myAge = 50;

// Now let's write some loops, fo' shizzle
for (int i = 0; i < 5; i++)
{
    Console.WriteLine("I'm still the Doggfather, and I'm loopin' like a G");
}

while (myAge < 60)
{
    Console.WriteLine("I'm still young at heart, you know what I'm sayin'?");
    myAge++;
}


// And finally, let's create an instance of our class and call its method
SnoopDoggyDog snoop = new SnoopDoggyDog();
snoop.Name = "Snoop Dogg";
snoop.Age = 50;
snoop.Bark();

// Now let's define a class, cuz we ballers like that
public class SnoopDoggyDog
    {
    public string Name { get; set; }
    public int Age { get; set; }

    public void Bark()
    {
        Console.WriteLine("Bow wow wow yippie yo yippie yay, I'm the top dogg and I'm here to stay");
    }

}
