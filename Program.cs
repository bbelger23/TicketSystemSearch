using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TicketSystemSearch
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            string defectFilePath = Directory.GetCurrentDirectory() + "\\tickets.csv";
            string enhanceFilePath = Directory.GetCurrentDirectory() + "\\enhancements.csv";
            string taskFilePath = Directory.GetCurrentDirectory() + "\\tasks.csv";

            logger.Info("Program Started");

            DefectFile defectFile = new DefectFile(defectFilePath);
            EnhanceFile enhanceFile = new EnhanceFile(enhanceFilePath);
            TaskFile taskFile = new TaskFile(taskFilePath);
            
            string option = "";
            string addChoice = "";
            string displayChoice = "";
            string searchChoice = "";
            string find = "";

            // user options
            do{
                Console.WriteLine("Select Option");
                Console.WriteLine("1. Add Tickets");
                Console.WriteLine("2. Display Tickets");
                Console.WriteLine("3. Search Tickets");
                Console.WriteLine("Press any key to quit");

                option = Console.ReadLine();

                if (option == "1")
                {
                    do{
                        Console.WriteLine("Select Choice");
                        Console.WriteLine("1. Add Bug/Defect Ticket");
                        Console.WriteLine("2. Add Enhancement Ticket");
                        Console.WriteLine("3. Add Task Ticket");
                        Console.WriteLine("Press any key to return to Select Option");

                        addChoice = Console.ReadLine();

                        if (addChoice == "1")
                        {
                            // add ticket
                            Defect defect = new Defect();
                            // user adds summary
                            Console.WriteLine("Enter ticket summary");
                            defect.summary = Console.ReadLine();
                            // user adds status of ticket
                            Console.WriteLine("Enter ticket status");
                            defect.status = Console.ReadLine();
                            // user adds priority of ticket
                            Console.WriteLine("Enter ticket priority");
                            defect.priority = Console.ReadLine();
                            // user adds who submitted the ticket
                            Console.WriteLine("Enter ticket submitter");
                            defect.submit = Console.ReadLine();
                            // user adds who the ticket is assigned to
                            Console.WriteLine("Enter who ticket is assigned to");
                            defect.assigned = Console.ReadLine();
                            // user adds who is watching the ticket
                            string input;
                            do
                            {
                                Console.WriteLine("Enter who is watching ticket (or done to quit)");
                                input = Console.ReadLine();
                                if (input != "done" && input.Length > 0)
                                {
                                    defect.watching.Add(input);
                                }
                            } while (input != "done");
                            if (defect.watching.Count == 0)
                            {
                                defect.watching.Add("(No one is watching the ticket)");
                            }
                            // user adds the severity of ticket
                            Console.WriteLine("Enter ticket severity");
                            defect.severity = Console.ReadLine();

                            defectFile.AddDefect(defect);

                        }

                        logger.Info("Ticket Added");

                        if (addChoice == "2")
                        {
                            // add ticket
                            Enhancement enhancement = new Enhancement();
                            // user adds summary
                            Console.WriteLine("Enter ticket summary");
                            enhancement.summary = Console.ReadLine();
                            // user adds status of ticket
                            Console.WriteLine("Enter ticket status");
                            enhancement.status = Console.ReadLine();
                            // user adds priority of ticket
                            Console.WriteLine("Enter ticket priority");
                            enhancement.priority = Console.ReadLine();
                            // user adds who submitted the ticket
                            Console.WriteLine("Enter ticket submitter");
                            enhancement.submit = Console.ReadLine();
                            // user adds who the ticket is assigned to
                            Console.WriteLine("Enter who ticket is assigned to");
                            enhancement.assigned = Console.ReadLine();
                            // user adds who is watching the ticket
                            string input;
                            do
                            {
                                Console.WriteLine("Enter who is watching ticket (or done to quit)");
                                input = Console.ReadLine();
                                if (input != "done" && input.Length > 0)
                                {
                                    enhancement.watching.Add(input);
                                }
                            } while (input != "done");
                            if (enhancement.watching.Count == 0)
                            {
                                enhancement.watching.Add("(No one is watching the ticket)");
                            }
                            // user adds software
                            Console.WriteLine("Enter the software");
                            enhancement.software = Console.ReadLine();
                            // user adds cost
                            Console.WriteLine("Enter the cost");
                            enhancement.cost = Console.ReadLine();
                            // user enters reason
                            Console.WriteLine("Enter the reason");
                            enhancement.reason = Console.ReadLine();
                            // user enters estimate
                            Console.WriteLine("Enter the estimate(MM/DD/YYYY)");
                            enhancement.estimate = DateTime.Parse(Console.ReadLine());

                            enhanceFile.AddEnhancement(enhancement);
                        }

                        logger.Info("Ticket Added");

                        if (addChoice == "3")
                        {
                            // add ticket
                            Task task = new Task();
                            // user adds summary
                            Console.WriteLine("Enter ticket summary");
                            task.summary = Console.ReadLine();
                            // user adds status of ticket
                            Console.WriteLine("Enter ticket status");
                            task.status = Console.ReadLine();
                            // user adds priority of ticket
                            Console.WriteLine("Enter ticket priority");
                            task.priority = Console.ReadLine();
                            // user adds who submitted the ticket
                            Console.WriteLine("Enter ticket submitter");
                            task.submit = Console.ReadLine();
                            // user adds who the ticket is assigned to
                            Console.WriteLine("Enter who ticket is assigned to");
                            task.assigned = Console.ReadLine();
                            // user adds who is watching the ticket
                            string input;
                            do
                            {
                                Console.WriteLine("Enter who is watching ticket (or done to quit)");
                                input = Console.ReadLine();
                                if (input != "done" && input.Length > 0)
                                {
                                    task.watching.Add(input);
                                }
                            } while (input != "done");
                            if (task.watching.Count == 0)
                            {
                                task.watching.Add("(No one is watching the ticket)");
                            }
                            // user adds project name
                            Console.WriteLine("Enter project name");
                            task.projectName = Console.ReadLine();
                            // user adds due date
                            Console.WriteLine("Enter due date");
                            task.dueDate = DateTime.Parse(Console.ReadLine());

                            taskFile.AddTask(task);
                        }
                        logger.Info("Ticket Added");
                        
                    } while (addChoice == "1" || addChoice == "2" || addChoice == "3");

                    
                    
                } else if (option == "2")
                {
                    do{
                        Console.WriteLine("Select Choice");
                        Console.WriteLine("1. Display Bug/Defect Ticket");
                        Console.WriteLine("2. Display Enhancement Ticket");
                        Console.WriteLine("3. Display Task Ticket");
                        Console.WriteLine("Press any key to return to Select Option");

                        displayChoice = Console.ReadLine();

                        if (displayChoice == "1")
                        {
                            foreach(Defect t in defectFile.Defects)
                            {
                                Console.WriteLine(t.Display());
                            }
                        }
                        if (displayChoice == "2")
                        {
                            foreach(Enhancement t in enhanceFile.Enhancements)
                            {
                                Console.WriteLine(t.Display());
                            }
                        }
                        if (displayChoice == "3")
                        {
                            foreach(Task t in taskFile.Tasks)
                            {
                                Console.WriteLine(t.Display());
                            }
                        }
                    } while (displayChoice == "1" || displayChoice == "2" || displayChoice == "3");

                } else if (option == "3")
                {
                    Console.WriteLine("Select Choice");
                    Console.WriteLine("1. Search by status");
                    Console.WriteLine("2. Search by priority");
                    Console.WriteLine("3. Search by submitter");
                    Console.WriteLine("Press any key to return to Select Option");

                    searchChoice = Console.ReadLine();

                    if (searchChoice == "1")
                    {
                        // ask user the status of ticket they want found
                        Console.WriteLine("Enter status of ticket you want to find");
                        find = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        
                        var findDefect = defectFile.Defects.Where(t => t.status.Contains(find));

                        foreach(Defect t in findDefect)
                        {
                            Console.WriteLine($" {t.status}");
                        }
                        
                        var findEnhance = enhanceFile.Enhancements.Where(t => t.status.Contains(find));

                        foreach(Enhancement t in findEnhance)
                        {
                            Console.WriteLine($" {t.status}");
                        }

                        var findTask = taskFile.Tasks.Where(t => t.status.Contains(find));

                        foreach(Task t in findTask)
                        {
                            Console.WriteLine($" {t.status}");
                        }

                        Console.WriteLine($"There are {findDefect.Count() + findEnhance.Count() + findTask.Count()} {find} tickets found");

                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (searchChoice == "2")
                    {
                        // ask user the priority of ticket they want found
                        Console.WriteLine("Enter priority of ticket you want to find");
                        find = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        
                        var findDefect = defectFile.Defects.Where(t => t.priority.Contains(find));

                        foreach(Defect t in findDefect)
                        {
                            Console.WriteLine($" {t.priority}");
                        }
                        
                        var findEnhance = enhanceFile.Enhancements.Where(t => t.priority.Contains(find));

                        foreach(Enhancement t in findEnhance)
                        {
                            Console.WriteLine($" {t.priority}");
                        }

                        var findTask = taskFile.Tasks.Where(t => t.priority.Contains(find));

                        foreach(Task t in findTask)
                        {
                            Console.WriteLine($" {t.priority}");
                        }

                        Console.WriteLine($"There are {findDefect.Count() + findEnhance.Count() + findTask.Count()} {find} priority tickets found");

                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (searchChoice == "3")
                    {
                        // ask user the submitter they want to find
                        Console.WriteLine("Enter submitter of ticket you want to find");
                        find = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        
                        var findDefect = defectFile.Defects.Where(t => t.submit.Contains(find));

                        foreach(Defect t in findDefect)
                        {
                            Console.WriteLine($" {t.submit}");
                        }
                        
                        var findEnhance = enhanceFile.Enhancements.Where(t => t.submit.Contains(find));

                        foreach(Enhancement t in findEnhance)
                        {
                            Console.WriteLine($" {t.submit}");
                        }

                        var findTask = taskFile.Tasks.Where(t => t.submit.Contains(find));

                        foreach(Task t in findTask)
                        {
                            Console.WriteLine($" {t.submit}");
                        }

                        Console.WriteLine($"There are {findDefect.Count() + findEnhance.Count() + findTask.Count()} tickets that {find} submitted");

                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            } while (option == "1" || option == "2" || option == "3"); 

            logger.Info("Program Ended");    
        }
    }
}
