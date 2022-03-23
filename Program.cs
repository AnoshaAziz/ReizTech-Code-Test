using System;
using System.Collections.Generic;

namespace ReizTech
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var angle = CalculateAngle(13, 30);
                Console.WriteLine("The Calculate degrees are {0}", angle);
                var tree = GenerateExampleTreeStructure();
                var depthOfTree = DepthOfTree(tree);
                Console.WriteLine("The Depth of Tree {0}", depthOfTree);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static int CalculateAngle(int hours, int minutes)
        {

            if (!(hours <= 24 && minutes <= 60))
            {
                throw new Exception("Invalid Data has been entered");
            }
            var minuteHandPerMinuteAngle = 360 / 60;
            double hourHandPerMinuteAngle = (double)360 / (60 * 12);

            int hour = hours % 12;
            var hoursAngle = ((hour * 60) + minutes) * hourHandPerMinuteAngle;
            var minuteAngle = minutes * minuteHandPerMinuteAngle;

            var calculatedAngleBetweenHoursAndMinutes = (int)Math.Abs(hoursAngle - minuteAngle);
            return calculatedAngleBetweenHoursAndMinutes;

        }

        static Branch GenerateExampleTreeStructure()
        {
            var root = new Branch
            {
                Level = 1,
                Branches = new List<Branch>
            {
                new Branch
                {
                   Level= 2,
                   Branches=new List<Branch>
                   {

                       new Branch
                       {
                            Level=3
                       }
                   }

                },
                 new Branch
                {
                   Level=2,
                   Branches=new List<Branch>
                   {
                         new Branch
                       {
                            Level=3,
                            Branches=new List<Branch>
                            {
                                new Branch
                                {
                                    Level=4

                                }
                            }
                       },
                       new Branch
                       {
                            Level=3,
                            Branches=new List<Branch>
                            {
                                new Branch
                                {
                                    Level=4,
                                    Branches=new List<Branch>
                                    {
                                        new Branch
                                        {
                                            Level=5
                                        }
                                    }
                                },
                                new Branch
                                {
                                    Level=4
                                }
                            }
                       },
                        new Branch
                       {
                            Level=3,
                            Branches=new List<Branch>
                            {
                                new Branch
                                {
                                    Level=4

                                }
                            }
                       },


                   }

                },


            }
            };

            return root;
        }
        static int DepthOfTree(Branch ptr)
        {
            // Base case
            if (ptr == null)
                return 0;

            // Check for all children and find
            // the maximum depth
            int maxdepth = 0;
            if (ptr.Branches != null)
            {
                foreach (Branch branch in ptr.Branches)
                {
                    maxdepth = Math.Max(maxdepth, DepthOfTree(branch));
                }
            }


            return maxdepth + 1;
        }

    }

    public class Branch
    {
        /// <summary>
        /// level is used to identify test data not for depth caluclation
        /// </summary>
        public int Level { get; set; }
        public List<Branch> Branches { get; set; }
    }
}
