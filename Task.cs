using System;

namespace TicketSystemSearch
{
    public class Task : Ticket
    {
        public string projectName {get;set;}
        public DateTime dueDate {get;set;}
        public override string Display()
        {
            return $"Id: {ticketID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submit}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}\nProject Name: {projectName}\nDue Date: {dueDate}";
        }
    }
}