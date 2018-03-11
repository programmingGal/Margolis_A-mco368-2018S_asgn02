using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSystem_Assignment_2
{
    // This program simulates a system of computers

    class Program
    {
        static void Main(string[] args)
        {
            int cloudStorage = 500;
            int networkSpeed = 1000;

            // default prototype computer with hardcoded  properties
            Computer defaultMachine = new Computer("55");
            defaultMachine.HasCellularAntenna = null;
            defaultMachine.HardDriveCapacity = 8.2;
            defaultMachine.RAM = 2000;
            int?[] softwareLicenses = { 4, 2, 0, 0 ,null};
            defaultMachine.NumLicenses = softwareLicenses;

            //user prototype, waiting for user to set properties
            Computer userPrototype = null;

            Computer[] computers;
            int size = 0; // # of computes added to the network

            Console.WriteLine("What is the maximum number of computers you will need to track?");

            int number;

            bool validValue = getIntFromUser(out number, 5, 20, 10);

            // if user entered a value within range of 5-20:
            if (validValue)
            {
                computers = new Computer[number];
            }
            //default to 10 and let user know:
            else
            {
                computers = new Computer[10];
                Console.WriteLine("Value entered was invalid. Max number of computers to track was set to 10.");
            }


            int choice;
            menu(out choice);

            while (choice != 11)
            {
                switch (choice)
                {
                    case 1:
                                        addAComputer(computers, ref size);
                        
                   break;
                    case 2:
                                        setUserPrototype(out userPrototype);
                        break;
                    case 3:
                                        //remove user prototype
                                        userPrototype = null;
                        break;
                    case 4:
                                        upgradeCloudStorage(ref cloudStorage);
                        break;
                    case 5:
                                      downgradeCloudStorage(ref cloudStorage);
                        break;
                    case 6:
                                        upgradeNetworkSpeed(ref networkSpeed);
                        break;
                    case 7:
                                        downgradeNetworkSpeed(ref networkSpeed);
                        break;
                    case 8:
                                        getSummaryOfAComputer(computers, defaultMachine, cloudStorage,networkSpeed);
                        break;
                     case 9:
                                         getStatisticsForAllComputers(computers, size, cloudStorage,networkSpeed);
                         break;
                    /* case 10:
                                         getStatisticsForSpecificComputers(computers, userPrototype ?? defaultMachine,cloudStorage,networkSpeed);
                         break;
               */
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }//end switch

                menu(out choice);
            }//end while


            Console.ReadKey();
        }

        public static void menu(out int choice)
        {
            Console.WriteLine("\n\nPlease choose from the following menu options:" +
                "\n1. Add a Computer to the network\n2. Enter the details of a prototype computer\n3. Remove the prototype computer" +
                "\n4. Upgrade your cloud storage\n5. Downgrade your cloud storage\n6. Upgrade your network speed.\n7. Downgrade your network speed." +
                "\n8. Get a summary of a specific computer on the network.\n9. Get a summary of statistics for all computers on the network." +
                "\n10.Get a summary of statistics for specific computers on the network.\n11. Quit the program. ");

                choice = Int32.Parse( Console.ReadLine());
        }

        public static bool getIntFromUser(out int number, int min, int max, int _default)
        {
            Console.WriteLine("Please enter a number between " +min+  " and " +max+ ", inclusive.");
            int numComputers = Convert.ToInt32(Console.ReadLine());

            if (numComputers >= min && numComputers <= max)
            {
                number = numComputers;
                return true;
            }
            else
            {
                number = _default;
                return false;
            }
        }


        public static bool doubleIntNotPastMax(ref int number, int max, bool setToMax)
        {

            if (2* number <= max)
                 {
                    number *= 2;
                    return true;
                 }
            else
            {
                if(setToMax == true)
                {
                    number = max;
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }


        public static bool halveValueNotPastMin(ref int number, int min, bool setToMin)
        {
            if(.5*number >= min)
            {
                number /= 2;
                return true;
            }
            else
            {
                if (setToMin == true)
                {
                    number = min;
                    return false;
                }
                else
                {
                    return false;
                }
            }
            
        }

        //Asks the user for information regarding the computer and then adds it to the network
        public static void addAComputer(Computer [] computers, ref int size)
        {
            Console.WriteLine("You've selected to add a Computer. " +
                                                         " \nPlease enter the Id, true or false if it has a cellular antenna, hard drive capacity, and RAM." +
                                                         "\nPress enter after each one. ");
            Computer comp = new Computer(Console.ReadLine());
            comp.HasCellularAntenna = Boolean.Parse(Console.ReadLine());
            comp.HardDriveCapacity = Double.Parse(Console.ReadLine());
            comp.RAM = Int32.Parse(Console.ReadLine());

            int?[] numLicenses = null;

            Console.WriteLine("Does this device allow for preinstalled software? Enter yes if applicable, enter no otherwise. ");
            if (Console.ReadLine() == "yes")
            {
                numLicenses = new int?[5];   // all holding null so far

                Console.WriteLine("Does the device have any preinstalled software? Enter yes or no.");

                if (Console.ReadLine() == "yes")
                {
                    Console.WriteLine("Enter a # from 0-5 for the amount of preinstalled software it has.");
                    int numSoftware = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter a value for the # of licenses each piece of software has. If it has no licenses, enter the value zero." +
                                                        "\nPress enter after each entry.");

                    //Put in the # of licenses into the array
                    int counter = 0;
                    while (counter < numSoftware)
                    {
                        numLicenses[counter] = Int32.Parse(Console.ReadLine());
                        counter++;
                    }
                }
                            

            }
            // if it doesn't allow for preinstalled software, pass in an array initialized to null, otherwise pass in array with some or all of the values set to a value >=0 (some values can be null)
            comp.NumLicenses = numLicenses;

            computers[size] = comp;

            size += 1;
            Console.WriteLine("Computer added!");
            
        }

        public static void setUserPrototype(out Computer userPrototype)
        {
            Console.WriteLine("\nPlease enter the ID of the prototype computer.");
                userPrototype = new Computer(Console.ReadLine());
          Console.WriteLine ( " \nPlease enter  true or false if it has a cellular antenna, a value for the hard drive capacity, and RAM." +
                                                         "\nPress enter after each one. ");

            userPrototype.HasCellularAntenna = Boolean.Parse(Console.ReadLine());
            userPrototype.HardDriveCapacity = Double.Parse(Console.ReadLine());
            userPrototype.RAM = Int32.Parse(Console.ReadLine());

            int?[] numLicenses = null;

            Console.WriteLine("Does the prototype computer allow for preinstalled software? Enter yes if there is any preinstalled software, enter no otherwise. ");
            if (Console.ReadLine() == "yes")
            {
                numLicenses = new int?[5];   // all holding zero so far

                Console.WriteLine("Enter a # from 0-5 for the amount of preinstalled software it has.");
                int numSoftware = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter a value for the # of licenses each piece of software has. If it has no licenses, enter the value zero." +
                                                    "\nPress enter after each entry.");

                //Put in the # of licenses into the array
                int counter = 0;
                while (counter < numSoftware)
                {
                    numLicenses[counter] = Int32.Parse(Console.ReadLine());
                    counter++;
                }



            }
            // if there was no preinstalled software, pass in an array initialized to null, otherwise pass in array with some or all of the values set to a value >=0
            userPrototype.NumLicenses = numLicenses;
            Console.WriteLine("Details of Prototype Computer saved!");


        }


        public static void upgradeCloudStorage(ref int cloudStorage)
        {
            int original = cloudStorage;
            if (original == 16000)
            {
                Console.WriteLine($"Your cloud storage is {cloudStorage} and is already at the max.");
                return;
            }
            
            bool doubled=  doubleIntNotPastMax(ref cloudStorage,16000, false);
             if(doubled)
            {
                Console.WriteLine($"Your cloud storage was upgraded from {original} to {cloudStorage}");
            }
             
            else
              {
                    Console.WriteLine("Sorry. Doubling your cloud storage would make it exceed the maximum.");
               }
          
               
           
        }


        public static void downgradeCloudStorage(ref int cloudStorage)
        {
            int original = cloudStorage;

            if (original == 500)
            {
                Console.WriteLine($"Your cloud storage is {cloudStorage} and is already at the minimum.");
                return;
            }

            bool halved= halveValueNotPastMin(ref cloudStorage, 500, true);
            if (halved)
            {
                Console.WriteLine($"Your cloud storage was downgraded from {original} to {cloudStorage}");

            }
            else

            {
                Console.WriteLine($"Your cloud storage was downgraded to the minimum, {cloudStorage}");
            }


        }


        public static void upgradeNetworkSpeed(ref int networkSpeed)
        {
            int original = networkSpeed;
            if (original == 250000)
            {
                Console.WriteLine($"Your network speed is {networkSpeed} and is already at the max.");
                return;
            }

            bool doubled = doubleIntNotPastMax(ref networkSpeed, 250000, true);
            if (doubled)
            {
                Console.WriteLine($"Your network speed was upgraded from {original} to {networkSpeed}");
            }

            else
            {
                Console.WriteLine($"Your network speed was upgraded to the max, {networkSpeed}");
            }
        }

        public static void downgradeNetworkSpeed(ref int networkSpeed)
        {
            int original = networkSpeed;
            if (original == 1000)
            {
                Console.WriteLine($"Your network speed is {networkSpeed} and is already at the minimum.");
                return;
            }

            bool halved = halveValueNotPastMin(ref networkSpeed, 1000, false);
            if (halved)
            {
                Console.WriteLine($"Your network speed was downgraded from {original} to {networkSpeed}");
            }

            else
            {
                Console.WriteLine("Sorry. Halving your network speed would make it go below the minimum.");
            }


        }

        public static void getSummaryOfAComputer(Computer [] computers, Computer defaultMachine, int cloudStorage, int networkSpeed)
        {
            Console.WriteLine($"Please enter an index from 0-{computers.Length - 1} of the computer you wish to see the details of .");
            int index = Int32.Parse(Console.ReadLine());

            //if there is no computer yet at that index, use the built in prototype
            Console.WriteLine(computers?[index]?.ToString() ?? defaultMachine.ToString());
            Console.WriteLine($"\n\tNetwork Information: \nCloud Storage: {cloudStorage}\nNetwork Speed: {networkSpeed}");
        }


        //gives summary of statistics on RAM, cellur Antenna, hard drive capacity etc. for all devices entered in the array of computers so far:
        public static void getStatisticsForAllComputers(Computer[] computers, int size, int cloudStorage, int networkSpeed)
        {
            // size is the values in the array that have been filled

            Console.WriteLine("\n\tSummary of Statistics for all computers currently part of the network:");

            // none were added yet
            if (size==0)
            {
                Console.WriteLine("No computers were added to the network yet.");
                return;
            }

            double avgRam = 0;
            double percentWithAntenna = 0;
            double avgHardDriveCapacity = 0;
            double avgSoftwareLicensesPerMachine = 0;
            double?[] avgLicensesPerProgram = new double?[5];

            //make counters for how many devices should be included in the percent or average
            int countAntennaApplicable = 0;
            int countHardDriveApplicable = 0;
            int countSoftwareInstalled = 0;    // only count the machines that installed software (any)
            int[] countEachProgramInstalled = new int[5];  // count how many times each program was installed by a machine on the network


            
                for (int index = 0; index < size; index++)
                {
                    avgRam += computers[index].RAM;

                    if (computers[index].HasCellularAntenna.HasValue)
                    {
                        countAntennaApplicable++;

                        if (computers[index].HasCellularAntenna == true)
                        {
                            percentWithAntenna++;
                        }
                    }


                    if (computers[index].HardDriveCapacity.HasValue)
                    {
                        countHardDriveApplicable++;
                        avgHardDriveCapacity += computers[index].HardDriveCapacity.Value;
                        
                    }

                    if (computers[index].NumLicenses !=null)
                    {
                        countSoftwareInstalled++;

                        int numProgram=0;
                        while(numProgram<5)
                        {
                            if (computers[index].NumLicenses[numProgram].HasValue)
                            {
                            avgSoftwareLicensesPerMachine += computers[index].NumLicenses[numProgram].Value;
                            countEachProgramInstalled[numProgram] += 1;
                            avgLicensesPerProgram[numProgram] += computers[index].NumLicenses[numProgram].Value;

                            }
                        numProgram++;
                        }
                        
                    }



                }

                avgRam = avgRam / size;
                percentWithAntenna = percentWithAntenna / countAntennaApplicable * 100;
                avgHardDriveCapacity = avgHardDriveCapacity / countHardDriveApplicable;
                avgSoftwareLicensesPerMachine = avgSoftwareLicensesPerMachine / countSoftwareInstalled;

            Console.WriteLine($"\nAverage RAM: {avgRam}\nPercent of Computers with a Cellular Antenna (where applicable): {percentWithAntenna}%" +
                                        $"\nAverage Hard Drive Capacity (where applicable): {avgHardDriveCapacity}" +
                                        $"\nAverage Total Software Licenses for Machines with software installed: {avgSoftwareLicensesPerMachine}");

            Console.WriteLine("\nAverage Licenses Per Program (where installed):");


            //go through each program to see how many times it was installed, then find the average # of licenses for that program on any machine where installed

            int progNum = 0;

            while (progNum < 5)
            {
                if (avgLicensesPerProgram[progNum] != null)
                { 
                            //find average by dividing all licenses for that program by the # of times the program is installed:
                            avgLicensesPerProgram[progNum] = avgLicensesPerProgram[progNum] / countEachProgramInstalled[progNum];

                            Console.WriteLine($"\n\tProgram #{progNum + 1}:  {avgLicensesPerProgram[progNum].Value}");
                }
            else 
            {
                    Console.WriteLine($"\n\tProgram #{progNum + 1}: not installed");
            }
                progNum++;
            }

            Console.WriteLine($"\n\nCloud Storage: {cloudStorage}\nNetwork Speed: {networkSpeed}");



        }
    }
    }

