using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment7.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addworkflowdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequest_AspNetUsers_AppUserId",
                table: "BookRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BookRequest_Process_ProcessId",
                table: "BookRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_NextStepRule_WorkflowSequence_CurrentStepId",
                table: "NextStepRule");

            migrationBuilder.DropForeignKey(
                name: "FK_NextStepRule_WorkflowSequence_NextStepId",
                table: "NextStepRule");

            migrationBuilder.DropForeignKey(
                name: "FK_Process_AspNetUsers_RequesterId",
                table: "Process");

            migrationBuilder.DropForeignKey(
                name: "FK_Process_NextStepRule_CurrentStepId",
                table: "Process");

            migrationBuilder.DropForeignKey(
                name: "FK_Process_Workflow_WorkflowId",
                table: "Process");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowAction_AspNetUsers_ActorId",
                table: "WorkflowAction");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowAction_Process_ProcessId",
                table: "WorkflowAction");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowAction_WorkflowSequence_StepId",
                table: "WorkflowAction");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowSequence_AspNetRoles_RequiredRoleId",
                table: "WorkflowSequence");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowSequence_Workflow_WorkflowId",
                table: "WorkflowSequence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkflowSequence",
                table: "WorkflowSequence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkflowAction",
                table: "WorkflowAction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workflow",
                table: "Workflow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Process",
                table: "Process");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NextStepRule",
                table: "NextStepRule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookRequest",
                table: "BookRequest");

            migrationBuilder.RenameTable(
                name: "WorkflowSequence",
                newName: "WorkflowSequences");

            migrationBuilder.RenameTable(
                name: "WorkflowAction",
                newName: "WorkflowActions");

            migrationBuilder.RenameTable(
                name: "Workflow",
                newName: "Workflows");

            migrationBuilder.RenameTable(
                name: "Process",
                newName: "Processs");

            migrationBuilder.RenameTable(
                name: "NextStepRule",
                newName: "NextStepRules");

            migrationBuilder.RenameTable(
                name: "BookRequest",
                newName: "BookRequests");

            migrationBuilder.RenameIndex(
                name: "IX_WorkflowSequence_WorkflowId",
                table: "WorkflowSequences",
                newName: "IX_WorkflowSequences_WorkflowId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkflowSequence_RequiredRoleId",
                table: "WorkflowSequences",
                newName: "IX_WorkflowSequences_RequiredRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkflowAction_StepId",
                table: "WorkflowActions",
                newName: "IX_WorkflowActions_StepId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkflowAction_ProcessId",
                table: "WorkflowActions",
                newName: "IX_WorkflowActions_ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkflowAction_ActorId",
                table: "WorkflowActions",
                newName: "IX_WorkflowActions_ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_Process_WorkflowId",
                table: "Processs",
                newName: "IX_Processs_WorkflowId");

            migrationBuilder.RenameIndex(
                name: "IX_Process_RequesterId",
                table: "Processs",
                newName: "IX_Processs_RequesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Process_CurrentStepId",
                table: "Processs",
                newName: "IX_Processs_CurrentStepId");

            migrationBuilder.RenameIndex(
                name: "IX_NextStepRule_NextStepId",
                table: "NextStepRules",
                newName: "IX_NextStepRules_NextStepId");

            migrationBuilder.RenameIndex(
                name: "IX_NextStepRule_CurrentStepId",
                table: "NextStepRules",
                newName: "IX_NextStepRules_CurrentStepId");

            migrationBuilder.RenameIndex(
                name: "IX_BookRequest_ProcessId",
                table: "BookRequests",
                newName: "IX_BookRequests_ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_BookRequest_AppUserId",
                table: "BookRequests",
                newName: "IX_BookRequests_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkflowSequences",
                table: "WorkflowSequences",
                column: "StepId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkflowActions",
                table: "WorkflowActions",
                column: "ActionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workflows",
                table: "Workflows",
                column: "WorkflowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Processs",
                table: "Processs",
                column: "ProcessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NextStepRules",
                table: "NextStepRules",
                column: "RuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookRequests",
                table: "BookRequests",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_AspNetUsers_AppUserId",
                table: "BookRequests",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Processs_ProcessId",
                table: "BookRequests",
                column: "ProcessId",
                principalTable: "Processs",
                principalColumn: "ProcessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NextStepRules_WorkflowSequences_CurrentStepId",
                table: "NextStepRules",
                column: "CurrentStepId",
                principalTable: "WorkflowSequences",
                principalColumn: "StepId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NextStepRules_WorkflowSequences_NextStepId",
                table: "NextStepRules",
                column: "NextStepId",
                principalTable: "WorkflowSequences",
                principalColumn: "StepId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processs_AspNetUsers_RequesterId",
                table: "Processs",
                column: "RequesterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Processs_NextStepRules_CurrentStepId",
                table: "Processs",
                column: "CurrentStepId",
                principalTable: "NextStepRules",
                principalColumn: "RuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processs_Workflows_WorkflowId",
                table: "Processs",
                column: "WorkflowId",
                principalTable: "Workflows",
                principalColumn: "WorkflowId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowActions_AspNetUsers_ActorId",
                table: "WorkflowActions",
                column: "ActorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowActions_Processs_ProcessId",
                table: "WorkflowActions",
                column: "ProcessId",
                principalTable: "Processs",
                principalColumn: "ProcessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowActions_WorkflowSequences_StepId",
                table: "WorkflowActions",
                column: "StepId",
                principalTable: "WorkflowSequences",
                principalColumn: "StepId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowSequences_AspNetRoles_RequiredRoleId",
                table: "WorkflowSequences",
                column: "RequiredRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowSequences_Workflows_WorkflowId",
                table: "WorkflowSequences",
                column: "WorkflowId",
                principalTable: "Workflows",
                principalColumn: "WorkflowId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_AspNetUsers_AppUserId",
                table: "BookRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Processs_ProcessId",
                table: "BookRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_NextStepRules_WorkflowSequences_CurrentStepId",
                table: "NextStepRules");

            migrationBuilder.DropForeignKey(
                name: "FK_NextStepRules_WorkflowSequences_NextStepId",
                table: "NextStepRules");

            migrationBuilder.DropForeignKey(
                name: "FK_Processs_AspNetUsers_RequesterId",
                table: "Processs");

            migrationBuilder.DropForeignKey(
                name: "FK_Processs_NextStepRules_CurrentStepId",
                table: "Processs");

            migrationBuilder.DropForeignKey(
                name: "FK_Processs_Workflows_WorkflowId",
                table: "Processs");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowActions_AspNetUsers_ActorId",
                table: "WorkflowActions");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowActions_Processs_ProcessId",
                table: "WorkflowActions");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowActions_WorkflowSequences_StepId",
                table: "WorkflowActions");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowSequences_AspNetRoles_RequiredRoleId",
                table: "WorkflowSequences");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowSequences_Workflows_WorkflowId",
                table: "WorkflowSequences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkflowSequences",
                table: "WorkflowSequences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workflows",
                table: "Workflows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkflowActions",
                table: "WorkflowActions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Processs",
                table: "Processs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NextStepRules",
                table: "NextStepRules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookRequests",
                table: "BookRequests");

            migrationBuilder.RenameTable(
                name: "WorkflowSequences",
                newName: "WorkflowSequence");

            migrationBuilder.RenameTable(
                name: "Workflows",
                newName: "Workflow");

            migrationBuilder.RenameTable(
                name: "WorkflowActions",
                newName: "WorkflowAction");

            migrationBuilder.RenameTable(
                name: "Processs",
                newName: "Process");

            migrationBuilder.RenameTable(
                name: "NextStepRules",
                newName: "NextStepRule");

            migrationBuilder.RenameTable(
                name: "BookRequests",
                newName: "BookRequest");

            migrationBuilder.RenameIndex(
                name: "IX_WorkflowSequences_WorkflowId",
                table: "WorkflowSequence",
                newName: "IX_WorkflowSequence_WorkflowId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkflowSequences_RequiredRoleId",
                table: "WorkflowSequence",
                newName: "IX_WorkflowSequence_RequiredRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkflowActions_StepId",
                table: "WorkflowAction",
                newName: "IX_WorkflowAction_StepId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkflowActions_ProcessId",
                table: "WorkflowAction",
                newName: "IX_WorkflowAction_ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkflowActions_ActorId",
                table: "WorkflowAction",
                newName: "IX_WorkflowAction_ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_Processs_WorkflowId",
                table: "Process",
                newName: "IX_Process_WorkflowId");

            migrationBuilder.RenameIndex(
                name: "IX_Processs_RequesterId",
                table: "Process",
                newName: "IX_Process_RequesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Processs_CurrentStepId",
                table: "Process",
                newName: "IX_Process_CurrentStepId");

            migrationBuilder.RenameIndex(
                name: "IX_NextStepRules_NextStepId",
                table: "NextStepRule",
                newName: "IX_NextStepRule_NextStepId");

            migrationBuilder.RenameIndex(
                name: "IX_NextStepRules_CurrentStepId",
                table: "NextStepRule",
                newName: "IX_NextStepRule_CurrentStepId");

            migrationBuilder.RenameIndex(
                name: "IX_BookRequests_ProcessId",
                table: "BookRequest",
                newName: "IX_BookRequest_ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_BookRequests_AppUserId",
                table: "BookRequest",
                newName: "IX_BookRequest_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkflowSequence",
                table: "WorkflowSequence",
                column: "StepId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workflow",
                table: "Workflow",
                column: "WorkflowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkflowAction",
                table: "WorkflowAction",
                column: "ActionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Process",
                table: "Process",
                column: "ProcessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NextStepRule",
                table: "NextStepRule",
                column: "RuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookRequest",
                table: "BookRequest",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequest_AspNetUsers_AppUserId",
                table: "BookRequest",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequest_Process_ProcessId",
                table: "BookRequest",
                column: "ProcessId",
                principalTable: "Process",
                principalColumn: "ProcessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NextStepRule_WorkflowSequence_CurrentStepId",
                table: "NextStepRule",
                column: "CurrentStepId",
                principalTable: "WorkflowSequence",
                principalColumn: "StepId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NextStepRule_WorkflowSequence_NextStepId",
                table: "NextStepRule",
                column: "NextStepId",
                principalTable: "WorkflowSequence",
                principalColumn: "StepId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Process_AspNetUsers_RequesterId",
                table: "Process",
                column: "RequesterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Process_NextStepRule_CurrentStepId",
                table: "Process",
                column: "CurrentStepId",
                principalTable: "NextStepRule",
                principalColumn: "RuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Workflow_WorkflowId",
                table: "Process",
                column: "WorkflowId",
                principalTable: "Workflow",
                principalColumn: "WorkflowId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowAction_AspNetUsers_ActorId",
                table: "WorkflowAction",
                column: "ActorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowAction_Process_ProcessId",
                table: "WorkflowAction",
                column: "ProcessId",
                principalTable: "Process",
                principalColumn: "ProcessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowAction_WorkflowSequence_StepId",
                table: "WorkflowAction",
                column: "StepId",
                principalTable: "WorkflowSequence",
                principalColumn: "StepId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowSequence_AspNetRoles_RequiredRoleId",
                table: "WorkflowSequence",
                column: "RequiredRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowSequence_Workflow_WorkflowId",
                table: "WorkflowSequence",
                column: "WorkflowId",
                principalTable: "Workflow",
                principalColumn: "WorkflowId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
