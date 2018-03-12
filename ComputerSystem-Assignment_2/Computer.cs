using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSystem_Assignment_2
{
    class Computer
    {
        private readonly String id;
        private bool? hasCellularAntenna;
        private double? hardDriveCapacity;
        private int rAM;
        private int?[] numLicenses;
       

        public Computer(String id)
        {
            this.id = id;
            numLicenses = new int?[5];
        }

        public String Id
        {
            get;
        }

        public bool? HasCellularAntenna
        {

            get
            {
                return hasCellularAntenna;
            }
            set
            {
                hasCellularAntenna = value;
            }
        }


        public double? HardDriveCapacity
        {
            get
            {
                return hardDriveCapacity;
            }
            set
            {
                if (value <0)
                {
                    throw new ArgumentOutOfRangeException("Value can't be negative");
                }
                else
                {
                    hardDriveCapacity = value;
                }
            }
        }

        
        public int RAM
        {
            get
            {
                if (hasCellularAntenna == null || hasCellularAntenna==false)
                {
                    rAM -= 50;
                }
                else
                {
                    rAM -= 100;
                }

                if (numLicenses == null)
                {
                    return rAM;
                }
                else
                {  // for every piece of software that is licensed (numLicenses not equal zero), so subtract 10 from available RAM
                    for (int n=0; n<numLicenses.Length;n++)
                    {
                        if(numLicenses[n] != null && numLicenses[n]>0)
                            {
                            rAM -= 10;   
                            }
                    }

                    return rAM;
                }
           
            }


            set
            {
                if (value < 1000)
                {
                    throw new ArgumentOutOfRangeException("RAM must be at least 1000.");
                }
                else
                {
                    rAM = value;
                }
            }
        }

        public int?[] NumLicenses
        {
            get
            {
                return numLicenses;
            }
            set
            {
                numLicenses = value;
            }
        }

        override
        public String ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append($"\n\tComputer Information: \nID: {id} \nHas Cellular Antenna: " );

            if (hasCellularAntenna.HasValue)
            {
                if (hasCellularAntenna == true)
                {
                    output.Append("yes");
                }
                else
                {
                    output.Append("no");
                }
            }
            else { output.Append("not applicable"); }

                output.Append($"\nHard Drive Capacity: { hardDriveCapacity?.ToString() ?? "not applicable"}");
                output.Append($"\nRAM: {rAM}");
                
                output.Append("\nLicenses for preinstalled software: ");

            if (numLicenses == null)
            {
                output.Append("not applicable");
            }
            else
            {
                for (int x = 0; x < numLicenses.Length; x++)
                {
                    output.Append($"\n\tLicenses for  preinstalled software #{x + 1}: ");
                    if (numLicenses[x] !=null)
                    {
                        output.Append(numLicenses[x]);
                    }
                    else
                    {
                        output.Append("software not installed");
                    }

                }
            }      


                return output.ToString();
        }

        
    }
}
