using System;
using System.Collections.Generic;


namespace Goldilocks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the characters
            Bear papaBear = new Bear("Papa", "big", "hot");
            Bear mamaBear = new Bear("Mama", "medium", "warm");
            Bear babyBear = new Bear("Baby", "small", "cold");
            Human goldilocks = new Human("Goldilocks", "blonde");

            // Create the house
            House house = new House();
            house.AddBowl(papaBear);
            house.AddBowl(mamaBear);
            house.AddBowl(babyBear);
            house.AddChair(papaBear);
            house.AddChair(mamaBear);
            house.AddChair(babyBear);
            house.AddBed(papaBear);
            house.AddBed(mamaBear);
            house.AddBed(babyBear);

            // The bears go for a walk
            Console.WriteLine("Once upon a time, there were three bears who lived in a house in the forest.");
            Console.WriteLine("{0} Bear, {1} Bear and {2} Bear.", papaBear.Name, mamaBear.Name, babyBear.Name);
            Console.WriteLine("One morning, they made porridge for breakfast, but it was too {0}.", papaBear.Temperature);
            Console.WriteLine("So they decided to go for a walk in the forest and let it cool down.");

            // Goldilocks arrives at the house
            Console.WriteLine("While they were away, a girl named {0} came to the house.", goldilocks.Name);
            Console.WriteLine("She had {0} hair and was very curious.", goldilocks.HairColor);
            Console.WriteLine("She saw the three bowls of porridge on the table and decided to try them.");

            // Goldilocks tries the porridge
            foreach (Bowl bowl in house.Bowls)
            {
                Console.WriteLine("She tasted the porridge from the {0} bowl.", bowl.Size);
                if (bowl.Temperature == "hot")
                {
                    Console.WriteLine("It was too {0}! She burned her tongue and spat it out.", bowl.Temperature);
                }
                else if (bowl.Temperature == "cold")
                {
                    Console.WriteLine("It was too {0}! She made a face and pushed it away.", bowl.Temperature);
                }
                else if (bowl.Temperature == "warm")
                {
                    Console.WriteLine("It was just right! She ate it all up.");
                    bowl.IsEmpty = true;
                }
            }

            // Goldilocks tries the chairs
            Console.WriteLine("She was still hungry, so she looked around and saw three chairs.");
            foreach (Chair chair in house.Chairs)
            {
                Console.WriteLine("She sat on the {0} chair.", chair.Size);
                if (chair.Size == "big")
                {
                    Console.WriteLine("It was too {0}! She felt like she was sinking into a marshmallow.", chair.Size);
                }
                else if (chair.Size == "small")
                {
                    Console.WriteLine("It was too {0}! She heard a crack and the chair broke under her weight.", chair.Size);
                    chair.IsBroken = true;
                }
                else if (chair.Size == "medium")
                {
                    Console.WriteLine("It was just right! She felt comfortable and cozy.");
                }
            }

            // Goldilocks tries the beds
            Console.WriteLine("She was feeling tired, so she went upstairs and saw three beds.");
            foreach (Bed bed in house.Beds)
            {
                Console.WriteLine("She lay down on the {0} bed.", bed.Size);
                if (bed.Size == "big")
                {
                    Console.WriteLine("It was too {0}! She felt like she was floating on a cloud.", bed.Size);
                }
                else if (bed.Size == "small")
                {
                    Console.WriteLine("It was too {0}! She felt cramped and squished.", bed.Size);
                }
                else if (bed.Size == "medium")
                {
                    Console.WriteLine("It was just right! She fell asleep and snored softly.");
                    bed.IsOccupied = true;
                }
            }

            // The bears return home
            Console.WriteLine("Soon, the three bears came back from their walk.");
            Console.WriteLine("They saw that someone had been in their house.");

            // The bears notice the porridge
            foreach (Bowl bowl in house.Bowls)
            {
                Console.WriteLine("{0} Bear said, \"Someone's been eating my porridge!\"", bowl.Owner.Name);
                if (bowl.IsEmpty)
                {
                    Console.WriteLine("And they've eaten it all up!");
                }
            }

            // The bears notice the chairs
            foreach (Chair chair in house.Chairs)
            {
                Console.WriteLine("{0} Bear said, \"Someone's been sitting on my chair!\"", chair.Owner.Name);
                if (chair.IsBroken)
                {
                    Console.WriteLine("And they've broken it!");
                }
            }

            // The bears notice the beds
            foreach (Bed bed in house.Beds)
            {
                Console.WriteLine("{0} Bear said, \"Someone's been sleeping on my bed!\"", bed.Owner.Name);
                if (bed.IsOccupied)
                {
                    Console.WriteLine("And they're still there!");
                    // The bears see Goldilocks
                    Console.WriteLine("The bears saw {0} sleeping on the {1} bed.", goldilocks.Name, bed.Size);
                    Console.WriteLine("{0} woke up and saw the three bears staring at her.", goldilocks.Name);
                    Console.WriteLine("She was so scared that she jumped out of the bed and ran out of the house.");
                    Console.WriteLine("She never came back to the house of the three bears.");
                    Console.WriteLine("The end.");
                    break;
                }
            }
        }
    }

    // Define the classes
    class Bear
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Temperature { get; set; }

        public Bear(string name, string size, string temperature)
        {
            Name = name;
            Size = size;
            Temperature = temperature;
        }
    }

    class Human
    {
        public string Name { get; set; }
        public string HairColor { get; set; }

        public Human(string name, string hairColor)
        {
            Name = name;
            HairColor = hairColor;
        }
    }

    class House
    {
        public List<Bowl> Bowls { get; set; }
        public List<Chair> Chairs { get; set; }
        public List<Bed> Beds { get; set; }

        public House()
        {
            Bowls = new List<Bowl>();
            Chairs = new List<Chair>();
            Beds = new List<Bed>();
        }

        public void AddBowl(Bear owner)
        {
            Bowl bowl = new Bowl(owner.Size, owner.Temperature, owner);
            Bowls.Add(bowl);
        }

        public void AddChair(Bear owner)
        {
            Chair chair = new Chair(owner.Size, owner);
            Chairs.Add(chair);
        }

        public void AddBed(Bear owner)
        {
            Bed bed = new Bed(owner.Size, owner);
            Beds.Add(bed);
        }
    }

    class Bowl
    {
        public string Size { get; set; }
        public string Temperature { get; set; }
        public bool IsEmpty { get; set; }
        public Bear Owner { get; set; }

        public Bowl(string size, string temperature, Bear owner)
        {
            Size = size;
            Temperature = temperature;
            IsEmpty = false;
            Owner = owner;
        }
    }

    class Chair
    {
        public string Size { get; set; }
        public bool IsBroken { get; set; }
        public Bear Owner { get; set; }

        public Chair(string size, Bear owner)
        {
            Size = size;
            IsBroken = false;
            Owner = owner;
        }
    }

    class Bed
    {
        public string Size { get; set; }
        public bool IsOccupied { get; set; }
        public Bear Owner { get; set; }

        public Bed(string size, Bear owner)
        {
            Size = size;
            IsOccupied = false;
            Owner = owner;
        }
    }
}