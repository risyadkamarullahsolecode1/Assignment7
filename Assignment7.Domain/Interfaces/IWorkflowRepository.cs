using Assignment7.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Domain.Interfaces
{
    public interface IWorkflowRepository
    {
        Task<Workflow> AddWorkflow(Workflow workflow);
        Task<WorkflowSequence> AddWorkflowSequence(WorkflowSequence workflowSequence);
        Task<Workflow?> GetFirstOrDefaultAsync(Expression<Func<Workflow, bool>> expression);
        Task<BookRequest> SubmitLeaveRequestAsync(BookRequest request);
        Task<Process> AddProcessLeaveRequest(Process process);
        Task<WorkflowAction> AddAction(WorkflowAction workflowAction);
        Task SubmitBookRequestAsync(BookRequest requestDto, string userId);
        Task<bool> ApproveBookRequestAsync(int workflowActionId, int processId, string actorId, string role, bool isApproved, string comment);
    }
}
