using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Handles a request by different handlers in sequence

/***********************************
LeaveRequest: request class – this request is handled by different handlers in chain

ILeaveRequestHandler: IHandler interface

Supervisor, ProjectManager, HR: concrete handler interface

***********************************/

namespace ChainofResponsibility
{
    //Request - will be handled by different handler
    public class LeaveRequest
    {
        public string Employee { get; set; }
        public int LeaveDays { get; set; }
    }
    //'IHandler' interface
    public interface ILeaveRequestHandler
    {
        void HandleRequest(LeaveRequest request);
        ILeaveRequestHandler nextHandler { get; set; }
    }
    //'supervisor' class - 'ConcreteHandler' class
    public class Supervisor : ILeaveRequestHandler
    {
        public ILeaveRequestHandler nextHandler { get; set; }
        public void HandleRequest(LeaveRequest request)
        {
            if (request.LeaveDays <= 10)
            {
                Console.WriteLine("Leave request:- Employee: {0}, Leave days: {1} - approved by supervisor", request.Employee, request.LeaveDays);
            }
            else
            {
                nextHandler.HandleRequest(request);
            }
        }
    }
    //'ProjectManager' class - 'ConcreteHandler' class
    public class ProjectManager : ILeaveRequestHandler
    {
        public ILeaveRequestHandler nextHandler { get; set; }
        public void HandleRequest(LeaveRequest request)
        {
            if (request.LeaveDays <= 30)
            {
                Console.WriteLine("Leave request:- Employee: {0}, Leave days: {1} - approved by project manager", request.Employee, request.LeaveDays);
            }
            else
            {
                nextHandler.HandleRequest(request);
            }
        }
    }
    //'HR' class - 'ConcreteHandler' class
    public class HR : ILeaveRequestHandler
    {
        public ILeaveRequestHandler nextHandler { get; set; }
        public void HandleRequest(LeaveRequest request)
        {
            if (request.LeaveDays > 30)
            {
                Console.WriteLine("Leave request:- Employee: {0}, Leave days: {1} - approved by HR", request.Employee, request.LeaveDays);
            }
            else
            {
                nextHandler.HandleRequest(request);
            }
        }
    }
    //'client'
    class Program
    {
        static void Main(string[] args)
        {
            LeaveRequest request = new LeaveRequest();
            request.Employee = "john";
            request.LeaveDays = 34;

            ILeaveRequestHandler supervisor = new Supervisor();
            ILeaveRequestHandler manager = new ProjectManager();
            ILeaveRequestHandler hr = new HR();

            supervisor.nextHandler = manager;
            manager.nextHandler = hr;

            supervisor.HandleRequest(request);
            request.LeaveDays = 14;
            supervisor.HandleRequest(request);
            request.LeaveDays = 4;
            supervisor.HandleRequest(request);

            Console.ReadLine();
        }
    }
}
